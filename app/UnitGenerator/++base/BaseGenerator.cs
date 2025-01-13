using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using JetBrains.Annotations;
using UnitGenerator.Local;

namespace UnitGenerator;

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
        var parts = tn.Declaration.Split('<');
        return parts[0] + "<" + arg + ">";
    }

    protected static void MakeToString(CsClass cl, string returnValue)
    {
        var m = cl.AddMethod("ToString", CsType.String).WithBody($"return {returnValue};");
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
                
        var t = ns.GetOrCreateClass(name);
        t = GeneratorCommon.Setup(t);

        if (info.IsEmbedded) 
            return t;
        var filename = Path.Combine(_output, name + ".auto.cs");
        file.SaveIfDifferent(filename);

        return t;
    }

    protected void Add_Constructor(Col1 col)
    {
        var target = Target;
        var code   = new CsCodeWriter();
        var m      = target.AddConstructor("creates instance of " + target.Name.Declaration);
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

            if ((flags & Flags1.DoNotAssignProperty) == 0)
            {
                var fieldOrProperty = (flags & Flags1.EmitField) == 0
                    ? i.PropertyName
                    : i.FieldName;
                code.WriteAssign(fieldOrProperty, i.Expression);
            }
        }

        c = col.Writer2.Code;
        if (!string.IsNullOrEmpty(c))
            code.WriteLine(c);

        m.WithBody(code);
    }
    
    protected void Add_EqualsUniversal(CsType compareType, bool addNullableChecking, OverridingType overridingType, string compareCode)
    {
        var cw = CsCodeWriter.Create(new SourceCodeLocation().WithGeneratorClass(GetType()));
        if (addNullableChecking)
            cw.SingleLineIf("other is null", ReturnValue("false"));
        cw.WriteLine(ReturnValue(compareCode));
        var m = Target.AddMethod(nameof(Equals), CsType.Bool)
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
        Target.AddMethod("GetHashCode", CsType.Int32)
            .WithOverride()
            .WithBody(cw);
    }

    protected void Add_ImplicitOperator(CsType source, CsType target, string expr)
    {
        var description = $"Converts {source.Declaration} into {target.Declaration} implicitly.";
        var m = Target.AddMethod(CsMethod.Implicit, target, description)
            .WithBodyFromExpression(expr);
        m.AddParam("src", source);
    }


    protected void Add_Properties(Col1 c)
    {
        foreach (var i in c.Items)
        {
            AddOneProperty(i);
        }

        return;

        void AddOneProperty(ConstructorParameterInfo i)
        {
            if ((i.CheckingFlags & Flags1.DoNotCreateProperty) != 0)
                return;

            var p = Add_Property(i.PropertyName, i.PropertyType, i.Description);
            p.EmitField = (i.CheckingFlags & Flags1.EmitField) != 0;
            if (p.EmitField)
            {
                p.MakeAutoImplementIfPossible = false;
                if (!string.IsNullOrEmpty(i.PropertyDefaultValue))
                    p.WithOwnGetterAsExpression(p.PropertyFieldName + " ?? " + i.PropertyDefaultValue);
            }

            i.PropertyCreated?.Invoke(p);
            var tmp = AddNotNullAttribute(i);
            switch (tmp)
            {
                case NotNullAttributeType.NotNull:
                    p.WithAttribute(CsAttribute.Make<NotNullAttribute>(Target));
                    break;
                case NotNullAttributeType.CanBeNull:
                    p.WithAttribute(CsAttribute.Make<CanBeNullAttribute>(Target));
                    break;
                case NotNullAttributeType.None: break;
                default: throw new ArgumentOutOfRangeException();
            }

        }

        NotNullAttributeType AddNotNullAttribute(ConstructorParameterInfo i)
        {
            if ((i.CheckingFlags & Flags1.PropertyIsNeverNull) != 0)
                return NotNullAttributeType.NotNull;
            if ((i.CheckingFlags & Flags1.NotNull) != 0)
            {
                if (Target.Kind == CsNamespaceMemberKind.Class)
                    if ((i.CheckingFlags & Flags1.AddNotNullAttributeToPropertyIfPossible) != 0)
                        return NotNullAttributeType.NotNull;

                if ((i.CheckingFlags & Flags1.PropertyCanBeNull) != 0)
                    return NotNullAttributeType.CanBeNull;
            }

            return NotNullAttributeType.None;
        }
    }
        

    protected CsProperty Add_Property(string name, CsType type, string description)
    {
        return Target.AddProperty(name, type)
            .WithDescription(description)
            .WithNoEmitField()
            .WithMakeAutoImplementIfPossible()
            .WithIsPropertyReadOnly();
    }

    protected void Add_ToString(string expression)
    {
        Target.AddMethod("ToString", CsType.String, "Returns unit name")
            .WithOverride()
            .WithBody("return " + expression + ";");
    }


    protected void AddCommon_EqualityOperators()
    {
        for (var i = 0; i < 2; i++)
        {
            var eq = i == 0;
            var m = Target.AddMethod(eq ? "==" : "!=", CsType.Bool, eq ? "Equality operator" : "Inequality operator")
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

public enum NotNullAttributeType
{
    None,
    CanBeNull,
    NotNull
}
