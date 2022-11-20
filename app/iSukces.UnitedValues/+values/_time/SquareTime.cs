using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitValuesGenerator, UnitJsonConverterGenerator, UnitExtensionsGenerator

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(SquareTimeJsonConverter))]
    public partial struct SquareTime : IUnitedValue<SquareTimeUnit>, IEquatable<SquareTime>, IComparable<SquareTime>, IFormattable
    {
        /// <summary>
        /// creates instance of SquareTime
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public SquareTime(decimal value, SquareTimeUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(SquareTime other)
        {
            return UnitedValuesUtils.Compare<SquareTime, SquareTimeUnit>(this, other);
        }

        public SquareTime ConvertTo(SquareTimeUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new SquareTime(basic / factor, newUnit);
        }

        public bool Equals(SquareTime other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<SquareTimeUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<SquareTimeUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            // generator : BasicUnitValuesGenerator.Add_GetBaseUnitValue
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
                return (Value.GetHashCode() * 397) ^ Unit?.GetHashCode() ?? 0;
            }
        }

        public SquareTime Round(int decimalPlaces)
        {
            return new SquareTime(Math.Round(Value, decimalPlaces), Unit);
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
        public static SquareTime operator -(SquareTime value)
        {
            return new SquareTime(-value.Value, value.Unit);
        }

        public static SquareTime operator -(SquareTime left, SquareTime right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new SquareTime(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(SquareTime left, SquareTime right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static SquareTime operator *(SquareTime value, decimal number)
        {
            return new SquareTime(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static SquareTime operator *(decimal number, SquareTime value)
        {
            return new SquareTime(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static SquareTime operator /(SquareTime value, decimal number)
        {
            return new SquareTime(value.Value / number, value.Unit);
        }

        public static decimal operator /(SquareTime left, SquareTime right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static SquareTime operator +(SquareTime left, SquareTime right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new SquareTime(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(SquareTime left, SquareTime right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(SquareTime left, SquareTime right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(SquareTime left, SquareTime right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(SquareTime left, SquareTime right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(SquareTime left, SquareTime right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates squareTime from value in h²
        /// </summary>
        /// <param name="value">SquareTime value in h²</param>
        public static SquareTime FromSquareHours(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareHour);
        }

        /// <summary>
        /// creates squareTime from value in h²
        /// </summary>
        /// <param name="value">SquareTime value in h²</param>
        public static SquareTime FromSquareHours(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime((decimal)value, SquareTimeUnits.SquareHour);
        }

        /// <summary>
        /// creates squareTime from value in h²
        /// </summary>
        /// <param name="value">SquareTime value in h²</param>
        public static SquareTime FromSquareHours(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareHour);
        }

        /// <summary>
        /// creates squareTime from value in h²
        /// </summary>
        /// <param name="value">SquareTime value in h²</param>
        public static SquareTime FromSquareHours(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareHour);
        }

        /// <summary>
        /// creates squareTime from value in ms²
        /// </summary>
        /// <param name="value">SquareTime value in ms²</param>
        public static SquareTime FromSquareMiliSecond(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareMiliSecond);
        }

        /// <summary>
        /// creates squareTime from value in ms²
        /// </summary>
        /// <param name="value">SquareTime value in ms²</param>
        public static SquareTime FromSquareMiliSecond(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime((decimal)value, SquareTimeUnits.SquareMiliSecond);
        }

        /// <summary>
        /// creates squareTime from value in ms²
        /// </summary>
        /// <param name="value">SquareTime value in ms²</param>
        public static SquareTime FromSquareMiliSecond(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareMiliSecond);
        }

        /// <summary>
        /// creates squareTime from value in ms²
        /// </summary>
        /// <param name="value">SquareTime value in ms²</param>
        public static SquareTime FromSquareMiliSecond(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareMiliSecond);
        }

        /// <summary>
        /// creates squareTime from value in min²
        /// </summary>
        /// <param name="value">SquareTime value in min²</param>
        public static SquareTime FromSquareMinutes(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareMinute);
        }

        /// <summary>
        /// creates squareTime from value in min²
        /// </summary>
        /// <param name="value">SquareTime value in min²</param>
        public static SquareTime FromSquareMinutes(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime((decimal)value, SquareTimeUnits.SquareMinute);
        }

        /// <summary>
        /// creates squareTime from value in min²
        /// </summary>
        /// <param name="value">SquareTime value in min²</param>
        public static SquareTime FromSquareMinutes(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareMinute);
        }

        /// <summary>
        /// creates squareTime from value in min²
        /// </summary>
        /// <param name="value">SquareTime value in min²</param>
        public static SquareTime FromSquareMinutes(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareMinute);
        }

        /// <summary>
        /// creates squareTime from value in s²
        /// </summary>
        /// <param name="value">SquareTime value in s²</param>
        public static SquareTime FromSquareSecond(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareSecond);
        }

        /// <summary>
        /// creates squareTime from value in s²
        /// </summary>
        /// <param name="value">SquareTime value in s²</param>
        public static SquareTime FromSquareSecond(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime((decimal)value, SquareTimeUnits.SquareSecond);
        }

        /// <summary>
        /// creates squareTime from value in s²
        /// </summary>
        /// <param name="value">SquareTime value in s²</param>
        public static SquareTime FromSquareSecond(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareSecond);
        }

        /// <summary>
        /// creates squareTime from value in s²
        /// </summary>
        /// <param name="value">SquareTime value in s²</param>
        public static SquareTime FromSquareSecond(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareSecond);
        }

        /// <summary>
        /// creates squareTime from value in y²
        /// </summary>
        /// <param name="value">SquareTime value in y²</param>
        public static SquareTime FromSquareYears(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareYear);
        }

        /// <summary>
        /// creates squareTime from value in y²
        /// </summary>
        /// <param name="value">SquareTime value in y²</param>
        public static SquareTime FromSquareYears(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime((decimal)value, SquareTimeUnits.SquareYear);
        }

        /// <summary>
        /// creates squareTime from value in y²
        /// </summary>
        /// <param name="value">SquareTime value in y²</param>
        public static SquareTime FromSquareYears(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareYear);
        }

        /// <summary>
        /// creates squareTime from value in y²
        /// </summary>
        /// <param name="value">SquareTime value in y²</param>
        public static SquareTime FromSquareYears(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new SquareTime(value, SquareTimeUnits.SquareYear);
        }

        public static SquareTime Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(SquareTime));
            return new SquareTime(parseResult.Value, new SquareTimeUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public SquareTimeUnit Unit { get; }

        public static readonly SquareTimeUnit BaseUnit = SquareTimeUnits.SquareSecond;

        public static readonly SquareTime Zero = new SquareTime(0, BaseUnit);

    }

    public static partial class SquareTimeExtensions
    {
        public static SquareTime Sum(this IEnumerable<SquareTime> items)
        {
            if (items is null)
                return SquareTime.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return SquareTime.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new SquareTime(value, unit);
        }

        public static SquareTime Sum(this IEnumerable<SquareTime?> items)
        {
            if (items is null)
                return SquareTime.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static SquareTime Sum<T>(this IEnumerable<T> items, Func<T, SquareTime> map)
        {
            if (items is null)
                return SquareTime.Zero;
            return items.Select(map).Sum();
        }

    }

    public partial class SquareTimeJsonConverter : AbstractUnitJsonConverter<SquareTime, SquareTimeUnit>
    {
        protected override SquareTime Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new SquareTime(value, string.IsNullOrEmpty(unit) ? SquareTime.BaseUnit : new SquareTimeUnit(unit));
        }

        protected override SquareTime Parse(string txt)
        {
            return SquareTime.Parse(txt);
        }

    }
}