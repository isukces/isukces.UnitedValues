// ReSharper disable All
// generator: FractionUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct DensityUnit : IFractionalUnit<WeightUnit, VolumeUnit>, IEquatable<DensityUnit>
    {
        /// <summary>
        /// creates instance of DensityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public DensityUnit(WeightUnit counterUnit, VolumeUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public bool Equals(DensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is DensityUnit unitedValue ? Equals(unitedValue) : false;
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

        public DensityUnit WithCounterUnit(WeightUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithCounterUnit
            return new DensityUnit(newUnit, DenominatorUnit);
        }

        public DensityUnit WithDenominatorUnit(VolumeUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithDenominatorUnit
            return new DensityUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(DensityUnit left, DensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(DensityUnit left, DensityUnit right)
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
        public VolumeUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
