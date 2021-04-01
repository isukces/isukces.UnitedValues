// ReSharper disable All
// generator: InversedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial class InversedKelvinTemperatureUnit : IUnit, IEquatable<InversedKelvinTemperatureUnit>, IDerivedDecomposableUnit
    {
        /// <summary>
        /// creates instance of InversedKelvinTemperatureUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public InversedKelvinTemperatureUnit(string unitName)
        {
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName.TrimToNull();
        }

        /// <summary>
        /// creates instance of InversedKelvinTemperatureUnit
        /// </summary>
        /// <param name="baseUnit">base unit</param>
        /// <param name="unitName">name of unit</param>
        public InversedKelvinTemperatureUnit(KelvinTemperatureUnit baseUnit, string unitName = null)
        {
            if (baseUnit is null)
                throw new NullReferenceException(nameof(baseUnit));
            BaseUnit = baseUnit;
            unitName = unitName?.Trim();
            UnitName = string.IsNullOrEmpty(unitName) ? "1/" + baseUnit.UnitName : unitName;
        }

        public bool Equals(InversedKelvinTemperatureUnit other)
        {
            return UnitName.Equals(other.UnitName);
        }

        public override bool Equals(object other)
        {
            return other is InversedKelvinTemperatureUnit unitedValue ? Equals(unitedValue) : false;
        }

        public DecomposableUnitItem GetBasicUnit()
        {
            // generator : InversedUnitGenerator.Add_Decompose
            var tmp = GetKelvinTemperatureUnit();
            return new DecomposableUnitItem(tmp, -1);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return UnitName.GetHashCode();
            }
        }

        public KelvinTemperatureUnit GetKelvinTemperatureUnit()
        {
            // generator : InversedUnitGenerator.AddGetBaseUnit
            if (!(BaseUnit is null))
                return BaseUnit;
            // poor quality code :(, but should work for simple cases like 1/K
            if (UnitName.StartsWith("1/"))
                return new KelvinTemperatureUnit(UnitName.Substring(2));
            throw new NotImplementedException("Not implemented yet");
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(InversedKelvinTemperatureUnit left, InversedKelvinTemperatureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(InversedKelvinTemperatureUnit left, InversedKelvinTemperatureUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        [NotNull]
        public string UnitName { get; }

        /// <summary>
        /// base unit
        /// </summary>
        [CanBeNull]
        public KelvinTemperatureUnit BaseUnit { get; }

    }
}
