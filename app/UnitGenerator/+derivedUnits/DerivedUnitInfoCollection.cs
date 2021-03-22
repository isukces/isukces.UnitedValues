using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class DerivedUnitInfoCollection
    {
        public DerivedUnitInfoCollection(IReadOnlyList<DerivedUnitInfo> items)
        {
            Items       = items;
            _dictionary = items.ToDictionary(a => a.Name, a => a);
        }


        public DerivedUnitInfo ByName(string name)
        {
            if (_dictionary.TryGetValue(name, out var x))
                return x;
            return null;
        }

        public IReadOnlyList<DerivedUnitInfo> Items { get; }
        private readonly Dictionary<string, DerivedUnitInfo> _dictionary;
    }
}