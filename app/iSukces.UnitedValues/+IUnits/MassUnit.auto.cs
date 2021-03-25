// ReSharper disable All
// generator: UnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct MassUnit : IUnit, IEquatable<MassUnit>
    {
        /// <summary>
        /// creates instance of MassUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public MassUnit(string unitName)
        {
            UnitName = unitName.TrimToNull();
        }

        public bool Equals(MassUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is MassUnit tmp && Equals(tmp);
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

        bool IEquatable<MassUnit>.Equals(MassUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(MassUnit left, MassUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(MassUnit left, MassUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;MassUnit&gt; into MassUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator MassUnit(UnitDefinition<MassUnit> src)
        {
            return new MassUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}