// ReSharper disable All
// generator: UnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct AreaUnit : IUnit, IEquatable<AreaUnit>
    {
        /// <summary>
        /// creates instance of AreaUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public AreaUnit(string unitName)
        {
            UnitName = unitName?.Replace('2', '²');
        }

        public bool Equals(AreaUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AreaUnit tmp && Equals(tmp);
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

        bool IEquatable<AreaUnit>.Equals(AreaUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(AreaUnit left, AreaUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(AreaUnit left, AreaUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;AreaUnit&gt; into AreaUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator AreaUnit(UnitDefinition<AreaUnit> src)
        {
            return new AreaUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
