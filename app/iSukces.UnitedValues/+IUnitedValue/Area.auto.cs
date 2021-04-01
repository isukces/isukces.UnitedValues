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
    [JsonConverter(typeof(AreaJsonConverter))]
    public partial struct Area : IUnitedValue<AreaUnit>, IEquatable<Area>, IFormattable
    {
        /// <summary>
        /// creates instance of Area
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Area(decimal value, AreaUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public Area ConvertTo(AreaUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Area(basic / factor, newUnit);
        }

        public bool Equals(Area other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<AreaUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<AreaUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Area Round(int decimalPlaces)
        {
            return new Area(Math.Round(Value, decimalPlaces), Unit);
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
        public static Area operator -(Area value)
        {
            return new Area(-value.Value, value.Unit);
        }

        public static Area operator -(Area left, Area right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Area(left.Value - right.Value, left.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Area operator *(Area value, decimal number)
        {
            return new Area(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Area operator *(decimal number, Area value)
        {
            return new Area(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Area operator /(Area value, decimal number)
        {
            return new Area(value.Value / number, value.Unit);
        }

        public static decimal operator /(Area left, Area right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Area operator +(Area left, Area right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Area(left.Value + right.Value, left.Unit);
        }

        /// <summary>
        /// creates area from value in cm²
        /// </summary>
        /// <param name="value">Area value in cm²</param>
        public static Area FromSquareCentimeters(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareCm);
        }

        /// <summary>
        /// creates area from value in cm²
        /// </summary>
        /// <param name="value">Area value in cm²</param>
        public static Area FromSquareCentimeters(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareCm);
        }

        /// <summary>
        /// creates area from value in cm²
        /// </summary>
        /// <param name="value">Area value in cm²</param>
        public static Area FromSquareCentimeters(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareCm);
        }

        /// <summary>
        /// creates area from value in cm²
        /// </summary>
        /// <param name="value">Area value in cm²</param>
        public static Area FromSquareCentimeters(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareCm);
        }

        /// <summary>
        /// creates area from value in dm²
        /// </summary>
        /// <param name="value">Area value in dm²</param>
        public static Area FromSquareDecimeters(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareDm);
        }

        /// <summary>
        /// creates area from value in dm²
        /// </summary>
        /// <param name="value">Area value in dm²</param>
        public static Area FromSquareDecimeters(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareDm);
        }

        /// <summary>
        /// creates area from value in dm²
        /// </summary>
        /// <param name="value">Area value in dm²</param>
        public static Area FromSquareDecimeters(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareDm);
        }

        /// <summary>
        /// creates area from value in dm²
        /// </summary>
        /// <param name="value">Area value in dm²</param>
        public static Area FromSquareDecimeters(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareDm);
        }

        /// <summary>
        /// creates area from value in fh²
        /// </summary>
        /// <param name="value">Area value in fh²</param>
        public static Area FromSquareFathom(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFathom);
        }

        /// <summary>
        /// creates area from value in fh²
        /// </summary>
        /// <param name="value">Area value in fh²</param>
        public static Area FromSquareFathom(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareFathom);
        }

        /// <summary>
        /// creates area from value in fh²
        /// </summary>
        /// <param name="value">Area value in fh²</param>
        public static Area FromSquareFathom(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFathom);
        }

        /// <summary>
        /// creates area from value in fh²
        /// </summary>
        /// <param name="value">Area value in fh²</param>
        public static Area FromSquareFathom(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFathom);
        }

        /// <summary>
        /// creates area from value in ft²
        /// </summary>
        /// <param name="value">Area value in ft²</param>
        public static Area FromSquareFoot(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFeet);
        }

        /// <summary>
        /// creates area from value in ft²
        /// </summary>
        /// <param name="value">Area value in ft²</param>
        public static Area FromSquareFoot(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareFeet);
        }

        /// <summary>
        /// creates area from value in ft²
        /// </summary>
        /// <param name="value">Area value in ft²</param>
        public static Area FromSquareFoot(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFeet);
        }

        /// <summary>
        /// creates area from value in ft²
        /// </summary>
        /// <param name="value">Area value in ft²</param>
        public static Area FromSquareFoot(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFeet);
        }

        /// <summary>
        /// creates area from value in fg²
        /// </summary>
        /// <param name="value">Area value in fg²</param>
        public static Area FromSquareFurlongs(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFurlong);
        }

        /// <summary>
        /// creates area from value in fg²
        /// </summary>
        /// <param name="value">Area value in fg²</param>
        public static Area FromSquareFurlongs(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareFurlong);
        }

        /// <summary>
        /// creates area from value in fg²
        /// </summary>
        /// <param name="value">Area value in fg²</param>
        public static Area FromSquareFurlongs(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFurlong);
        }

        /// <summary>
        /// creates area from value in fg²
        /// </summary>
        /// <param name="value">Area value in fg²</param>
        public static Area FromSquareFurlongs(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareFurlong);
        }

        /// <summary>
        /// creates area from value in inch²
        /// </summary>
        /// <param name="value">Area value in inch²</param>
        public static Area FromSquareInches(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareInch);
        }

        /// <summary>
        /// creates area from value in inch²
        /// </summary>
        /// <param name="value">Area value in inch²</param>
        public static Area FromSquareInches(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareInch);
        }

        /// <summary>
        /// creates area from value in inch²
        /// </summary>
        /// <param name="value">Area value in inch²</param>
        public static Area FromSquareInches(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareInch);
        }

        /// <summary>
        /// creates area from value in inch²
        /// </summary>
        /// <param name="value">Area value in inch²</param>
        public static Area FromSquareInches(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareInch);
        }

        /// <summary>
        /// creates area from value in km²
        /// </summary>
        /// <param name="value">Area value in km²</param>
        public static Area FromSquareKilometers(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareKm);
        }

        /// <summary>
        /// creates area from value in km²
        /// </summary>
        /// <param name="value">Area value in km²</param>
        public static Area FromSquareKilometers(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareKm);
        }

        /// <summary>
        /// creates area from value in km²
        /// </summary>
        /// <param name="value">Area value in km²</param>
        public static Area FromSquareKilometers(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareKm);
        }

        /// <summary>
        /// creates area from value in km²
        /// </summary>
        /// <param name="value">Area value in km²</param>
        public static Area FromSquareKilometers(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareKm);
        }

        /// <summary>
        /// creates area from value in m²
        /// </summary>
        /// <param name="value">Area value in m²</param>
        public static Area FromSquareMeter(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMeter);
        }

        /// <summary>
        /// creates area from value in m²
        /// </summary>
        /// <param name="value">Area value in m²</param>
        public static Area FromSquareMeter(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareMeter);
        }

        /// <summary>
        /// creates area from value in m²
        /// </summary>
        /// <param name="value">Area value in m²</param>
        public static Area FromSquareMeter(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMeter);
        }

        /// <summary>
        /// creates area from value in m²
        /// </summary>
        /// <param name="value">Area value in m²</param>
        public static Area FromSquareMeter(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMeter);
        }

        /// <summary>
        /// creates area from value in mil²
        /// </summary>
        /// <param name="value">Area value in mil²</param>
        public static Area FromSquareMiles(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMile);
        }

        /// <summary>
        /// creates area from value in mil²
        /// </summary>
        /// <param name="value">Area value in mil²</param>
        public static Area FromSquareMiles(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareMile);
        }

        /// <summary>
        /// creates area from value in mil²
        /// </summary>
        /// <param name="value">Area value in mil²</param>
        public static Area FromSquareMiles(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMile);
        }

        /// <summary>
        /// creates area from value in mil²
        /// </summary>
        /// <param name="value">Area value in mil²</param>
        public static Area FromSquareMiles(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMile);
        }

        /// <summary>
        /// creates area from value in mm²
        /// </summary>
        /// <param name="value">Area value in mm²</param>
        public static Area FromSquareMilimeters(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMm);
        }

        /// <summary>
        /// creates area from value in mm²
        /// </summary>
        /// <param name="value">Area value in mm²</param>
        public static Area FromSquareMilimeters(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareMm);
        }

        /// <summary>
        /// creates area from value in mm²
        /// </summary>
        /// <param name="value">Area value in mm²</param>
        public static Area FromSquareMilimeters(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMm);
        }

        /// <summary>
        /// creates area from value in mm²
        /// </summary>
        /// <param name="value">Area value in mm²</param>
        public static Area FromSquareMilimeters(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareMm);
        }

        /// <summary>
        /// creates area from value in nm²
        /// </summary>
        /// <param name="value">Area value in nm²</param>
        public static Area FromSquareNauticalMiles(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareNauticalMile);
        }

        /// <summary>
        /// creates area from value in nm²
        /// </summary>
        /// <param name="value">Area value in nm²</param>
        public static Area FromSquareNauticalMiles(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareNauticalMile);
        }

        /// <summary>
        /// creates area from value in nm²
        /// </summary>
        /// <param name="value">Area value in nm²</param>
        public static Area FromSquareNauticalMiles(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareNauticalMile);
        }

        /// <summary>
        /// creates area from value in nm²
        /// </summary>
        /// <param name="value">Area value in nm²</param>
        public static Area FromSquareNauticalMiles(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareNauticalMile);
        }

        /// <summary>
        /// creates area from value in yd²
        /// </summary>
        /// <param name="value">Area value in yd²</param>
        public static Area FromSquareYards(decimal value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareYard);
        }

        /// <summary>
        /// creates area from value in yd²
        /// </summary>
        /// <param name="value">Area value in yd²</param>
        public static Area FromSquareYards(double value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area((decimal)value, AreaUnits.SquareYard);
        }

        /// <summary>
        /// creates area from value in yd²
        /// </summary>
        /// <param name="value">Area value in yd²</param>
        public static Area FromSquareYards(int value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareYard);
        }

        /// <summary>
        /// creates area from value in yd²
        /// </summary>
        /// <param name="value">Area value in yd²</param>
        public static Area FromSquareYards(long value)
        {
            // generator : BasicUnitValuesGenerator.Add_FromMethods
            return new Area(value, AreaUnits.SquareYard);
        }

        public static Area Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Area));
            return new Area(parseResult.Value, new AreaUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public AreaUnit Unit { get; }

        public static readonly AreaUnit BaseUnit = AreaUnits.SquareMeter;

        public static readonly Area Zero = new Area(0, BaseUnit);

    }
}
