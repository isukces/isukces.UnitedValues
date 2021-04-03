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
    [JsonConverter(typeof(MassJsonConverter))]
    public partial struct Mass : IUnitedValue<MassUnit>, IEquatable<Mass>, IComparable<Mass>, IFormattable
    {
        /// <summary>
        /// creates instance of Mass
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Mass(decimal value, MassUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(Mass other)
        {
            return UnitedValuesUtils.Compare<Mass, MassUnit>(this, other);
        }

        public Mass ConvertTo(MassUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Mass(basic / factor, newUnit);
        }

        public bool Equals(Mass other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<MassUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<MassUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Mass Round(int decimalPlaces)
        {
            return new Mass(Math.Round(Value, decimalPlaces), Unit);
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
        public static Mass operator -(Mass value)
        {
            return new Mass(-value.Value, value.Unit);
        }

        public static Mass operator -(Mass left, Mass right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Mass(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Mass left, Mass right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Mass operator *(Mass value, decimal number)
        {
            return new Mass(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Mass operator *(decimal number, Mass value)
        {
            return new Mass(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Mass operator /(Mass value, decimal number)
        {
            return new Mass(value.Value / number, value.Unit);
        }

        public static decimal operator /(Mass left, Mass right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Mass operator +(Mass left, Mass right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Mass(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Mass left, Mass right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Mass left, Mass right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Mass left, Mass right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Mass left, Mass right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Mass left, Mass right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates mass from value in g
        /// </summary>
        /// <param name="value">Mass value in g</param>
        public static Mass FromGrams(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Gram);
        }

        /// <summary>
        /// creates mass from value in g
        /// </summary>
        /// <param name="value">Mass value in g</param>
        public static Mass FromGrams(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass((decimal)value, MassUnits.Gram);
        }

        /// <summary>
        /// creates mass from value in g
        /// </summary>
        /// <param name="value">Mass value in g</param>
        public static Mass FromGrams(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Gram);
        }

        /// <summary>
        /// creates mass from value in g
        /// </summary>
        /// <param name="value">Mass value in g</param>
        public static Mass FromGrams(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Gram);
        }

        /// <summary>
        /// creates mass from value in kg
        /// </summary>
        /// <param name="value">Mass value in kg</param>
        public static Mass FromKg(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Kg);
        }

        /// <summary>
        /// creates mass from value in kg
        /// </summary>
        /// <param name="value">Mass value in kg</param>
        public static Mass FromKg(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass((decimal)value, MassUnits.Kg);
        }

        /// <summary>
        /// creates mass from value in kg
        /// </summary>
        /// <param name="value">Mass value in kg</param>
        public static Mass FromKg(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Kg);
        }

        /// <summary>
        /// creates mass from value in kg
        /// </summary>
        /// <param name="value">Mass value in kg</param>
        public static Mass FromKg(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Kg);
        }

        /// <summary>
        /// creates mass from value in oz
        /// </summary>
        /// <param name="value">Mass value in oz</param>
        public static Mass FromOunce(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Ounce);
        }

        /// <summary>
        /// creates mass from value in oz
        /// </summary>
        /// <param name="value">Mass value in oz</param>
        public static Mass FromOunce(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass((decimal)value, MassUnits.Ounce);
        }

        /// <summary>
        /// creates mass from value in oz
        /// </summary>
        /// <param name="value">Mass value in oz</param>
        public static Mass FromOunce(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Ounce);
        }

        /// <summary>
        /// creates mass from value in oz
        /// </summary>
        /// <param name="value">Mass value in oz</param>
        public static Mass FromOunce(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Ounce);
        }

        /// <summary>
        /// creates mass from value in t
        /// </summary>
        /// <param name="value">Mass value in t</param>
        public static Mass FromTons(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Tone);
        }

        /// <summary>
        /// creates mass from value in t
        /// </summary>
        /// <param name="value">Mass value in t</param>
        public static Mass FromTons(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass((decimal)value, MassUnits.Tone);
        }

        /// <summary>
        /// creates mass from value in t
        /// </summary>
        /// <param name="value">Mass value in t</param>
        public static Mass FromTons(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Tone);
        }

        /// <summary>
        /// creates mass from value in t
        /// </summary>
        /// <param name="value">Mass value in t</param>
        public static Mass FromTons(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Mass(value, MassUnits.Tone);
        }

        public static Mass Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Mass));
            return new Mass(parseResult.Value, new MassUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public MassUnit Unit { get; }

        public static readonly MassUnit BaseUnit = MassUnits.Kg;

        public static readonly Mass Zero = new Mass(0, BaseUnit);

    }
}
