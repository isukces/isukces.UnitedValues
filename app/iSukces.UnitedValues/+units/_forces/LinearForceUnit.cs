using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionUnitGenerator
public sealed partial class LinearForceUnit : IFractionalUnit<ForceUnit, LengthUnit>, IEquatable<LinearForceUnit>, IDecomposableUnit
{
    /// <summary>
    /// creates instance of LinearForceUnit
    /// </summary>
    /// <param name="counterUnit">counter unit</param>
    /// <param name="denominatorUnit">denominator unit</param>
    public LinearForceUnit(ForceUnit counterUnit, LengthUnit denominatorUnit)
    {
        CounterUnit = counterUnit;
        DenominatorUnit = denominatorUnit;
    }

    public IReadOnlyList<DecomposableUnitItem> Decompose()
    {
        // generator : FractionUnitGenerator.Add_Decompose
        return new []
        {
            new DecomposableUnitItem(CounterUnit, 1),
            new DecomposableUnitItem(DenominatorUnit, -1)
        };
        /*
        var decomposer = new UnitDecomposer();
        decomposer.Add(CounterUnit, 1);
        decomposer.Add(DenominatorUnit, -1);
        return decomposer.Items;
        */
    }

    public bool Equals(LinearForceUnit? other)
    {
        // generator : FractionUnitGenerator
        return CounterUnit.Equals(other?.CounterUnit) && DenominatorUnit.Equals(other?.DenominatorUnit);
    }

    public override bool Equals(object? other)
    {
        // generator : FractionUnitGenerator
        return other is LinearForceUnit value && Equals(value);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (CounterUnit.GetHashCode() * 397) ^ DenominatorUnit.GetHashCode();
        }
    }

    /// <summary>
    /// Returns unit name
    /// </summary>
    public override string ToString()
    {
        return UnitName;
    }

    public LinearForceUnit WithCounterUnit(ForceUnit newUnit)
    {
        // generator : FractionUnitGenerator.Add_WithSecond
        return new LinearForceUnit(newUnit, DenominatorUnit);
    }

    public LinearForceUnit WithDenominatorUnit(LengthUnit newUnit)
    {
        // generator : FractionUnitGenerator.Add_WithFirst
        return new LinearForceUnit(CounterUnit, newUnit);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(LinearForceUnit left, LinearForceUnit right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(LinearForceUnit left, LinearForceUnit right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// counter unit
    /// </summary>
    public ForceUnit CounterUnit { get; }

    /// <summary>
    /// denominator unit
    /// </summary>
    public LengthUnit DenominatorUnit { get; }

    public string UnitName => CounterUnit.UnitName + "/" + DenominatorUnit.UnitName;

}
