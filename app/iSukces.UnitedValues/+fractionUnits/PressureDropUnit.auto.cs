// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class PressureDropUnit : IFractionalUnit<PressureUnit, LengthUnit>, IEquatable<PressureDropUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of PressureDropUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public PressureDropUnit(PressureUnit counterUnit, LengthUnit denominatorUnit)
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

        public bool Equals(PressureDropUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is PressureDropUnit unitedValue ? Equals(unitedValue) : false;
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

        public PressureDropUnit WithCounterUnit(PressureUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new PressureDropUnit(newUnit, DenominatorUnit);
        }

        public PressureDropUnit WithDenominatorUnit(LengthUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new PressureDropUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(PressureDropUnit left, PressureDropUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(PressureDropUnit left, PressureDropUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// counter unit
        /// </summary>
        public PressureUnit CounterUnit { get; }

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
