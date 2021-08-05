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
    [JsonConverter(typeof(PressureJsonConverter))]
    public partial struct Pressure : IUnitedValue<PressureUnit>, IEquatable<Pressure>, IComparable<Pressure>, IFormattable
    {
        /// <summary>
        /// creates instance of Pressure
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Pressure(decimal value, PressureUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(Pressure other)
        {
            return UnitedValuesUtils.Compare<Pressure, PressureUnit>(this, other);
        }

        public Pressure ConvertTo(PressureUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Pressure(basic / factor, newUnit);
        }

        public bool Equals(Pressure other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<PressureUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<PressureUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Pressure Round(int decimalPlaces)
        {
            return new Pressure(Math.Round(Value, decimalPlaces), Unit);
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
        public static Pressure operator -(Pressure value)
        {
            return new Pressure(-value.Value, value.Unit);
        }

        public static Pressure operator -(Pressure left, Pressure right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Pressure(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Pressure left, Pressure right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Pressure operator *(Pressure value, decimal number)
        {
            return new Pressure(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Pressure operator *(decimal number, Pressure value)
        {
            return new Pressure(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Pressure operator /(Pressure value, decimal number)
        {
            return new Pressure(value.Value / number, value.Unit);
        }

        public static decimal operator /(Pressure left, Pressure right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Pressure operator +(Pressure left, Pressure right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Pressure(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Pressure left, Pressure right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Pressure left, Pressure right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Pressure left, Pressure right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Pressure left, Pressure right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates pressure from value in GPa
        /// </summary>
        /// <param name="value">Pressure value in GPa</param>
        public static Pressure FromGigaPascal(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.GigaPascal);
        }

        /// <summary>
        /// creates pressure from value in GPa
        /// </summary>
        /// <param name="value">Pressure value in GPa</param>
        public static Pressure FromGigaPascal(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure((decimal)value, PressureUnits.GigaPascal);
        }

        /// <summary>
        /// creates pressure from value in GPa
        /// </summary>
        /// <param name="value">Pressure value in GPa</param>
        public static Pressure FromGigaPascal(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.GigaPascal);
        }

        /// <summary>
        /// creates pressure from value in GPa
        /// </summary>
        /// <param name="value">Pressure value in GPa</param>
        public static Pressure FromGigaPascal(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.GigaPascal);
        }

        /// <summary>
        /// creates pressure from value in hPa
        /// </summary>
        /// <param name="value">Pressure value in hPa</param>
        public static Pressure FromHectoPascal(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.HectoPascal);
        }

        /// <summary>
        /// creates pressure from value in hPa
        /// </summary>
        /// <param name="value">Pressure value in hPa</param>
        public static Pressure FromHectoPascal(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure((decimal)value, PressureUnits.HectoPascal);
        }

        /// <summary>
        /// creates pressure from value in hPa
        /// </summary>
        /// <param name="value">Pressure value in hPa</param>
        public static Pressure FromHectoPascal(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.HectoPascal);
        }

        /// <summary>
        /// creates pressure from value in hPa
        /// </summary>
        /// <param name="value">Pressure value in hPa</param>
        public static Pressure FromHectoPascal(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.HectoPascal);
        }

        /// <summary>
        /// creates pressure from value in kPa
        /// </summary>
        /// <param name="value">Pressure value in kPa</param>
        public static Pressure FromKiloPascal(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.KiloPascal);
        }

        /// <summary>
        /// creates pressure from value in kPa
        /// </summary>
        /// <param name="value">Pressure value in kPa</param>
        public static Pressure FromKiloPascal(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure((decimal)value, PressureUnits.KiloPascal);
        }

        /// <summary>
        /// creates pressure from value in kPa
        /// </summary>
        /// <param name="value">Pressure value in kPa</param>
        public static Pressure FromKiloPascal(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.KiloPascal);
        }

        /// <summary>
        /// creates pressure from value in kPa
        /// </summary>
        /// <param name="value">Pressure value in kPa</param>
        public static Pressure FromKiloPascal(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.KiloPascal);
        }

        /// <summary>
        /// creates pressure from value in MPa
        /// </summary>
        /// <param name="value">Pressure value in MPa</param>
        public static Pressure FromMegaPascal(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.MegaPascal);
        }

        /// <summary>
        /// creates pressure from value in MPa
        /// </summary>
        /// <param name="value">Pressure value in MPa</param>
        public static Pressure FromMegaPascal(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure((decimal)value, PressureUnits.MegaPascal);
        }

        /// <summary>
        /// creates pressure from value in MPa
        /// </summary>
        /// <param name="value">Pressure value in MPa</param>
        public static Pressure FromMegaPascal(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.MegaPascal);
        }

        /// <summary>
        /// creates pressure from value in MPa
        /// </summary>
        /// <param name="value">Pressure value in MPa</param>
        public static Pressure FromMegaPascal(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.MegaPascal);
        }

        /// <summary>
        /// creates pressure from value in Pa
        /// </summary>
        /// <param name="value">Pressure value in Pa</param>
        public static Pressure FromPascal(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.Pascal);
        }

        /// <summary>
        /// creates pressure from value in Pa
        /// </summary>
        /// <param name="value">Pressure value in Pa</param>
        public static Pressure FromPascal(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure((decimal)value, PressureUnits.Pascal);
        }

        /// <summary>
        /// creates pressure from value in Pa
        /// </summary>
        /// <param name="value">Pressure value in Pa</param>
        public static Pressure FromPascal(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.Pascal);
        }

        /// <summary>
        /// creates pressure from value in Pa
        /// </summary>
        /// <param name="value">Pressure value in Pa</param>
        public static Pressure FromPascal(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Pressure(value, PressureUnits.Pascal);
        }

        public static Pressure Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Pressure));
            return new Pressure(parseResult.Value, new PressureUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public PressureUnit Unit { get; }

        public static readonly PressureUnit BaseUnit = PressureUnits.Pascal;

        public static readonly Pressure Zero = new Pressure(0, BaseUnit);

    }
}
