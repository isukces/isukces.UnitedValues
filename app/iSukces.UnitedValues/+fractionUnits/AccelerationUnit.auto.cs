// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class AccelerationUnit : IFractionalUnit<LengthUnit, SquareTimeUnit>, IEquatable<AccelerationUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of AccelerationUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public AccelerationUnit(LengthUnit counterUnit, SquareTimeUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : FractionUnitGenerator.Add_Decompose
            var denominatorUnit = DenominatorUnit.GetBasicUnit();
            return new[]
            {
                new DecomposableUnitItem(CounterUnit, 1),
                new DecomposableUnitItem(denominatorUnit.Unit, -denominatorUnit.Power)
            };
            /*
            var decomposer = new UnitDecomposer();
            decomposer.Add(CounterUnit, 1);
            decomposer.Add(DenominatorUnit, -1);
            return decomposer.Items;
            */
        }

        public bool Equals(AccelerationUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is AccelerationUnit unitedValue ? Equals(unitedValue) : false;
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

        public AccelerationUnit WithCounterUnit(LengthUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new AccelerationUnit(newUnit, DenominatorUnit);
        }

        public AccelerationUnit WithDenominatorUnit(SquareTimeUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new AccelerationUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(AccelerationUnit left, AccelerationUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(AccelerationUnit left, AccelerationUnit right)
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
        public SquareTimeUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
