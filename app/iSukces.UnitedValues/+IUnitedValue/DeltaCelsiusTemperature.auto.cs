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
    [JsonConverter(typeof(DeltaCelsiusTemperatureJsonConverter))]
    public partial struct DeltaCelsiusTemperature : IUnitedValue<CelsiusTemperatureUnit>, IEquatable<DeltaCelsiusTemperature>, IComparable<DeltaCelsiusTemperature>, IFormattable
    {
        /// <summary>
        /// creates instance of DeltaCelsiusTemperature
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public DeltaCelsiusTemperature(decimal value, CelsiusTemperatureUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(DeltaCelsiusTemperature other)
        {
            return UnitedValuesUtils.Compare<DeltaCelsiusTemperature, CelsiusTemperatureUnit>(this, other);
        }

        public DeltaCelsiusTemperature ConvertTo(CelsiusTemperatureUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new DeltaCelsiusTemperature(basic / factor, newUnit);
        }

        public bool Equals(DeltaCelsiusTemperature other)
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

        public DeltaCelsiusTemperature Round(int decimalPlaces)
        {
            return new DeltaCelsiusTemperature(Math.Round(Value, decimalPlaces), Unit);
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
        public static DeltaCelsiusTemperature operator -(DeltaCelsiusTemperature value)
        {
            return new DeltaCelsiusTemperature(-value.Value, value.Unit);
        }

        public static DeltaCelsiusTemperature operator -(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new DeltaCelsiusTemperature(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static DeltaCelsiusTemperature operator *(DeltaCelsiusTemperature value, decimal number)
        {
            return new DeltaCelsiusTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static DeltaCelsiusTemperature operator *(decimal number, DeltaCelsiusTemperature value)
        {
            return new DeltaCelsiusTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static DeltaCelsiusTemperature operator /(DeltaCelsiusTemperature value, decimal number)
        {
            return new DeltaCelsiusTemperature(value.Value / number, value.Unit);
        }

        public static decimal operator /(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static DeltaCelsiusTemperature operator +(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new DeltaCelsiusTemperature(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static DeltaCelsiusTemperature Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(DeltaCelsiusTemperature));
            return new DeltaCelsiusTemperature(parseResult.Value, new CelsiusTemperatureUnit(parseResult.UnitName));
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

        public static readonly DeltaCelsiusTemperature Zero = new DeltaCelsiusTemperature(0, BaseUnit);

    }
}
