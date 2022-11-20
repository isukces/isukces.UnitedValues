using System.Collections.Generic;
using System.IO;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using JetBrains.Annotations;
using UnitGenerator.Local;

namespace UnitGenerator
{
    public abstract class BaseGenerator<TDef>
    {
        protected BaseGenerator(string output, string nameSpace)
        {
            _output    = output;
            _nameSpace = nameSpace;
        }

        protected static string MakeGenericType<TGenericType>(ITypeNameResolver reslve, ITypeNameProvider arg)
        {
            return MakeGenericType<TGenericType>(reslve, arg.GetTypename());
        }

        protected static string MakeGenericType<TGenericType>(ITypeNameResolver reslve, string arg)
        {
            var tn    = reslve.GetTypeName<TGenericType>();
            var parts = tn.Split('<');
            return parts[0] + "<" + arg + ">";
        }

        protected static void MakeToString(CsClass cl, string returnValue)
        {
            var m = cl.AddMethod("ToString", "string").WithBody($"return {returnValue};");
            m.Overriding = OverridingType.Override;
        }

        public void Generate(IEnumerable<TDef> all)
        {
            foreach (var unit in all)
            {
                Cfg = unit;
                if (!CanGenerate())
                    continue;
                var name = GetTypename(unit);
                /*var info = CsFilesManager.Instance.GetFileInfo(name, _nameSpace);

                var file = info.File;
                if (!info.IsEmbedded)
                    PrepareFile(file);
                var ns   = file.GetOrCreateNamespace(_nameSpace);
                
                Target           = ns.GetOrCreateClass(name);
                Target.IsPartial = true;*/
                Target = Get(name, out var file);
                GenerateOne();
                CsFilesManager.AddGeneratorName(file, GetType().Name);
                
            }
        }

        protected CsClass Get(string name, out CsFile file)
        {
            var info = CsFilesManager.Instance.GetFileInfo(name, _nameSpace);

            file = info.File;
            if (!info.IsEmbedded)
                PrepareFile(file);
            var ns = file.GetOrCreateNamespace(_nameSpace);
                
            var t= ns.GetOrCreateClass(name);
            t.IsPartial = true;
            
            
            if (!info.IsEmbedded)
            {
                var filename = Path.Combine(_output, name + ".auto.cs");
                file.SaveIfDifferent(filename);
            }
            
            return t;
        }

        protected void Add_Constructor(Col1 col)
        {
            var target = Target;
            var code   = new CsCodeWriter();
            var m      = target.AddConstructor("creates instance of " + target.Name);
            var c      = col.Writer1.Code;
            if (!string.IsNullOrEmpty(c))
                code.WriteLine(c);
            foreach (var i in col.Items)
            {
                var flags = i.CheckingFlags;
                code.CheckArgument(i.ArgName, flags.ConvertToArgChecking(), Target);
                var p = m.AddParam(i.PropertyName.FirstLower(), i.PropertyType, i.Description);
                if ((flags & Flags1.Optional) != 0)
                    p.ConstValue = "null";

                /*if ((flags & Flags1.TrimValue) != 0)
                {
                    code.WriteLine("{0} = {0}?.Trim();", i.ArgName);
                    flags &= ~Flags1.TrimValue;

                    if ((flags & Flags1.NotWhitespace) != 0)
                    {
                        flags &= ~Flags1.NotWhitespace;
                        flags |= Flags1.NotEmpty;
                    }
                }*/

                /*if ((flags & Flags1.NotNull) != 0)
                {
                    flags &= ~Flags1.NotNull;
                    p.Attributes.Add(CsAttribute.Make<NotNullAttribute>(target));
                    var throwCode = new Args($"nameof({i.ArgName})")
                        .Throw<NullReferenceException>(target);
                    code.SingleLineIf($"{i.ArgName} is null", throwCode);
                }*/

                /*if ((flags & Flags1.NotWhitespace) != 0)
                {
                    flags &= ~(Flags1.NotEmpty | Flags1.NotWhitespace);
                    // var m = nameof(string.IsNullOrWhiteSpace);
                    var throwCode = new Args($"nameof({i.ArgName})")
                        .Throw<ArgumentException>(target);
                    code.SingleLineIf($"string.IsNullOrWhiteSpace({i.ArgName})", throwCode);

                    flags &= ~(Flags1.NotNullOrWhitespace | Flags1.NotNullOrEmpty);
                }

                if ((flags & Flags1.NotEmpty) != 0)
                {
                    flags &= ~Flags1.NotEmpty;
                    //var m = nameof(string.IsNullOrEmpty);
                    var throwCode = new Args($"nameof({i.ArgName})")
                        .Throw<ArgumentException>(target);
                    code.SingleLineIf($"string.IsNullOrEmpty({i.ArgName})", throwCode);

                    flags &= ~(Flags1.NotNullOrWhitespace | Flags1.NotNullOrEmpty);
                }*/

                if ((flags & Flags1.DoNotAssignProperty) == 0)
                    code.WriteAssign(i.PropertyName, i.Expression);
            }

            c = col.Writer2.Code;
            if (!string.IsNullOrEmpty(c))
                code.WriteLine(c);

            m.WithBody(code);
        }

        protected void Add_EqualsUniversal(string compareType, bool nullable, OverridingType overridingType,
            string compareCode)
        {
            var cw = new CsCodeWriter();
            if (nullable)
                cw.SingleLineIf("other is null", ReturnValue("false"));
            cw.WriteLine(ReturnValue(compareCode));
            var m = Target.AddMethod("Equals", "bool")
                .WithBody(cw);
            m.Overriding = overridingType;
            m.AddParam("other", compareType);
        }

        protected void Add_GetHashCode(string expression)
        {
            CodeWriter cw = new CsCodeWriter();
            cw.Open("unchecked");
            cw.WriteLine(ReturnValue(expression));
            cw.Close();
            Target.AddMethod("GetHashCode", "int")
                .WithOverride()
                .WithBody(cw);
        }

        protected void Add_ImplicitOperator(string source, string target, string expr)
        {
            var description = $"Converts {source} into {target} implicitly.";
            var m = Target.AddMethod(CsMethod.Implicit, target, description)
                .WithBodyFromExpression(expr);
            m.AddParam("src", source);
        }


        protected void Add_Properties(Col1 c)
        {
            foreach (var i in c.Items)
            {
                if ((i.CheckingFlags & Flags1.DoNotCreateProperty) != 0)
                    continue;
                var p = Add_Property(i.PropertyName, i.PropertyType, i.Description);
                i.PropertyCreated?.Invoke(p);
                if ((i.CheckingFlags & Flags1.NotNull) == 0) continue;

                if (Target.Kind == CsNamespaceMemberKind.Class)
                    if ((i.CheckingFlags & Flags1.AddNotNullAttributeToPropertyIfPossible) != 0)
                        p.WithAttribute(CsAttribute.Make<NotNullAttribute>(Target));

                if ((i.CheckingFlags & Flags1.PropertyCanBeNull) != 0)
                    p.WithAttribute(CsAttribute.Make<CanBeNullAttribute>(Target));
            }
        }

        protected CsProperty Add_Property(string name, string type, string description)
        {
            return Target.AddProperty(name, type)
                .WithDescription(description)
                .WithNoEmitField()
                .WithMakeAutoImplementIfPossible()
                .WithIsPropertyReadOnly();
        }

        protected void Add_ToString(string expression)
        {
            Target.AddMethod("ToString", "string", "Returns unit name")
                .WithOverride()
                .WithBody("return " + expression + ";");
        }


        protected void AddCommon_EqualityOperators()
        {
            for (var i = 0; i < 2; i++)
            {
                var eq = i == 0;
                var m = Target.AddMethod(eq ? "==" : "!=", "bool", eq ? "Equality operator" : "Inequality operator")
                    .WithBody($"return {(eq ? "" : "!")}left.Equals(right);");

                m.AddParam("left", Target.Name, "first value to compare");
                m.AddParam("right", Target.Name, "second value to compare");
            }
        }

        protected virtual bool CanGenerate()
        {
            return true;
        }

        protected abstract void GenerateOne();
        protected abstract string GetTypename(TDef cfg);

        protected virtual void PrepareFile(CsFile file)
        {
            if (file.Namespaces.Any())
                return;
            file.AddImportNamespace("System");
            file.AddImportNamespace("System.Globalization");
            file.AddImportNamespace("System.Collections.Generic");
            file.AddImportNamespace("JetBrains.Annotations");
        }

        protected string ReturnValue(string expression)
        {
            return "return " + expression + ";";
        }

        protected TDef Cfg { get; private set; }

        protected CsClass Target { get; private set; }
        protected static ClrTypesResolver _resolver = new ClrTypesResolver(typeof(Length).Assembly);

        private readonly string _output;
        private readonly string _nameSpace;
    }
}