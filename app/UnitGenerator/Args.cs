using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using UnitGenerator.Local;

namespace UnitGenerator
{
    public class Args
    {
        public Args(params string[] arguments)
        {
            Arguments = arguments;
        }

        public Args(IEnumerable<string> args)
        {
            Arguments = args.ToArray();
        }

        public string Create(string constructedTypeName)
        {
            return $"new {constructedTypeName}({ToString()})";
        }
        
        public string Create(ITypeNameProvider constructedTypeName)
        {
            return Create(constructedTypeName.GetTypename());
        }
        
        public string Create<T>()
        {
            return Create(typeof(T).Name);
        }
        
        public string Create<T>(ITypeNameResolver resolver)
        {
            return Create(resolver.GetTypeName<T>());
        }
        
        public string Throw<T>(ITypeNameResolver resolver)
        {
            var exc = Create(resolver.GetTypeName<T>());
            return $"throw {exc};";
        }
        
        public string CallMethod(string methodName)
        {
            return $"{methodName}({ToString()})";
        }

        public string MakeGenericType(string type, bool trunc =false)
        {
            if (trunc)
                type = type.Split('<')[0];
            return $"{type}<{ToString()}>";
        }

        public override string ToString()
        {
            return string.Join(", ", Arguments);
        }

        public string[] Arguments { get; }

        public CsCodeWriter ReturnArray()
        {
            var c = new CsCodeWriter();
            c.Open("return new[]");
            var lastIdx = Arguments.Length-1;
            for (var index = 0; index <= lastIdx; index++)
            {
                var i = Arguments[index];
                if (index < lastIdx)
                    i += ",";
                c.WriteLine(i);
            }

            c.DecIndent();
            c.WriteLine("};");
            return c;
        }
    }
}