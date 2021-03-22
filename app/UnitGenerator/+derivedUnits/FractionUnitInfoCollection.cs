using System.Collections.Generic;

namespace UnitGenerator
{
    public class FractionUnitInfoCollection
    {
        public FractionUnitInfoCollection(IReadOnlyList<FractionUnitInfo> items)
        {
            Items = items;
        }

        public IReadOnlyList<FractionUnitInfo> Items { get; }
    }
}