// ReSharper disable All
// generator: BasicUnitValuesGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(TimeJsonConverter))]
    public partial struct Time : IUnitedValue<TimeUnit>, IEquatable<Time>, IComparable<Time>, IFormattable
    {
        /// <summary>
        /// creates instance of Time
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Time(decimal value, TimeUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(Time other)
        {
            return UnitedValuesUtils.Compare<Time, TimeUnit>(this, other);
        }

        public Time ConvertTo(TimeUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Time(basic / factor, newUnit);
        }

        public bool Equals(Time other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<TimeUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<TimeUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Time Round(int decimalPlaces)
        {
            return new Time(Math.Round(Value, decimalPlaces), Unit);
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
        public static Time operator -(Time value)
        {
            return new Time(-value.Value, value.Unit);
        }

        public static Time operator -(Time left, Time right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Time(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Time left, Time right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Time operator *(Time value, decimal number)
        {
            return new Time(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Time operator *(decimal number, Time value)
        {
            return new Time(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Time operator /(Time value, decimal number)
        {
            return new Time(value.Value / number, value.Unit);
        }

        public static decimal operator /(Time left, Time right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Time operator +(Time left, Time right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Time(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates time from value in h
        /// </summary>
        /// <param name="value">Time value in h</param>
        public static Time FromHours(decimal value)
        {
            return new Time(value, TimeUnits.Hour);
        }

        /// <summary>
        /// creates time from value in h
        /// </summary>
        /// <param name="value">Time value in h</param>
        public static Time FromHours(double value)
        {
            return new Time((decimal)value, TimeUnits.Hour);
        }

        /// <summary>
        /// creates time from value in h
        /// </summary>
        /// <param name="value">Time value in h</param>
        public static Time FromHours(int value)
        {
            return new Time(value, TimeUnits.Hour);
        }

        /// <summary>
        /// creates time from value in h
        /// </summary>
        /// <param name="value">Time value in h</param>
        public static Time FromHours(long value)
        {
            return new Time(value, TimeUnits.Hour);
        }

        /// <summary>
        /// creates time from value in min
        /// </summary>
        /// <param name="value">Time value in min</param>
        public static Time FromMinutes(decimal value)
        {
            return new Time(value, TimeUnits.Minute);
        }

        /// <summary>
        /// creates time from value in min
        /// </summary>
        /// <param name="value">Time value in min</param>
        public static Time FromMinutes(double value)
        {
            return new Time((decimal)value, TimeUnits.Minute);
        }

        /// <summary>
        /// creates time from value in min
        /// </summary>
        /// <param name="value">Time value in min</param>
        public static Time FromMinutes(int value)
        {
            return new Time(value, TimeUnits.Minute);
        }

        /// <summary>
        /// creates time from value in min
        /// </summary>
        /// <param name="value">Time value in min</param>
        public static Time FromMinutes(long value)
        {
            return new Time(value, TimeUnits.Minute);
        }

        /// <summary>
        /// creates time from value in s
        /// </summary>
        /// <param name="value">Time value in s</param>
        public static Time FromSecond(decimal value)
        {
            return new Time(value, TimeUnits.Second);
        }

        /// <summary>
        /// creates time from value in s
        /// </summary>
        /// <param name="value">Time value in s</param>
        public static Time FromSecond(double value)
        {
            return new Time((decimal)value, TimeUnits.Second);
        }

        /// <summary>
        /// creates time from value in s
        /// </summary>
        /// <param name="value">Time value in s</param>
        public static Time FromSecond(int value)
        {
            return new Time(value, TimeUnits.Second);
        }

        /// <summary>
        /// creates time from value in s
        /// </summary>
        /// <param name="value">Time value in s</param>
        public static Time FromSecond(long value)
        {
            return new Time(value, TimeUnits.Second);
        }

        public static Time Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Time));
            return new Time(parseResult.Value, new TimeUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public TimeUnit Unit { get; }

        public static readonly TimeUnit BaseUnit = TimeUnits.Second;

        public static readonly Time Zero = new Time(0, BaseUnit);

    }
}
