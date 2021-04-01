// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class SpecificHeatCapacityUnit : IFractionalUnit<EnergyMassDensityUnit, KelvinTemperatureUnit>, IEquatable<SpecificHeatCapacityUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of SpecificHeatCapacityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public SpecificHeatCapacityUnit(EnergyMassDensityUnit counterUnit, KelvinTemperatureUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : FractionUnitGenerator.Add_Decompose
            var decomposer = new UnitDecomposer();
            decomposer.Add(CounterUnit, 1);
            decomposer.Add(DenominatorUnit, -1);
            return decomposer.Items;
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

        public SpecificHeatCapacityUnit WithCounterUnit(EnergyMassDensityUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new SpecificHeatCapacityUnit(newUnit, DenominatorUnit);
        }

        public SpecificHeatCapacityUnit WithDenominatorUnit(KelvinTemperatureUnit newUnit)
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
        public EnergyMassDensityUnit CounterUnit { get; }

        /// <summary>
        /// denominator unit
        /// </summary>
        public KelvinTemperatureUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
