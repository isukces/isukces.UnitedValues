// ReSharper disable All
// generator: UnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct TimeUnit : IUnit, IEquatable<TimeUnit>
    {
        /// <summary>
        /// creates instance of TimeUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public TimeUnit(string unitName)
        {
            UnitName = unitName.TrimToNull();
        }

        public bool Equals(TimeUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TimeUnit tmp && Equals(tmp);
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

        bool IEquatable<TimeUnit>.Equals(TimeUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(TimeUnit left, TimeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(TimeUnit left, TimeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;TimeUnit&gt; into TimeUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator TimeUnit(UnitDefinition<TimeUnit> src)
        {
            return new TimeUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
