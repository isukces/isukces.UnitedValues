// ReSharper disable All

using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct PlaneDensityUnit : IUnit, IEquatable<PlaneDensityUnit>
    {
        /// <summary>
        ///     creates instance of PlaneDensityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public PlaneDensityUnit(MassUnit counterUnit, AreaUnit denominatorUnit)
        {
            CounterUnit     = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        /// <summary>
        ///     Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(PlaneDensityUnit left, PlaneDensityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(PlaneDensityUnit left, PlaneDensityUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(PlaneDensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is PlaneDensityUnit unitedValue ? Equals(unitedValue) : false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CounterUnit.GetHashCode() * 397) ^ DenominatorUnit.GetHashCode();
            }
        }

        /// <summary>
        ///     Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        /// <summary>
        ///     counter unit
        /// </summary>
        public MassUnit CounterUnit { get; }

        /// <summary>
        ///     denominator unit
        /// </summary>
        public AreaUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }
    }
}