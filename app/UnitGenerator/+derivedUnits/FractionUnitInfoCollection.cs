using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class FractionUnitInfoCollection
    {
        private Dictionary<string, FractionUnitInfo> _d;

        public FractionUnitInfoCollection(IReadOnlyList<FractionUnitInfo> items)
        {
            Items = items;
            _d    = items.ToDictionary(a => a.ValueTypeName, a => a);
        }

        public FractionUnitInfo ByValueTypeName(string valueTypeName)
        {
            _d.TryGetValue(valueTypeName, out var tmp);
            return tmp;
        }

        public IReadOnlyList<FractionUnitInfo> Items { get; }
    }
}