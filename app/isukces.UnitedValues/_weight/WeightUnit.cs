using System;

namespace isukces.UnitedValues
{
    public struct WeightUnit : IEquatable<WeightUnit>
    {
        public WeightUnit(string unitName)
        {
            UnitName = unitName;
        }

        public static bool operator ==(WeightUnit left, WeightUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WeightUnit left, WeightUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(WeightUnit other)
        {
            return string.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is WeightUnit && Equals((WeightUnit)obj);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        public override string ToString() => UnitName;

        bool IEquatable<WeightUnit>.Equals(WeightUnit other) => Equals(other);

        public string UnitName { get; }
    }
}