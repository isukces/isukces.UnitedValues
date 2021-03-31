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
    [JsonConverter(typeof(PowerJsonConverter))]
    public partial struct Power : IUnitedValue<PowerUnit>, IEquatable<Power>, IComparable<Power>, IFormattable
    {
        /// <summary>
        /// creates instance of Power
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Power(decimal value, PowerUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(Power other)
        {
            return UnitedValuesUtils.Compare<Power, PowerUnit>(this, other);
        }

        public Power ConvertTo(PowerUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Power(basic / factor, newUnit);
        }

        public bool Equals(Power other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<PowerUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<PowerUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Power Round(int decimalPlaces)
        {
            return new Power(Math.Round(Value, decimalPlaces), Unit);
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
        public static Power operator -(Power value)
        {
            return new Power(-value.Value, value.Unit);
        }

        public static Power operator -(Power left, Power right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Power(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Power left, Power right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Power operator *(Power value, decimal number)
        {
            return new Power(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Power operator *(decimal number, Power value)
        {
            return new Power(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Power operator /(Power value, decimal number)
        {
            return new Power(value.Value / number, value.Unit);
        }

        public static decimal operator /(Power left, Power right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Power operator +(Power left, Power right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Power(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Power left, Power right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Power left, Power right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Power left, Power right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Power left, Power right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Power left, Power right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates power from value in GW
        /// </summary>
        /// <param name="value">Power value in GW</param>
        public static Power FromGigaWatt(decimal value)
        {
            return new Power(value, PowerUnits.GigaWatt);
        }

        /// <summary>
        /// creates power from value in GW
        /// </summary>
        /// <param name="value">Power value in GW</param>
        public static Power FromGigaWatt(double value)
        {
            return new Power((decimal)value, PowerUnits.GigaWatt);
        }

        /// <summary>
        /// creates power from value in GW
        /// </summary>
        /// <param name="value">Power value in GW</param>
        public static Power FromGigaWatt(int value)
        {
            return new Power(value, PowerUnits.GigaWatt);
        }

        /// <summary>
        /// creates power from value in GW
        /// </summary>
        /// <param name="value">Power value in GW</param>
        public static Power FromGigaWatt(long value)
        {
            return new Power(value, PowerUnits.GigaWatt);
        }

        /// <summary>
        /// creates power from value in kW
        /// </summary>
        /// <param name="value">Power value in kW</param>
        public static Power FromKiloWatt(decimal value)
        {
            return new Power(value, PowerUnits.KiloWatt);
        }

        /// <summary>
        /// creates power from value in kW
        /// </summary>
        /// <param name="value">Power value in kW</param>
        public static Power FromKiloWatt(double value)
        {
            return new Power((decimal)value, PowerUnits.KiloWatt);
        }

        /// <summary>
        /// creates power from value in kW
        /// </summary>
        /// <param name="value">Power value in kW</param>
        public static Power FromKiloWatt(int value)
        {
            return new Power(value, PowerUnits.KiloWatt);
        }

        /// <summary>
        /// creates power from value in kW
        /// </summary>
        /// <param name="value">Power value in kW</param>
        public static Power FromKiloWatt(long value)
        {
            return new Power(value, PowerUnits.KiloWatt);
        }

        /// <summary>
        /// creates power from value in MW
        /// </summary>
        /// <param name="value">Power value in MW</param>
        public static Power FromMegaWatt(decimal value)
        {
            return new Power(value, PowerUnits.MegaWatt);
        }

        /// <summary>
        /// creates power from value in MW
        /// </summary>
        /// <param name="value">Power value in MW</param>
        public static Power FromMegaWatt(double value)
        {
            return new Power((decimal)value, PowerUnits.MegaWatt);
        }

        /// <summary>
        /// creates power from value in MW
        /// </summary>
        /// <param name="value">Power value in MW</param>
        public static Power FromMegaWatt(int value)
        {
            return new Power(value, PowerUnits.MegaWatt);
        }

        /// <summary>
        /// creates power from value in MW
        /// </summary>
        /// <param name="value">Power value in MW</param>
        public static Power FromMegaWatt(long value)
        {
            return new Power(value, PowerUnits.MegaWatt);
        }

        /// <summary>
        /// creates power from value in mW
        /// </summary>
        /// <param name="value">Power value in mW</param>
        public static Power FromMiliWatt(decimal value)
        {
            return new Power(value, PowerUnits.MiliWatt);
        }

        /// <summary>
        /// creates power from value in mW
        /// </summary>
        /// <param name="value">Power value in mW</param>
        public static Power FromMiliWatt(double value)
        {
            return new Power((decimal)value, PowerUnits.MiliWatt);
        }

        /// <summary>
        /// creates power from value in mW
        /// </summary>
        /// <param name="value">Power value in mW</param>
        public static Power FromMiliWatt(int value)
        {
            return new Power(value, PowerUnits.MiliWatt);
        }

        /// <summary>
        /// creates power from value in mW
        /// </summary>
        /// <param name="value">Power value in mW</param>
        public static Power FromMiliWatt(long value)
        {
            return new Power(value, PowerUnits.MiliWatt);
        }

        /// <summary>
        /// creates power from value in W
        /// </summary>
        /// <param name="value">Power value in W</param>
        public static Power FromWatt(decimal value)
        {
            return new Power(value, PowerUnits.Watt);
        }

        /// <summary>
        /// creates power from value in W
        /// </summary>
        /// <param name="value">Power value in W</param>
        public static Power FromWatt(double value)
        {
            return new Power((decimal)value, PowerUnits.Watt);
        }

        /// <summary>
        /// creates power from value in W
        /// </summary>
        /// <param name="value">Power value in W</param>
        public static Power FromWatt(int value)
        {
            return new Power(value, PowerUnits.Watt);
        }

        /// <summary>
        /// creates power from value in W
        /// </summary>
        /// <param name="value">Power value in W</param>
        public static Power FromWatt(long value)
        {
            return new Power(value, PowerUnits.Watt);
        }

        public static Power Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Power));
            return new Power(parseResult.Value, new PowerUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public PowerUnit Unit { get; }

        public static readonly PowerUnit BaseUnit = PowerUnits.Watt;

        public static readonly Power Zero = new Power(0, BaseUnit);

    }
}
