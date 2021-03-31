// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class EnergyMassDensityUnit : IFractionalUnit<EnergyUnit, MassUnit>, IEquatable<EnergyMassDensityUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of EnergyMassDensityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public EnergyMassDensityUnit(EnergyUnit counterUnit, MassUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : FractionUnitGenerator.Add_Decompose
            return new[]
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

        public bool Equals(EnergyMassDensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is EnergyMassDensityUnit unitedValue ? Equals(unitedValue) : false;
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

        public EnergyMassDensityUnit WithCounterUnit(EnergyUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new EnergyMassDensityUnit(newUnit, DenominatorUnit);
        }

        public EnergyMassDensityUnit WithDenominatorUnit(MassUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new EnergyMassDensityUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(EnergyMassDensityUnit left, EnergyMassDensityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(EnergyMassDensityUnit left, EnergyMassDensityUnit right)
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
        public MassUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
