using System.Collections.Generic;

namespace UnitGenerator;

public class InversedUnitsCollection
{
    public InversedUnitsCollection(IReadOnlyList<InversedUnit> items)
    {
        Items = items;
        // _d    = items.ToDictionary(a => a.UnitTypes.Value, a => a);
    }

    /*
    public InversedUnit ByValueTypeName(XValueTypeName valueTypeName)
    {
        _d.TryGetValue(valueTypeName, out var tmp);
        return tmp;
    }
    */

    public IReadOnlyList<InversedUnit> Items { get; }
    // private readonly Dictionary<XValueTypeName, InversedUnit> _d;
}
