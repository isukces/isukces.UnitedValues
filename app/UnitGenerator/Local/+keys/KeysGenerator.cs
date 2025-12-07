using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;

namespace UnitGenerator.Local;

public class KeysGenerator : IAssemblyAutoCodeGenerator
{
    private static void AddGetHashCodeMethod(CsClass cl, KeysGeneratorDef def)
    {
        var m = cl.AddMethod(nameof(GetHashCode), CsType.Int32);
        m.Overriding = OverridingType.Override;

        switch (def.WrappedType)
        {
            case WrappedTypes.String:
                m.WithBodyAsExpression($"{def.ValuePropertyName}.GetHashCode()");
                break;
            case WrappedTypes.Int:
                m.WithBodyAsExpression(def.ValuePropertyName);
                break;
            default:
                throw new NotImplementedException();
                  
        }
    }

    private static void AddToStringMethod(CsClass cl, KeysGeneratorDef def)
    {
        var m = cl.AddMethod(nameof(ToString), CsType.String);
        m.Overriding = OverridingType.Override;
        var e = def.GetToStringExpression();
        m.WithBodyAsExpression(e);
    }

    private static string ValueEquals(string other, KeysGeneratorDef def)
    {
        return $"{def.ValuePropertyName}.Equals({other})";
    }

    public void Add(KeysGeneratorDef def)
    {
        Defs.Add(def);
    }

    public void AssemblyEnd(Assembly assembly, IAutoCodeGeneratorContext context)
    {
    }

    public void AssemblyStart(Assembly assembly, IAutoCodeGeneratorContext context)
    {
        foreach (var def in Defs.Where(a => a.TargetAssembly == assembly))
        {
            var ns       = context.GetOrCreateNamespace(assembly.GetName().Name);
            var csStruct = ns.GetOrCreateClass(def.TypeName);
            GeneratorCommon.Setup(csStruct);
            csStruct.Description = def.TypeDescription;

            csStruct.AddProperty(def.ValuePropertyName, def.CsWrappedType)
                .WithMakeAutoImplementIfPossible()
                .WithIsPropertyReadOnly()
                .WithNoEmitField();

            AddConstructor(csStruct, def);
            AddEqualsMethods(csStruct, def);
            AddGetHashCodeMethod(csStruct, def);
            AddToStringMethod(csStruct, def);

            if (def.WrappedType == WrappedTypes.Int)
                csStruct.ImplementedInterfaces.Add(csStruct.GetTypeName<IIntegerBasedKey>());
        }
    }

    private static void AddConstructor(CsClass csStruct, KeysGeneratorDef def)
    {
        var propName = def.ValuePropertyName;
        var argName  = propName.FirstLower();
        var cs       = new CsCodeWriter();
        if (def.WrappedType == WrappedTypes.String)
        {
            var throwCode = Utils.ThrowNullReferenceException(argName, csStruct);
            cs.SingleLineIf($"{argName} is null", throwCode);

            throwCode = Utils.ThrowArgumentException(argName, csStruct);
            cs.SingleLineIf($"{argName}.Length == 0", throwCode);
                
            cs.WriteAssign(propName, $"{argName}.Trim()");
        }
        else
            cs.WriteAssign(propName,  argName );

        csStruct.AddConstructor()
            .WithParameter(new CsMethodParameter(argName, def.CsWrappedType))
            .WithBody(cs);
            
            
        for (var i = 0; i < 2; i++)
        {
            var eq   = i == 0;
            var expresion = $"{(eq ? "" : "!")}left.Equals(right)";
            var m = csStruct.AddMethod(eq ? "==" : "!=", CsType.Bool, eq ? "Equality operator" : "Inequality operator")
                .WithBodyAsExpression(expresion);

            m.AddParam("left", csStruct.Name, "first value to compare");
            m.AddParam("right", csStruct.Name, "second value to compare");
        }
    }

    private void AddEqualsMethods(CsClass cl, KeysGeneratorDef def)
    {
        var typeName = (CsType)def.TypeName;
        var propName = def.ValuePropertyName;
        {
            var m = cl.AddMethod(nameof(Equals), CsType.Bool);
            m.Parameters.Add(new CsMethodParameter("other", typeName.WithReferenceNullable()));
            m.WithBodyAsExpression(ValueEquals($"other.{propName}", def));
        }
        {
            var expression = def.WrappedType == WrappedTypes.String 
                ? $"obj is {typeName.Declaration} s && StringComparer.Ordinal.Equals({propName}, s.{propName})" : $"obj is {typeName.Declaration} s && {propName}.Equals(s.{propName})";
            var m = cl.AddMethod(nameof(Equals), CsType.Bool)
                .WithBodyAsExpression(expression);
            m.Overriding = OverridingType.Override;
            m.Parameters.Add(new CsMethodParameter("obj", CsType.ObjectNullable));
            
        }
    }

    public List<KeysGeneratorDef> Defs { get; } = new();
}
