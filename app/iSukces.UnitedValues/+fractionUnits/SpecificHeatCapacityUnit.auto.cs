// ReSharper disable All
// generator: FractionUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct SpecificHeatCapacityUnit : IFractionalUnit<EnergyUnit, MassDetlaKelvinUnit>, IEquatable<SpecificHeatCapacityUnit>
    {
        /// <summary>
        /// creates instance of SpecificHeatCapacityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public SpecificHeatCapacityUnit(EnergyUnit counterUnit, MassDetlaKelvinUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public bool Equals(SpecificHeatCapacityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is SpecificHeatCapacityUnit unitedValue ? Equals(unitedValue) : false;
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

        public SpecificHeatCapacityUnit WithCounterUnit(EnergyUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new SpecificHeatCapacityUnit(newUnit, DenominatorUnit);
        }

        public SpecificHeatCapacityUnit WithDenominatorUnit(MassDetlaKelvinUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new SpecificHeatCapacityUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(SpecificHeatCapacityUnit left, SpecificHeatCapacityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(SpecificHeatCapacityUnit left, SpecificHeatCapacityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// counter unit
        /// </summary>
        public EnergyUnit CounterUnit { get; }

        /// <summary>
        /// denominator unit
        /// </summary>
        public MassDetlaKelvinUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}