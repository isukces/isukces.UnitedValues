using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator;

public class ProductUnitsCollection
{
    public ProductUnitsCollection(IReadOnlyList<ProductUnit> items)
    {
        Items = items;
        _d    = items.ToDictionary(a => a.UnitTypes.Value, a => a);
    }

    public ProductUnit? ByValueTypeName(XValueTypeName valueTypeName)
    {
        _d.TryGetValue(valueTypeName, out var tmp);
        return tmp;
    }

    public           IReadOnlyList<ProductUnit>              Items { get; }
    private readonly Dictionary<XValueTypeName, ProductUnit> _d;
}
