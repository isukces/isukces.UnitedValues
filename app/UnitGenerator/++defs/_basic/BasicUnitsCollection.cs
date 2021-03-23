using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace UnitGenerator
{
    public class BasicUnitsCollection
    {
        public BasicUnitsCollection(IReadOnlyList<BasicUnit> items)
        {
            Items = items;
            _dict = items.GroupBy(a => a.UnitTypes.Unit)
                .ToDictionary(a => a.Key, a => a.ToArray());
            DistinctNames = _dict.Keys.ToArray();
        }

        [CanBeNull]
        public BasicUnit GetDeltaByUnit(string unit)
        {
            if (!_dict.TryGetValue(unit, out var item))
                return null;
            return item.FirstOrDefault(a => a.UnitTypes.ValueKind == Kind.Delta);
        }

        public IReadOnlyList<BasicUnit> Items { get; }

        public IReadOnlyList<string> DistinctNames { get; }
        private readonly Dictionary<string, BasicUnit[]> _dict;
    }
}