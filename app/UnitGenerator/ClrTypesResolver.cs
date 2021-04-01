using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitGenerator
{
    public class ClrTypesResolver
    {
        public ClrTypesResolver(Assembly assembly)
        {
            _assembly = assembly;
        }

        public bool TryGetValue(string name, out Type o)
        {
            return Types.TryGetValue(name, out o);
        }

        public IReadOnlyDictionary<string, Type> Types
        {
            get
            {
                if (_types is null)
                {
                    var types = _assembly.GetExportedTypes();
                    _types = types.ToDictionary(a => a.Name, a => a);
                }

                return _types;
            }
        }

        private IReadOnlyDictionary<string, Type> _types;

        private readonly Assembly _assembly;
    }
}