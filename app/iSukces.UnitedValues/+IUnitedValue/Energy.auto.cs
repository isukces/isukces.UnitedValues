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
    [JsonConverter(typeof(EnergyJsonConverter))]
    public partial struct Energy : IUnitedValue<EnergyUnit>, IEquatable<Energy>, IComparable<Energy>, IFormattable
    {
        /// <summary>
        /// creates instance of Energy
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Energy(decimal value, EnergyUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(Energy other)
        {
            return UnitedValuesUtils.Compare<Energy, EnergyUnit>(this, other);
        }

        public Energy ConvertTo(EnergyUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Energy(basic / factor, newUnit);
        }

        public bool Equals(Energy other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<EnergyUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<EnergyUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Energy Round(int decimalPlaces)
        {
            return new Energy(Math.Round(Value, decimalPlaces), Unit);
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
        public static Energy operator -(Energy value)
        {
            return new Energy(-value.Value, value.Unit);
        }

        public static Energy operator -(Energy left, Energy right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Energy(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Energy left, Energy right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Energy operator *(Energy value, decimal number)
        {
            return new Energy(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Energy operator *(decimal number, Energy value)
        {
            return new Energy(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Energy operator /(Energy value, decimal number)
        {
            return new Energy(value.Value / number, value.Unit);
        }

        public static decimal operator /(Energy left, Energy right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Energy operator +(Energy left, Energy right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Energy(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Energy left, Energy right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Energy left, Energy right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Energy left, Energy right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Energy left, Energy right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Energy left, Energy right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates energy from value in cal
        /// </summary>
        /// <param name="value">Energy value in cal</param>
        public static Energy FromCalorie(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.Calorie);
        }

        /// <summary>
        /// creates energy from value in cal
        /// </summary>
        /// <param name="value">Energy value in cal</param>
        public static Energy FromCalorie(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.Calorie);
        }

        /// <summary>
        /// creates energy from value in cal
        /// </summary>
        /// <param name="value">Energy value in cal</param>
        public static Energy FromCalorie(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.Calorie);
        }

        /// <summary>
        /// creates energy from value in cal
        /// </summary>
        /// <param name="value">Energy value in cal</param>
        public static Energy FromCalorie(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.Calorie);
        }

        /// <summary>
        /// creates energy from value in GJ
        /// </summary>
        /// <param name="value">Energy value in GJ</param>
        public static Energy FromGigaJoule(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.GigaJoule);
        }

        /// <summary>
        /// creates energy from value in GJ
        /// </summary>
        /// <param name="value">Energy value in GJ</param>
        public static Energy FromGigaJoule(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.GigaJoule);
        }

        /// <summary>
        /// creates energy from value in GJ
        /// </summary>
        /// <param name="value">Energy value in GJ</param>
        public static Energy FromGigaJoule(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.GigaJoule);
        }

        /// <summary>
        /// creates energy from value in GJ
        /// </summary>
        /// <param name="value">Energy value in GJ</param>
        public static Energy FromGigaJoule(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.GigaJoule);
        }

        /// <summary>
        /// creates energy from value in GWh
        /// </summary>
        /// <param name="value">Energy value in GWh</param>
        public static Energy FromGigaWattHour(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.GigaWattHour);
        }

        /// <summary>
        /// creates energy from value in GWh
        /// </summary>
        /// <param name="value">Energy value in GWh</param>
        public static Energy FromGigaWattHour(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.GigaWattHour);
        }

        /// <summary>
        /// creates energy from value in GWh
        /// </summary>
        /// <param name="value">Energy value in GWh</param>
        public static Energy FromGigaWattHour(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.GigaWattHour);
        }

        /// <summary>
        /// creates energy from value in GWh
        /// </summary>
        /// <param name="value">Energy value in GWh</param>
        public static Energy FromGigaWattHour(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.GigaWattHour);
        }

        /// <summary>
        /// creates energy from value in J
        /// </summary>
        /// <param name="value">Energy value in J</param>
        public static Energy FromJoule(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.Joule);
        }

        /// <summary>
        /// creates energy from value in J
        /// </summary>
        /// <param name="value">Energy value in J</param>
        public static Energy FromJoule(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.Joule);
        }

        /// <summary>
        /// creates energy from value in J
        /// </summary>
        /// <param name="value">Energy value in J</param>
        public static Energy FromJoule(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.Joule);
        }

        /// <summary>
        /// creates energy from value in J
        /// </summary>
        /// <param name="value">Energy value in J</param>
        public static Energy FromJoule(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.Joule);
        }

        /// <summary>
        /// creates energy from value in kcal
        /// </summary>
        /// <param name="value">Energy value in kcal</param>
        public static Energy FromKiloCalorie(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloCalorie);
        }

        /// <summary>
        /// creates energy from value in kcal
        /// </summary>
        /// <param name="value">Energy value in kcal</param>
        public static Energy FromKiloCalorie(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.KiloCalorie);
        }

        /// <summary>
        /// creates energy from value in kcal
        /// </summary>
        /// <param name="value">Energy value in kcal</param>
        public static Energy FromKiloCalorie(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloCalorie);
        }

        /// <summary>
        /// creates energy from value in kcal
        /// </summary>
        /// <param name="value">Energy value in kcal</param>
        public static Energy FromKiloCalorie(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloCalorie);
        }

        /// <summary>
        /// creates energy from value in kJ
        /// </summary>
        /// <param name="value">Energy value in kJ</param>
        public static Energy FromKiloJoule(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloJoule);
        }

        /// <summary>
        /// creates energy from value in kJ
        /// </summary>
        /// <param name="value">Energy value in kJ</param>
        public static Energy FromKiloJoule(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.KiloJoule);
        }

        /// <summary>
        /// creates energy from value in kJ
        /// </summary>
        /// <param name="value">Energy value in kJ</param>
        public static Energy FromKiloJoule(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloJoule);
        }

        /// <summary>
        /// creates energy from value in kJ
        /// </summary>
        /// <param name="value">Energy value in kJ</param>
        public static Energy FromKiloJoule(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloJoule);
        }

        /// <summary>
        /// creates energy from value in kWh
        /// </summary>
        /// <param name="value">Energy value in kWh</param>
        public static Energy FromKiloWattHour(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloWattHour);
        }

        /// <summary>
        /// creates energy from value in kWh
        /// </summary>
        /// <param name="value">Energy value in kWh</param>
        public static Energy FromKiloWattHour(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.KiloWattHour);
        }

        /// <summary>
        /// creates energy from value in kWh
        /// </summary>
        /// <param name="value">Energy value in kWh</param>
        public static Energy FromKiloWattHour(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloWattHour);
        }

        /// <summary>
        /// creates energy from value in kWh
        /// </summary>
        /// <param name="value">Energy value in kWh</param>
        public static Energy FromKiloWattHour(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.KiloWattHour);
        }

        /// <summary>
        /// creates energy from value in MJ
        /// </summary>
        /// <param name="value">Energy value in MJ</param>
        public static Energy FromMegaJoule(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.MegaJoule);
        }

        /// <summary>
        /// creates energy from value in MJ
        /// </summary>
        /// <param name="value">Energy value in MJ</param>
        public static Energy FromMegaJoule(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.MegaJoule);
        }

        /// <summary>
        /// creates energy from value in MJ
        /// </summary>
        /// <param name="value">Energy value in MJ</param>
        public static Energy FromMegaJoule(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.MegaJoule);
        }

        /// <summary>
        /// creates energy from value in MJ
        /// </summary>
        /// <param name="value">Energy value in MJ</param>
        public static Energy FromMegaJoule(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.MegaJoule);
        }

        /// <summary>
        /// creates energy from value in MWh
        /// </summary>
        /// <param name="value">Energy value in MWh</param>
        public static Energy FromMegaWattHour(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.MegaWattHour);
        }

        /// <summary>
        /// creates energy from value in MWh
        /// </summary>
        /// <param name="value">Energy value in MWh</param>
        public static Energy FromMegaWattHour(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.MegaWattHour);
        }

        /// <summary>
        /// creates energy from value in MWh
        /// </summary>
        /// <param name="value">Energy value in MWh</param>
        public static Energy FromMegaWattHour(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.MegaWattHour);
        }

        /// <summary>
        /// creates energy from value in MWh
        /// </summary>
        /// <param name="value">Energy value in MWh</param>
        public static Energy FromMegaWattHour(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.MegaWattHour);
        }

        /// <summary>
        /// creates energy from value in Wh
        /// </summary>
        /// <param name="value">Energy value in Wh</param>
        public static Energy FromWattHour(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.WattHour);
        }

        /// <summary>
        /// creates energy from value in Wh
        /// </summary>
        /// <param name="value">Energy value in Wh</param>
        public static Energy FromWattHour(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy((decimal)value, EnergyUnits.WattHour);
        }

        /// <summary>
        /// creates energy from value in Wh
        /// </summary>
        /// <param name="value">Energy value in Wh</param>
        public static Energy FromWattHour(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.WattHour);
        }

        /// <summary>
        /// creates energy from value in Wh
        /// </summary>
        /// <param name="value">Energy value in Wh</param>
        public static Energy FromWattHour(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Energy(value, EnergyUnits.WattHour);
        }

        public static Energy Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Energy));
            return new Energy(parseResult.Value, new EnergyUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public EnergyUnit Unit { get; }

        public static readonly EnergyUnit BaseUnit = EnergyUnits.Joule;

        public static readonly Energy Zero = new Energy(0, BaseUnit);

    }
}
