using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    internal class Args
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
            return $"new {constructedTypeName}({this})";
        }

        public override string ToString()
        {
            return string.Join(", ", _args);
        }

        private readonly string[] _args;
    }
}