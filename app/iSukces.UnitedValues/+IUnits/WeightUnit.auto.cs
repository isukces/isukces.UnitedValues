// ReSharper disable All
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct WeightUnit : IUnit, IEquatable<WeightUnit>
    {
        /// <summary>
        /// creates instance of WeightUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public WeightUnit(string unitName)
        {
            UnitName = unitName;
        }

        public bool Equals(WeightUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is WeightUnit tmp && Equals(tmp);
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

        bool IEquatable<WeightUnit>.Equals(WeightUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(WeightUnit left, WeightUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(WeightUnit left, WeightUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;WeightUnit&gt; into WeightUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator WeightUnit(UnitDefinition<WeightUnit> src)
        {
            return new WeightUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
