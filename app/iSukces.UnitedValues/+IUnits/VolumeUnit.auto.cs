// ReSharper disable All
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial struct VolumeUnit : IUnit, IEquatable<VolumeUnit>
    {
        /// <summary>
        /// creates instance of VolumeUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public VolumeUnit(string unitName)
        {
            UnitName = unitName?.Replace('3', '³');
        }

        public bool Equals(VolumeUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VolumeUnit tmp && Equals(tmp);
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

        bool IEquatable<VolumeUnit>.Equals(VolumeUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(VolumeUnit left, VolumeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(VolumeUnit left, VolumeUnit right)
        {
            return left.Equals(right);
        }

        public static implicit operator VolumeUnit(UnitDefinition<VolumeUnit> src)
        {
            return new VolumeUnit(src.UnitName);
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
