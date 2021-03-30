using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class FractionUnitsCollection
    {
        public FractionUnitsCollection(IReadOnlyList<FractionUnit> items)
        {
            Items = items;
            _d    = items.ToDictionary(a => a.UnitTypes.Value, a => a);
        }

        public FractionUnit ByValueTypeName(XValueTypeName valueTypeName)
        {
            _d.TryGetValue(valueTypeName, out var tmp);
            return tmp;
        }

        public IReadOnlyList<FractionUnit> Items { get; }
        private readonly Dictionary<XValueTypeName, FractionUnit> _d;
    }
}