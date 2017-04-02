using System;

namespace isukces.UnitedValues
{
    public interface IUnitedValue<TUnit>
        : IEquatable<IUnitedValue<TUnit>>
        where TUnit : IUnit, IEquatable<TUnit>
    {
        decimal Value { get; }
        TUnit Unit { get; }

        decimal GetBaseUnitValue();
    }

    public interface IUnit
    {
        string UnitName { get; }
    }

   
}