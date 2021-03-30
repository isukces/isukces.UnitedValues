// ReSharper disable All
// generator: FractionUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class LinearDensityUnit : IFractionalUnit<MassUnit, LengthUnit>, IEquatable<LinearDensityUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of LinearDensityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public LinearDensityUnit(MassUnit counterUnit, LengthUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public System.Collections.Generic.IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : FractionUnitGenerator.AddDecompose
            var decomposer = new UnitDecomposer();
            decomposer.Add(CounterUnit, 1);
            decomposer.Add(DenominatorUnit, -1);
            return decomposer.Items;
        }

        public bool Equals(LinearDensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is LinearDensityUnit unitedValue ? Equals(unitedValue) : false;
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

        public LinearDensityUnit WithCounterUnit(MassUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new LinearDensityUnit(newUnit, DenominatorUnit);
        }

        public LinearDensityUnit WithDenominatorUnit(LengthUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new LinearDensityUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(LinearDensityUnit left, LinearDensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(LinearDensityUnit left, LinearDensityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// counter unit
        /// </summary>
        public MassUnit CounterUnit { get; }

        /// <summary>
        /// denominator unit
        /// </summary>
        public LengthUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
