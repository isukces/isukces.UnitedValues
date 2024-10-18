using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues;

public struct UnitDefinition<TUnit>: IUnitDefinition
    where TUnit : IUnit
{
    public UnitDefinition(TUnit unit, decimal multiplication, params string[] aliases)
    {
        UnitName       = unit.UnitName;
        Unit           = unit;
        Multiplication = multiplication;
        Aliases        = aliases ?? [];
    }

    public string   UnitName       { get; }
    public TUnit    Unit           { get; }
    public decimal  Multiplication { get; }
    public string[] Aliases        { get; }
}

public class UnitEqualityComparer<TUnit> : IEqualityComparer<TUnit>
    where TUnit : IUnit
{
    public bool Equals(TUnit x, TUnit y)
    {
        return string.Equals(x?.UnitName, y?.UnitName, StringComparison.Ordinal);
    }

    public int GetHashCode(TUnit obj)
    {
        return string.IsNullOrEmpty(obj?.UnitName)
            ? 0
            : obj.UnitName.GetHashCode();
    }
}