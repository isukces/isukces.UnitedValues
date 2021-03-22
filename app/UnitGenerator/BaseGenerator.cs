using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public abstract class BaseGenerator<TDef>
    {
        protected BaseGenerator(string output, string nameSpace)
        {
            _output    = output;
            _nameSpace = nameSpace;
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
                var file = new CsFile();
                PrepareFile(file);
                var ns   = file.GetOrCreateNamespace(_nameSpace);
                var name = GetTypename(unit);
                Target           = ns.GetOrCreateClass(name);
                Target.IsPartial = true;
                GenerateOne();
                file.BeginContent += "// generator: " + GetType().Name;
                var filename = Path.Combine(_output, name + ".auto.cs");
                if (filename==@"C:\programs\isukces\dotnetLib\isukces.UnitedValues\app\iSukces.UnitedValues\+jsonConverters\DensityJsonConverter.auto.cs")
                    Debug.WriteLine("");
                file.SaveIfDifferent(filename);
            }
        }

        protected void Add_Constructor(params ConstructorParameterInfo[] items)
        {
            var code = new CsCodeWriter();
            var m    = Target.AddConstructor("creates instance of " + Target.Name);
            foreach (var i in items)
            {
                code.WriteLine(string.Format("{0} = {1};", i.PropertyName, i.Expression));
                m.AddParam(i.PropertyName.FirstLower(), i.PropertyType, i.Description);
            }

            m.WithBody(code);
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


        protected void Add_Properties(params ConstructorParameterInfo[] items)
        {
            foreach (var i in items) Add_Property(i.PropertyName, i.PropertyType, i.Description);
        }

        protected void Add_Property(string name, string type, string description)
        {
            Target.AddProperty(name, type)
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

        protected abstract void GenerateOne();
        protected abstract string GetTypename(TDef cfg);

        protected virtual void PrepareFile(CsFile file)
        {
            file.AddImportNamespace("System");
            file.AddImportNamespace("System.Globalization");
        }

        protected string ReturnValue(string expression)
        {
            return "return " + expression + ";";
        }

        protected TDef Cfg { get; private set; }

        protected CsClass Target { get; private set; }

        private readonly string _output;
        private readonly string _nameSpace;
    }
}