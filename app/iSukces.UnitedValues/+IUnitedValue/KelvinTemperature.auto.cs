// ReSharper disable All
// generator: BasicUnitValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(KelvinTemperatureJsonConverter))]
    public partial struct KelvinTemperature : IUnitedValue<KelvinTemperatureUnit>, IEquatable<KelvinTemperature>, IComparable<KelvinTemperature>, IFormattable
    {
        /// <summary>
        /// creates instance of KelvinTemperature
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public KelvinTemperature(decimal value, KelvinTemperatureUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(KelvinTemperature other)
        {
            return UnitedValuesUtils.Compare<KelvinTemperature, KelvinTemperatureUnit>(this, other);
        }

        public KelvinTemperature ConvertTo(KelvinTemperatureUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new KelvinTemperature(basic / factor, newUnit);
        }

        public bool Equals(KelvinTemperature other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<KelvinTemperatureUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<KelvinTemperatureUnit> unitedValue ? Equals(unitedValue) : false;
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

        public KelvinTemperature Round(int decimalPlaces)
        {
            return new KelvinTemperature(Math.Round(Value, decimalPlaces), Unit);
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
        public static KelvinTemperature operator -(KelvinTemperature value)
        {
            return new KelvinTemperature(-value.Value, value.Unit);
        }

        public static DeltaKelvinTemperature operator -(KelvinTemperature left, KelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return new DeltaKelvinTemperature(-right.Value, right.Unit);
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return new DeltaKelvinTemperature(left.Value, left.Unit);
            right = right.ConvertTo(left.Unit);
            return new DeltaKelvinTemperature(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(KelvinTemperature left, KelvinTemperature right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static KelvinTemperature operator *(KelvinTemperature value, decimal number)
        {
            return new KelvinTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static KelvinTemperature operator *(decimal number, KelvinTemperature value)
        {
            return new KelvinTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static KelvinTemperature operator /(KelvinTemperature value, decimal number)
        {
            return new KelvinTemperature(value.Value / number, value.Unit);
        }

        public static decimal operator /(KelvinTemperature left, KelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static KelvinTemperature operator +(KelvinTemperature left, DeltaKelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return new KelvinTemperature(right.Value, left.Unit);
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new KelvinTemperature(left.Value + right.Value, left.Unit);
        }

        public static KelvinTemperature operator +(DeltaKelvinTemperature left, KelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return new KelvinTemperature(left.Value, right.Unit);
            right = right.ConvertTo(left.Unit);
            return new KelvinTemperature(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(KelvinTemperature left, KelvinTemperature right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(KelvinTemperature left, KelvinTemperature right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(KelvinTemperature left, KelvinTemperature right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(KelvinTemperature left, KelvinTemperature right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(KelvinTemperature left, KelvinTemperature right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates kelvinTemperature from value in K
        /// </summary>
        /// <param name="value">KelvinTemperature value in K</param>
        public static KelvinTemperature FromDegree(decimal value)
        {
            return new KelvinTemperature(value, KelvinTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates kelvinTemperature from value in K
        /// </summary>
        /// <param name="value">KelvinTemperature value in K</param>
        public static KelvinTemperature FromDegree(double value)
        {
            return new KelvinTemperature((decimal)value, KelvinTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates kelvinTemperature from value in K
        /// </summary>
        /// <param name="value">KelvinTemperature value in K</param>
        public static KelvinTemperature FromDegree(int value)
        {
            return new KelvinTemperature(value, KelvinTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates kelvinTemperature from value in K
        /// </summary>
        /// <param name="value">KelvinTemperature value in K</param>
        public static KelvinTemperature FromDegree(long value)
        {
            return new KelvinTemperature(value, KelvinTemperatureUnits.Degree);
        }

        public static KelvinTemperature Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(KelvinTemperature));
            return new KelvinTemperature(parseResult.Value, new KelvinTemperatureUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public KelvinTemperatureUnit Unit { get; }

        public static readonly KelvinTemperatureUnit BaseUnit = KelvinTemperatureUnits.Degree;

        public static readonly KelvinTemperature Zero = new KelvinTemperature(0, BaseUnit);

    }
}
