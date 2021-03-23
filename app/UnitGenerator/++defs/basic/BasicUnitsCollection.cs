using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class PrimitiveUnitsCollection
    {
        public PrimitiveUnitsCollection(IReadOnlyList<PrimitiveUnit> items)
        {
            Items         = items;
            DistinctNames = items.Select(a => a.UnitTypeName).Distinct().ToArray();
        }

        public IReadOnlyList<PrimitiveUnit> Items { get; }

        public IReadOnlyList<string> DistinctNames { get; }
    }
}