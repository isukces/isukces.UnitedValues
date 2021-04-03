// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class VelocityUnit : IFractionalUnit<LengthUnit, TimeUnit>, IEquatable<VelocityUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of VelocityUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public VelocityUnit(LengthUnit counterUnit, TimeUnit denominatorUnit)
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

        public bool Equals(VelocityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is VelocityUnit unitedValue ? Equals(unitedValue) : false;
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

        public VelocityUnit WithCounterUnit(LengthUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new VelocityUnit(newUnit, DenominatorUnit);
        }

        public VelocityUnit WithDenominatorUnit(TimeUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new VelocityUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(VelocityUnit left, VelocityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(VelocityUnit left, VelocityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// counter unit
        /// </summary>
        public LengthUnit CounterUnit { get; }

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
