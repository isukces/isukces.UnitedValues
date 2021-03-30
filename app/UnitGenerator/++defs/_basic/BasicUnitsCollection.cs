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
                .ToDictionary(a => a.Key, a =>
                {
                    var items2 = a.ToArray();
                    return new BasicUnitsCollectionItem(items2);
                });
            DistinctNames = _dict.Keys.ToArray();
        }

        [CanBeNull]
        public BasicUnit GetDeltaByUnit(XUnitTypeName unit)
        {
            if (!_dict.TryGetValue(unit, out var item))
                return null;
            return item.GetDeltaByUnit();
        }

        public IReadOnlyList<BasicUnit> Items { get; }

        public XUnitTypeName[] DistinctNames { get; }
        private readonly Dictionary<XUnitTypeName, BasicUnitsCollectionItem> _dict;
    }

    internal class BasicUnitsCollectionItem
    {
        public BasicUnitsCollectionItem(BasicUnit[] items)
        {
            Items = items;
        }

        public BasicUnit GetDeltaByUnit()
        {
            return Items.FirstOrDefault(a => a.UnitTypes.ValueKind == UnitNameKind.Delta);
        }

        public BasicUnit[] Items { get; }
    }
}