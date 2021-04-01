// ReSharper disable All
// generator: FractionUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class PressureUnit : IFractionalUnit<ForceUnit, AreaUnit>, IEquatable<PressureUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of PressureUnit
        /// </summary>
        /// <param name="counterUnit">counter unit</param>
        /// <param name="denominatorUnit">denominator unit</param>
        public PressureUnit(ForceUnit counterUnit, AreaUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : FractionUnitGenerator.Add_Decompose
            var denominatorUnit = DenominatorUnit.GetBasicUnit();
            return new []
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

        public bool Equals(PressureUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object other)
        {
            return other is PressureUnit unitedValue ? Equals(unitedValue) : false;
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

        public PressureUnit WithCounterUnit(ForceUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithSecond
            return new PressureUnit(newUnit, DenominatorUnit);
        }

        public PressureUnit WithDenominatorUnit(AreaUnit newUnit)
        {
            // generator : FractionUnitGenerator.Add_WithFirst
            return new PressureUnit(CounterUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(PressureUnit left, PressureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(PressureUnit left, PressureUnit right)
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
        public AreaUnit DenominatorUnit { get; }

        public string UnitName
        {
            get { return CounterUnit.UnitName + "/" + DenominatorUnit.UnitName; }
        }

    }
}
