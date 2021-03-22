// ReSharper disable All
// generator: UnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct ForceUnit : IUnit, IEquatable<ForceUnit>
    {
        /// <summary>
        /// creates instance of ForceUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public ForceUnit(string unitName)
        {
            UnitName = unitName.TrimToNull();
        }

        public bool Equals(ForceUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ForceUnit tmp && Equals(tmp);
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

        bool IEquatable<ForceUnit>.Equals(ForceUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(ForceUnit left, ForceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(ForceUnit left, ForceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;ForceUnit&gt; into ForceUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator ForceUnit(UnitDefinition<ForceUnit> src)
        {
            return new ForceUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
