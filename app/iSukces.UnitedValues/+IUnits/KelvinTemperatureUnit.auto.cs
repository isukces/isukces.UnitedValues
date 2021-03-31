// ReSharper disable All
// generator: BasicUnitGenerator
using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial class KelvinTemperatureUnit : IUnit, IEquatable<KelvinTemperatureUnit>
    {
        /// <summary>
        /// creates instance of KelvinTemperatureUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public KelvinTemperatureUnit(string unitName)
        {
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName;
        }

        public bool Equals(KelvinTemperatureUnit other)
        {
            return String.Equals(UnitName, other?.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is KelvinTemperatureUnit tmp && Equals(tmp);
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

        bool IEquatable<KelvinTemperatureUnit>.Equals(KelvinTemperatureUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(KelvinTemperatureUnit left, KelvinTemperatureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(KelvinTemperatureUnit left, KelvinTemperatureUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;KelvinTemperatureUnit&gt; into KelvinTemperatureUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator KelvinTemperatureUnit(UnitDefinition<KelvinTemperatureUnit> src)
        {
            return src.Unit;
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
