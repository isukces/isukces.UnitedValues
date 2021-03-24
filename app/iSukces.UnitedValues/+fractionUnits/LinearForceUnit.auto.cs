// ReSharper disable All
// generator: FractionUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct LinearForceUnit : IFractionalUnit<ForceUnit, LengthUnit>, IEquatable<LinearForceUnit>
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

        public bool Equals(LinearForceUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is LinearForceUnit unitedValue ? Equals(unitedValue) : false;
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

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
