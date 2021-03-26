using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class TypesGroup : IEquatable<TypesGroup>
    {
        /// <summary>
        ///     Creates instance
        /// </summary>
        /// <param name="value">Name of type that contains value and unit i.e. Length</param>
        /// <param name="unit">Name of type that represents unit i.e. LengthUnit</param>
        /// <param name="container">Name of static type that contains fields with known unit names i.e. LengthUnits</param>
        public TypesGroup(string value, string unit = null, string container = null)
        {
            value = value?.TrimToNull();
            Value = value ?? throw new ArgumentException(nameof(value));

            var isDeltaValue = Value.StartsWith("Delta", StringComparison.Ordinal);
            ValueKind = isDeltaValue ? Kind.Delta : Kind.Normal;
            var valueNoDelta = isDeltaValue ? Value.Substring(5) : Value;

            Unit      = unit?.TrimToNull() ?? valueNoDelta + "Unit";
            Container = container?.TrimToNull() ?? Unit + "s";
        }

        public static bool operator ==(TypesGroup left, TypesGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TypesGroup left, TypesGroup right)
        {
            return !Equals(left, right);
        }

        public bool Equals(TypesGroup other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value && Unit == other.Unit &&
                   Container == other.Container;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TypesGroup)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Value.GetHashCode();
                hashCode = (hashCode * 397) ^ Unit.GetHashCode();
                hashCode = (hashCode * 397) ^ Container.GetHashCode();
                return hashCode;
            }
        }

        public bool IsValue<T>()
        {
            return typeof(T).Name == Value;
        }

        public override string ToString()
        {
            return
                $"ValueTypeName={Value}, UnitTypeName={Unit}, UnitContainerTypeName={Container}";
        }

        public Kind ValueKind { get; }


        /// <summary>
        ///     Name of type that contains value and unit i.e. Length
        /// </summary>
        public string Value { get; }

        /// <summary>
        ///     Name of type that represents unit i.e. LengthUnit
        /// </summary>
        public string Unit { get; }

        /// <summary>
        ///     Name of static type that contains fields with known unit names i.e. LengthUnits
        /// </summary>
        public string Container { get; }
    }

    public enum Kind
    {
        Normal,
        Delta
    }
}