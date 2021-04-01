// ReSharper disable All
// generator: ProductUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class MassDetlaKelvinUnit : IProductUnit<MassUnit, KelvinTemperatureUnit>, IEquatable<MassDetlaKelvinUnit>, IDecomposableUnit
    {
        /// <summary>
        /// creates instance of MassDetlaKelvinUnit
        /// </summary>
        /// <param name="leftUnit">left unit</param>
        /// <param name="rightUnit">right unit</param>
        public MassDetlaKelvinUnit(MassUnit leftUnit, KelvinTemperatureUnit rightUnit)
        {
            LeftUnit = leftUnit;
            RightUnit = rightUnit;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : ProductUnitGenerator.Add_Decompose
            return new []
            {
                new DecomposableUnitItem(LeftUnit, 1),
                new DecomposableUnitItem(RightUnit, 1)
            };
            /*
            var decomposer = new UnitDecomposer();
            decomposer.Add(LeftUnit, 1);
            decomposer.Add(RightUnit, 1);
            return decomposer.Items;
            */
        }

        public bool Equals(MassDetlaKelvinUnit other)
        {
            return LeftUnit.Equals(other.LeftUnit) && RightUnit.Equals(other.RightUnit);
        }

        public override bool Equals(object other)
        {
            return other is MassDetlaKelvinUnit unitedValue ? Equals(unitedValue) : false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (LeftUnit.GetHashCode() * 397) ^ RightUnit.GetHashCode();
            }
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        public MassDetlaKelvinUnit WithLeftUnit(MassUnit newUnit)
        {
            // generator : ProductUnitGenerator.Add_WithSecond
            return new MassDetlaKelvinUnit(newUnit, RightUnit);
        }

        public MassDetlaKelvinUnit WithRightUnit(KelvinTemperatureUnit newUnit)
        {
            // generator : ProductUnitGenerator.Add_WithFirst
            return new MassDetlaKelvinUnit(LeftUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(MassDetlaKelvinUnit left, MassDetlaKelvinUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(MassDetlaKelvinUnit left, MassDetlaKelvinUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// left unit
        /// </summary>
        public MassUnit LeftUnit { get; }

        /// <summary>
        /// right unit
        /// </summary>
        public KelvinTemperatureUnit RightUnit { get; }

        public string UnitName
        {
            get { return LeftUnit.UnitName + RightUnit.UnitName; }
        }

    }
}
