// ReSharper disable All
// generator: UnitedValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(LengthJsonConverter))]
    public partial struct Length : IUnitedValue<LengthUnit>, IEquatable<Length>, IComparable<Length>, IFormattable
    {
        /// <summary>
        /// creates instance of Length
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Length(decimal value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public int CompareTo(Length other)
        {
            return UnitedValuesUtils.Compare<Length, LengthUnit>(this, other);
        }

        public Length ConvertTo(LengthUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.Get(newUnit);
            if (factor is null)
                throw new Exception("Unable to find multiplication for unit " + newUnit);
            return new Length(basic / factor.Value, newUnit);
        }

        public bool Equals(Length other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<LengthUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<LengthUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            if (Unit.Equals(BaseUnit))
                return Value;
            var factor = GlobalUnitRegistry.Factors.Get(Unit);
            if (!(factor is null))
                return Value * factor.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public Length Round(int decimalPlaces)
        {
            return new Length(Math.Round(Value, decimalPlaces), Unit);
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        public string ToString(string format, IFormatProvider provider = null)
        {
            return this.ToStringFormat(format, provider);
        }

        /// <summary>
        /// implements - operator
        /// </summary>
        /// <param name="value"></param>
        public static Length operator -(Length value)
        {
            return new Length(-value.Value, value.Unit);
        }

        public static Length operator -(Length left, Length right)
        {
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Length(right.Value - left.Value, left.Unit);
        }

        public static bool operator !=(Length left, Length right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Length operator *(Length value, decimal number)
        {
            return new Length(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Length operator *(decimal number, Length value)
        {
            return new Length(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Length operator /(Length value, decimal number)
        {
            return new Length(value.Value / number, value.Unit);
        }

        public static decimal operator /(Length left, Length right)
        {
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Length operator +(Length left, Length right)
        {
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Length(right.Value + left.Value, left.Unit);
        }

        public static bool operator <(Length left, Length right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Length left, Length right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static Length Parse(string value)
        {
            var parseResult = CommonParse.Parse(value, typeof(Length));
            return new Length(parseResult.Value, new LengthUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public LengthUnit Unit { get; }

        public static readonly LengthUnit BaseUnit = LengthUnits.Meter;

        public static readonly Length Zero = new Length(0, BaseUnit);

    }
}
