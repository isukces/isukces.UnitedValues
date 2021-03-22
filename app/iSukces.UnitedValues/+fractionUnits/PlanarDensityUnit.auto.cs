// ReSharper disable All
// generator: FractionUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct PlanarDensityUnit : IFractionalUnit<WeightUnit, AreaUnit>, IEquatable<PlanarDensityUnit>
    {
        /// <summary>
        /// creates instance of PlanarDensityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public PlanarDensityUnit(WeightUnit counterUnit, AreaUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public bool Equals(PlanarDensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is PlanarDensityUnit unitedValue ? Equals(unitedValue) : false;
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

        public PlanarDensityUnit WithCounterUnit(WeightUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithCounterUnit
            return new PlanarDensityUnit(newUnit, DenominatorUnit);
        }

        public PlanarDensityUnit WithDenominatorUnit(AreaUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithDenominatorUnit
            return new PlanarDensityUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(PlanarDensityUnit left, PlanarDensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(PlanarDensityUnit left, PlanarDensityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// counter unit
        /// </summary>
        public WeightUnit CounterUnit { get; }

        /// <summary>
        /// denominator unit
        /// </summary>
        public AreaUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
