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
    [JsonConverter(typeof(DeltaKelvinTemperatureJsonConverter))]
    public partial struct DeltaKelvinTemperature : IUnitedValue<KelvinTemperatureUnit>, IEquatable<DeltaKelvinTemperature>, IComparable<DeltaKelvinTemperature>, IFormattable
    {
        /// <summary>
        /// creates instance of DeltaKelvinTemperature
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public DeltaKelvinTemperature(decimal value, KelvinTemperatureUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(DeltaKelvinTemperature other)
        {
            return UnitedValuesUtils.Compare<DeltaKelvinTemperature, KelvinTemperatureUnit>(this, other);
        }

        public DeltaKelvinTemperature ConvertTo(KelvinTemperatureUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new DeltaKelvinTemperature(basic / factor, newUnit);
        }

        public bool Equals(DeltaKelvinTemperature other)
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

        public DeltaKelvinTemperature Round(int decimalPlaces)
        {
            return new DeltaKelvinTemperature(Math.Round(Value, decimalPlaces), Unit);
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
        public static DeltaKelvinTemperature operator -(DeltaKelvinTemperature value)
        {
            return new DeltaKelvinTemperature(-value.Value, value.Unit);
        }

        public static DeltaKelvinTemperature operator -(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new DeltaKelvinTemperature(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static DeltaKelvinTemperature operator *(DeltaKelvinTemperature value, decimal number)
        {
            return new DeltaKelvinTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static DeltaKelvinTemperature operator *(decimal number, DeltaKelvinTemperature value)
        {
            return new DeltaKelvinTemperature(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static DeltaKelvinTemperature operator /(DeltaKelvinTemperature value, decimal number)
        {
            return new DeltaKelvinTemperature(value.Value / number, value.Unit);
        }

        public static decimal operator /(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static InversedDeltaKelvinTemperature operator /(decimal number, DeltaKelvinTemperature value)
        {
            return new InversedDeltaKelvinTemperature(number / value.Value, InversedKelvinTemperatureUnits.GetInversedKelvinTemperatureUnit(value.Unit));
        }

        public static DeltaKelvinTemperature operator +(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new DeltaKelvinTemperature(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(DeltaKelvinTemperature left, DeltaKelvinTemperature right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates deltaKelvinTemperature from value in ----
        /// </summary>
        /// <param name="value">DeltaKelvinTemperature value in ----</param>
        public static DeltaKelvinTemperature FromDegree(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new DeltaKelvinTemperature(value, KelvinTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates deltaKelvinTemperature from value in ----
        /// </summary>
        /// <param name="value">DeltaKelvinTemperature value in ----</param>
        public static DeltaKelvinTemperature FromDegree(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new DeltaKelvinTemperature((decimal)value, KelvinTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates deltaKelvinTemperature from value in ----
        /// </summary>
        /// <param name="value">DeltaKelvinTemperature value in ----</param>
        public static DeltaKelvinTemperature FromDegree(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new DeltaKelvinTemperature(value, KelvinTemperatureUnits.Degree);
        }

        /// <summary>
        /// creates deltaKelvinTemperature from value in ----
        /// </summary>
        /// <param name="value">DeltaKelvinTemperature value in ----</param>
        public static DeltaKelvinTemperature FromDegree(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new DeltaKelvinTemperature(value, KelvinTemperatureUnits.Degree);
        }

        public static DeltaKelvinTemperature Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(DeltaKelvinTemperature));
            return new DeltaKelvinTemperature(parseResult.Value, new KelvinTemperatureUnit(parseResult.UnitName));
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

        public static readonly DeltaKelvinTemperature Zero = new DeltaKelvinTemperature(0, BaseUnit);

    }
}
