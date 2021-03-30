// ReSharper disable All
// generator: UnitGenerator
using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial class CelsiusTemperatureUnit : IUnit, IEquatable<CelsiusTemperatureUnit>
    {
        /// <summary>
        /// creates instance of CelsiusTemperatureUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public CelsiusTemperatureUnit([JetBrains.Annotations.NotNull] string unitName)
        {
            unitName = unitName?.Trim();
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            if (string.IsNullOrWhiteSpace(unitName))
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName.TrimToNull();
        }

        public bool Equals(CelsiusTemperatureUnit other)
        {
            return String.Equals(UnitName, other?.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CelsiusTemperatureUnit tmp && Equals(tmp);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        bool IEquatable<CelsiusTemperatureUnit>.Equals(CelsiusTemperatureUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(CelsiusTemperatureUnit left, CelsiusTemperatureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(CelsiusTemperatureUnit left, CelsiusTemperatureUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;CelsiusTemperatureUnit&gt; into CelsiusTemperatureUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator CelsiusTemperatureUnit(UnitDefinition<CelsiusTemperatureUnit> src)
        {
            return new CelsiusTemperatureUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
