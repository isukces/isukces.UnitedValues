using System;

namespace isukces.UnitedValues
{
    public interface IUnitedValue<TUnit>
        : IEquatable<IUnitedValue<TUnit>>
        where TUnit : IUnit, IEquatable<TUnit>
    {
        decimal GetBaseUnitValue();
        decimal Value { get; }
        TUnit Unit { get; }
    }

    public interface IUnitNameContainer
    {
        string UnitName { get; }
    }

    public interface IUnit : IUnitNameContainer
    {
    }

    public interface IUnitDefinition : IUnitNameContainer
    {
        decimal Multiplication { get; }
    }
}