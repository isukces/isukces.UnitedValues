using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class Args
    {
        public Args(params string[] args)
        {
            _args = args;
        }

        public Args(IEnumerable<string> args)
        {
            _args = args.ToArray();
        }

        public string Create(string constructedTypeName)
        {
            return $"new {constructedTypeName}({ToString()})";
        }
        
        public string Create<T>()
        {
            return Create(typeof(T).Name);
        }
        
        public string CallMethod(string methodName)
        {
            return $"{methodName}({ToString()})";
        }

        public string MakeGenericType(string type)
        {
            return $"{type}<{ToString()}>";
        }

        public override string ToString()
        {
            return string.Join(", ", _args);
        }

        private readonly string[] _args;
    }
}