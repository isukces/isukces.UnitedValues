using System;

namespace isukces.UnitedValues
{ 
    public struct LengthUnit : IEquatable<LengthUnit>
    {
        public LengthUnit(string unitName)
        {
            UnitName = unitName;
        }

        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(LengthUnit other)
        {
            return string.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LengthUnit && Equals((LengthUnit)obj);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        public override string ToString() => UnitName;

        bool IEquatable<LengthUnit>.Equals(LengthUnit other) => Equals(other);

        public string UnitName { get; }
    }
}