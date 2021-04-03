// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class VolumeStreamUnit : IFractionalUnit<VolumeUnit, TimeUnit>, IEquatable<VolumeStreamUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of VolumeStreamUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public VolumeStreamUnit(VolumeUnit counterUnit, TimeUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : FractionUnitGenerator.Add_Decompose
            var counterUnit = CounterUnit.GetBasicUnit();
            return new []
            {
                new DecomposableUnitItem(counterUnit.Unit, counterUnit.Power),
                new DecomposableUnitItem(DenominatorUnit, -1)
            };
            /*
            var decomposer = new UnitDecomposer();
            decomposer.Add(CounterUnit, 1);
            decomposer.Add(DenominatorUnit, -1);
            return decomposer.Items;
            */
        }

        public bool Equals(VolumeStreamUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is VolumeStreamUnit unitedValue ? Equals(unitedValue) : false;
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

        public VolumeStreamUnit WithCounterUnit(VolumeUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new VolumeStreamUnit(newUnit, DenominatorUnit);
        }

        public VolumeStreamUnit WithDenominatorUnit(TimeUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new VolumeStreamUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(VolumeStreamUnit left, VolumeStreamUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(VolumeStreamUnit left, VolumeStreamUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// counter unit
        /// </summary>
        public VolumeUnit CounterUnit { get; }

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
