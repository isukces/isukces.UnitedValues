using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class DerivedUnitCollection
    {
        public DerivedUnitCollection(IReadOnlyList<DerivedUnit> items)
        {
            Items       = items;
            _dictionary = items.ToDictionary(a => a.Name, a => a);
        }


        public DerivedUnit ByName(string name)
        {
            if (_dictionary.TryGetValue(name, out var x))
                return x;
            return null;
        }

        public IReadOnlyList<DerivedUnit> Items { get; }
        private readonly Dictionary<string, DerivedUnit> _dictionary;
    }
}