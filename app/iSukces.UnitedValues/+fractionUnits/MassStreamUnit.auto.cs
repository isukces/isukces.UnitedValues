// ReSharper disable All
// generator: FractionUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct MassStreamUnit : IFractionalUnit<WeightUnit, TimeUnit>, IEquatable<MassStreamUnit>
    {
        /// <summary>
        /// creates instance of MassStreamUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public MassStreamUnit(WeightUnit counterUnit, TimeUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public bool Equals(MassStreamUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is MassStreamUnit unitedValue ? Equals(unitedValue) : false;
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

        public MassStreamUnit WithCounterUnit(WeightUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new MassStreamUnit(newUnit, DenominatorUnit);
        }

        public MassStreamUnit WithDenominatorUnit(TimeUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new MassStreamUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(MassStreamUnit left, MassStreamUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(MassStreamUnit left, MassStreamUnit right)
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
        public TimeUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
