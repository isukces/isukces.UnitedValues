using System.Collections.Generic;

namespace UnitGenerator;

public class ThermaUnitsCollection
{
    public ThermaUnitsCollection(IReadOnlyList<ThermalUnit> items)
    {
        Items = items;
            
    }
    public IReadOnlyList<ThermalUnit> Items { get; }
}