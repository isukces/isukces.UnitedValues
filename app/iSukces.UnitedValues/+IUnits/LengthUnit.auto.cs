// ReSharper disable All
// generator: UnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct LengthUnit : IUnit, IEquatable<LengthUnit>
    {
        /// <summary>
        /// creates instance of LengthUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public LengthUnit(string unitName)
        {
            UnitName = unitName.TrimToNull();
        }

        public bool Equals(LengthUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LengthUnit tmp && Equals(tmp);
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

        bool IEquatable<LengthUnit>.Equals(LengthUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;LengthUnit&gt; into LengthUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator LengthUnit(UnitDefinition<LengthUnit> src)
        {
            return new LengthUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
