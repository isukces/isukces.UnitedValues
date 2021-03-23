using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace UnitGenerator
{
    public class PrimitiveUnitsCollection
    {
        public PrimitiveUnitsCollection(IReadOnlyList<PrimitiveUnit> items)
        {
            Items = items;
            _dict = items.GroupBy(a => a.UnitTypes.Unit)
                .ToDictionary(a => a.Key, a => a.ToArray());
            DistinctNames = _dict.Keys.ToArray();
        }

        [CanBeNull]
        public PrimitiveUnit GetDeltaByUnit(string unit)
        {
            if (!_dict.TryGetValue(unit, out var item))
                return null;
            return item.FirstOrDefault(a => a.UnitTypes.ValueKind == Kind.Delta);
        }

        public IReadOnlyList<PrimitiveUnit> Items { get; }

        public IReadOnlyList<string> DistinctNames { get; }
        private readonly Dictionary<string, PrimitiveUnit[]> _dict;
    }
}