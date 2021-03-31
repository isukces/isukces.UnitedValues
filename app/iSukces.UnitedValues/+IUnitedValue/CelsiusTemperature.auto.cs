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
    [JsonConverter(typeof(CelsiusTemperatureJsonConverter))]
    public partial struct CelsiusTemperature : IUnitedValue<CelsiusTemperatureUnit>, IEquatable<CelsiusTemperature>, IComparable<CelsiusTemperature>, IFormattable
    {
        /// <summary>
        /// creates instance of CelsiusTemperature
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public CelsiusTemperature(decimal value, CelsiusTemperatureUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(CelsiusTemperature other)
        {
            return UnitedValuesUtils.Compare<CelsiusTemperature, CelsiusTemperatureUnit>(this, other);
        }

        public CelsiusTemperature ConvertTo(CelsiusTemperatureUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new CelsiusTemperature(basic / factor, newUnit);
        }

        public bool Equals(CelsiusTemperature other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<CelsiusTemperatureUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<CelsiusTemperatureUnit> unitedValue ? Equals(unitedValue) : false;
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

        public CelsiusTemperature Round(int decimalPlaces)
        {
            return new CelsiusTemperature(Math.Round(Value, decimalPlaces), Unit);
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
        public static CelsiusTemperature operator -(CelsiusTemperature value)
        {
            return new CelsiusTemperature(-value.Value, value.Unit);
        }

        public static DeltaCelsiusTemperature operator -(CelsiusTemperature left, CelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return new DeltaCelsiusTemperature(-right.Value, right.Unit);
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return new DeltaCelsiusTemperature(left.Value, left.Unit);
            right = right.ConvertTo(left.Unit);
            return new DeltaCelsiusTemperature(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(CelsiusTemperature left, CelsiusTemperature right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static CelsiusTemperature operator *(CelsiusTemperature value, decimal number)
        {
            return new CelsiusTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static CelsiusTemperature operator *(decimal number, CelsiusTemperature value)
        {
            return new CelsiusTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static CelsiusTemperature operator /(CelsiusTemperature value, decimal number)
        {
            return new CelsiusTemperature(value.Value / number, value.Unit);
        }

        public static decimal operator /(CelsiusTemperature left, CelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static CelsiusTemperature operator +(CelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return new CelsiusTemperature(right.Value, left.Unit);
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new CelsiusTemperature(left.Value + right.Value, left.Unit);
        }

        public static CelsiusTemperature operator +(DeltaCelsiusTemperature left, CelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return new CelsiusTemperature(left.Value, right.Unit);
            right = right.ConvertTo(left.Unit);
            return new CelsiusTemperature(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(CelsiusTemperature left, CelsiusTemperature right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(CelsiusTemperature left, CelsiusTemperature right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(CelsiusTemperature left, CelsiusTemperature right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(CelsiusTemperature left, CelsiusTemperature right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(CelsiusTemperature left, CelsiusTemperature right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates celsiusTemperature from value in °C
        /// </summary>
        /// <param name="value">CelsiusTemperature value in °C</param>
        public static CelsiusTemperature FromDegree(decimal value)
        {
            return new CelsiusTemperature(value, CelsiusTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates celsiusTemperature from value in °C
        /// </summary>
        /// <param name="value">CelsiusTemperature value in °C</param>
        public static CelsiusTemperature FromDegree(double value)
        {
            return new CelsiusTemperature((decimal)value, CelsiusTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates celsiusTemperature from value in °C
        /// </summary>
        /// <param name="value">CelsiusTemperature value in °C</param>
        public static CelsiusTemperature FromDegree(int value)
        {
            return new CelsiusTemperature(value, CelsiusTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates celsiusTemperature from value in °C
        /// </summary>
        /// <param name="value">CelsiusTemperature value in °C</param>
        public static CelsiusTemperature FromDegree(long value)
        {
            return new CelsiusTemperature(value, CelsiusTemperatureUnits.Degree);
        }

        public static CelsiusTemperature Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(CelsiusTemperature));
            return new CelsiusTemperature(parseResult.Value, new CelsiusTemperatureUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public CelsiusTemperatureUnit Unit { get; }

        public static readonly CelsiusTemperatureUnit BaseUnit = CelsiusTemperatureUnits.Degree;

        public static readonly CelsiusTemperature Zero = new CelsiusTemperature(0, BaseUnit);

    }
}
