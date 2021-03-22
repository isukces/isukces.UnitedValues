using System;

namespace iSukces.UnitedValues
{
    public interface IUnitedValue<TUnit>
        : IEquatable<IUnitedValue<TUnit>>
        where TUnit : IUnit, IEquatable<TUnit>
    {
        decimal GetBaseUnitValue();
        decimal Value { get; }
        TUnit   Unit  { get; }
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

    public interface IFractionalUnit : IUnit
    {
    }

    public interface IFractionalUnit<out TCounter, out TDenominator> : IUnit
    {
        /// <summary>
        ///     counter unit
        /// </summary>
        TCounter CounterUnit { get; }

        /// <summary>
        ///     denominator unit
        /// </summary>
        TDenominator DenominatorUnit { get; }
    }
}