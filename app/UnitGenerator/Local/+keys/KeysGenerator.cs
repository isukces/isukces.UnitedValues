using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;

namespace UnitGenerator.Local
{
    public class KeysGenerator : IAssemblyAutoCodeGenerator
    {
        private static void AddGetHashCodeMethod(CsClass cl, KeysGeneratorDef def)
        {
            var m = cl.AddMethod(nameof(GetHashCode), "int");
            m.Overriding = OverridingType.Override;

            switch (def.WrappedType)
            {
                case WrappedTypes.String:
                    // m.Body = "return Value is null ? 0 : StringComparer.Ordinal.GetHashCode(Value);";
                    m.Body = $"return {def.ValuePropertyName}.GetHashCode();";
                    break;
                case WrappedTypes.Int:
                    m.Body = $"return {def.ValuePropertyName};";
                    break;
                default:
                    throw new NotImplementedException();
                  
            }
        }

        private static void AddToStringMethod(CsClass cl, KeysGeneratorDef def)
        {
            var m = cl.AddMethod(nameof(ToString), "string");
            m.Overriding = OverridingType.Override;
            var e = def.GetToStringExpression();
            m.Body = $"return {e};";
        }

        private static string ValueEquals(string other, KeysGeneratorDef def)
        {
            return $"return {def.ValuePropertyName}.Equals({other});";
            /*if (compareByEqual)
                return $"return Value.Equals({other});";
            return $"return Value == {other};";*/
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
                csStruct.Description = def.TypeDescription;
                csStruct.IsPartial   = true;
                // csStruct.Kind        = CsNamespaceMemberKind.Struct;

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
            var argName = propName.FirstLower();
            var cs     = new CsCodeWriter();
            if (def.WrappedType == WrappedTypes.String)
            {
                var args      = new CsArguments($"nameof({argName})");
                var exception = args.Create(csStruct.GetTypeName<NullReferenceException>());
                cs.SingleLineIf($"{argName} is null", $"throw {exception};");

                exception = args.Create(csStruct.GetTypeName<ArgumentException>());
                cs.SingleLineIf($"{argName}.Length == 0", $"throw {exception};");
                
                cs.WriteAssign(propName, $"{argName}.Trim()");
            }
            else
                cs.WriteAssign(propName,  argName );

            csStruct.AddConstructor()
                .WithParameter(new CsMethodParameter(argName, def.CsWrappedType))
                .WithBody(cs);
            
            
            for (var i = 0; i < 2; i++)
            {
                var eq = i == 0;
                var m = csStruct.AddMethod(eq ? "==" : "!=", "bool", eq ? "Equality operator" : "Inequality operator")
                    .WithBody($"return {(eq ? "" : "!")}left.Equals(right);");

                m.AddParam("left", csStruct.Name, "first value to compare");
                m.AddParam("right", csStruct.Name, "second value to compare");
            }
        }

        private void AddEqualsMethods(CsClass cl, KeysGeneratorDef def)
        {
            var typeName             = def.TypeName;
            var propName = def.ValuePropertyName;
            {
                var m = cl.AddMethod(nameof(Equals), "bool");
                m.Parameters.Add(new CsMethodParameter("other", typeName));
                m.Body = ValueEquals($"other.{propName}", def);
            }
            {
                var m = cl.AddMethod(nameof(Equals), "bool");
                m.Overriding = OverridingType.Override;
                m.Parameters.Add(new CsMethodParameter("obj", "object"));
                if (def.WrappedType == WrappedTypes.String)
                    m.Body = $"return obj is {typeName} s && StringComparer.Ordinal.Equals({propName}, s.{propName});";
                else
                    m.Body = $"return obj is {typeName} s && {propName}.Equals(s.{propName});";
            }
        }

        public List<KeysGeneratorDef> Defs { get; } = new List<KeysGeneratorDef>();
    }
}