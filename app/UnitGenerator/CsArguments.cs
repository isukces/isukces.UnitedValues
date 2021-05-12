using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using UnitGenerator.Local;

namespace UnitGenerator
{
    public class CsArguments
    {
        public CsArguments(params string[] arguments)
        {
            Arguments = arguments;
        }
        
        public static CsArguments Make<T>(IEnumerable<T> arguments, Func<T,string> map)
        {
            return new CsArguments(arguments.Select(map).ToArray());
        }

        public CsArguments(IEnumerable<string> args)
        {
            Arguments = args.ToArray();
        }

        public string CallMethod(string methodName)
        {
            return $"{methodName}({ToString()})";
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

        public void CreateArray(CsCodeWriter c, string prefix)
        {
            c.Open(prefix + "new []");
            var lastIdx = Arguments.Length - 1;
            for (var index = 0; index <= lastIdx; index++)
            {
                var i = Arguments[index];
                if (index < lastIdx)
                    i += ",";
                c.WriteLine(i);
            }

            c.DecIndent();
            c.WriteLine("};");
        }

        public string MakeGenericType(string type, bool trunc = false)
        {
            if (trunc)
                type = type.Split('<')[0];
            return $"{type}<{ToString()}>";
        }
        public string MakeGenericTypeMethodCall(string methodName, params string [] args)
        {
            var call1 = MakeGenericType(methodName);
            var a     = new CsArguments(args);
            return a.CallMethod(call1);
        }

        public CsCodeWriter ReturnArray()
        {
            var c = new CsCodeWriter();
            CreateArray(c, "return ");
            return c;
        }

        public string Throw<T>(ITypeNameResolver resolver)
        {
            var exc = Create(resolver.GetTypeName<T>());
            return $"throw {exc};";
        }

        public override string ToString()
        {
            return string.Join(", ", Arguments);
        }

        public string[] Arguments { get; }
    }
}