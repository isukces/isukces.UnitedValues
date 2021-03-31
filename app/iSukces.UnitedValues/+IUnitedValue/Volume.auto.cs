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
    [JsonConverter(typeof(VolumeJsonConverter))]
    public partial struct Volume : IUnitedValue<VolumeUnit>, IEquatable<Volume>, IFormattable
    {
        /// <summary>
        /// creates instance of Volume
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Volume(decimal value, VolumeUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public Volume ConvertTo(VolumeUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Volume(basic / factor, newUnit);
        }

        public bool Equals(Volume other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<VolumeUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<VolumeUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Volume Round(int decimalPlaces)
        {
            return new Volume(Math.Round(Value, decimalPlaces), Unit);
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
        public static Volume operator -(Volume value)
        {
            return new Volume(-value.Value, value.Unit);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Volume(left.Value - right.Value, left.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Volume operator *(Volume value, decimal number)
        {
            return new Volume(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Volume operator *(decimal number, Volume value)
        {
            return new Volume(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Volume operator /(Volume value, decimal number)
        {
            return new Volume(value.Value / number, value.Unit);
        }

        public static decimal operator /(Volume left, Volume right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Volume operator +(Volume left, Volume right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Volume(left.Value + right.Value, left.Unit);
        }

        /// <summary>
        /// creates volume from value in cm³
        /// </summary>
        /// <param name="value">Volume value in cm³</param>
        public static Volume FromCubicCentimeters(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicCm);
        }

        /// <summary>
        /// creates volume from value in cm³
        /// </summary>
        /// <param name="value">Volume value in cm³</param>
        public static Volume FromCubicCentimeters(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicCm);
        }

        /// <summary>
        /// creates volume from value in cm³
        /// </summary>
        /// <param name="value">Volume value in cm³</param>
        public static Volume FromCubicCentimeters(int value)
        {
            return new Volume(value, VolumeUnits.CubicCm);
        }

        /// <summary>
        /// creates volume from value in cm³
        /// </summary>
        /// <param name="value">Volume value in cm³</param>
        public static Volume FromCubicCentimeters(long value)
        {
            return new Volume(value, VolumeUnits.CubicCm);
        }

        /// <summary>
        /// creates volume from value in dm³
        /// </summary>
        /// <param name="value">Volume value in dm³</param>
        public static Volume FromCubicDecimeters(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicDm);
        }

        /// <summary>
        /// creates volume from value in dm³
        /// </summary>
        /// <param name="value">Volume value in dm³</param>
        public static Volume FromCubicDecimeters(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicDm);
        }

        /// <summary>
        /// creates volume from value in dm³
        /// </summary>
        /// <param name="value">Volume value in dm³</param>
        public static Volume FromCubicDecimeters(int value)
        {
            return new Volume(value, VolumeUnits.CubicDm);
        }

        /// <summary>
        /// creates volume from value in dm³
        /// </summary>
        /// <param name="value">Volume value in dm³</param>
        public static Volume FromCubicDecimeters(long value)
        {
            return new Volume(value, VolumeUnits.CubicDm);
        }

        /// <summary>
        /// creates volume from value in fh³
        /// </summary>
        /// <param name="value">Volume value in fh³</param>
        public static Volume FromCubicFathom(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicFathom);
        }

        /// <summary>
        /// creates volume from value in fh³
        /// </summary>
        /// <param name="value">Volume value in fh³</param>
        public static Volume FromCubicFathom(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicFathom);
        }

        /// <summary>
        /// creates volume from value in fh³
        /// </summary>
        /// <param name="value">Volume value in fh³</param>
        public static Volume FromCubicFathom(int value)
        {
            return new Volume(value, VolumeUnits.CubicFathom);
        }

        /// <summary>
        /// creates volume from value in fh³
        /// </summary>
        /// <param name="value">Volume value in fh³</param>
        public static Volume FromCubicFathom(long value)
        {
            return new Volume(value, VolumeUnits.CubicFathom);
        }

        /// <summary>
        /// creates volume from value in ft³
        /// </summary>
        /// <param name="value">Volume value in ft³</param>
        public static Volume FromCubicFoot(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicFeet);
        }

        /// <summary>
        /// creates volume from value in ft³
        /// </summary>
        /// <param name="value">Volume value in ft³</param>
        public static Volume FromCubicFoot(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicFeet);
        }

        /// <summary>
        /// creates volume from value in ft³
        /// </summary>
        /// <param name="value">Volume value in ft³</param>
        public static Volume FromCubicFoot(int value)
        {
            return new Volume(value, VolumeUnits.CubicFeet);
        }

        /// <summary>
        /// creates volume from value in ft³
        /// </summary>
        /// <param name="value">Volume value in ft³</param>
        public static Volume FromCubicFoot(long value)
        {
            return new Volume(value, VolumeUnits.CubicFeet);
        }

        /// <summary>
        /// creates volume from value in fg³
        /// </summary>
        /// <param name="value">Volume value in fg³</param>
        public static Volume FromCubicFurlongs(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicFurlong);
        }

        /// <summary>
        /// creates volume from value in fg³
        /// </summary>
        /// <param name="value">Volume value in fg³</param>
        public static Volume FromCubicFurlongs(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicFurlong);
        }

        /// <summary>
        /// creates volume from value in fg³
        /// </summary>
        /// <param name="value">Volume value in fg³</param>
        public static Volume FromCubicFurlongs(int value)
        {
            return new Volume(value, VolumeUnits.CubicFurlong);
        }

        /// <summary>
        /// creates volume from value in fg³
        /// </summary>
        /// <param name="value">Volume value in fg³</param>
        public static Volume FromCubicFurlongs(long value)
        {
            return new Volume(value, VolumeUnits.CubicFurlong);
        }

        /// <summary>
        /// creates volume from value in inch³
        /// </summary>
        /// <param name="value">Volume value in inch³</param>
        public static Volume FromCubicInches(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicInch);
        }

        /// <summary>
        /// creates volume from value in inch³
        /// </summary>
        /// <param name="value">Volume value in inch³</param>
        public static Volume FromCubicInches(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicInch);
        }

        /// <summary>
        /// creates volume from value in inch³
        /// </summary>
        /// <param name="value">Volume value in inch³</param>
        public static Volume FromCubicInches(int value)
        {
            return new Volume(value, VolumeUnits.CubicInch);
        }

        /// <summary>
        /// creates volume from value in inch³
        /// </summary>
        /// <param name="value">Volume value in inch³</param>
        public static Volume FromCubicInches(long value)
        {
            return new Volume(value, VolumeUnits.CubicInch);
        }

        /// <summary>
        /// creates volume from value in km³
        /// </summary>
        /// <param name="value">Volume value in km³</param>
        public static Volume FromCubicKilometers(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicKm);
        }

        /// <summary>
        /// creates volume from value in km³
        /// </summary>
        /// <param name="value">Volume value in km³</param>
        public static Volume FromCubicKilometers(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicKm);
        }

        /// <summary>
        /// creates volume from value in km³
        /// </summary>
        /// <param name="value">Volume value in km³</param>
        public static Volume FromCubicKilometers(int value)
        {
            return new Volume(value, VolumeUnits.CubicKm);
        }

        /// <summary>
        /// creates volume from value in km³
        /// </summary>
        /// <param name="value">Volume value in km³</param>
        public static Volume FromCubicKilometers(long value)
        {
            return new Volume(value, VolumeUnits.CubicKm);
        }

        /// <summary>
        /// creates volume from value in m³
        /// </summary>
        /// <param name="value">Volume value in m³</param>
        public static Volume FromCubicMeter(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicMeter);
        }

        /// <summary>
        /// creates volume from value in m³
        /// </summary>
        /// <param name="value">Volume value in m³</param>
        public static Volume FromCubicMeter(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicMeter);
        }

        /// <summary>
        /// creates volume from value in m³
        /// </summary>
        /// <param name="value">Volume value in m³</param>
        public static Volume FromCubicMeter(int value)
        {
            return new Volume(value, VolumeUnits.CubicMeter);
        }

        /// <summary>
        /// creates volume from value in m³
        /// </summary>
        /// <param name="value">Volume value in m³</param>
        public static Volume FromCubicMeter(long value)
        {
            return new Volume(value, VolumeUnits.CubicMeter);
        }

        /// <summary>
        /// creates volume from value in mil³
        /// </summary>
        /// <param name="value">Volume value in mil³</param>
        public static Volume FromCubicMiles(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicMile);
        }

        /// <summary>
        /// creates volume from value in mil³
        /// </summary>
        /// <param name="value">Volume value in mil³</param>
        public static Volume FromCubicMiles(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicMile);
        }

        /// <summary>
        /// creates volume from value in mil³
        /// </summary>
        /// <param name="value">Volume value in mil³</param>
        public static Volume FromCubicMiles(int value)
        {
            return new Volume(value, VolumeUnits.CubicMile);
        }

        /// <summary>
        /// creates volume from value in mil³
        /// </summary>
        /// <param name="value">Volume value in mil³</param>
        public static Volume FromCubicMiles(long value)
        {
            return new Volume(value, VolumeUnits.CubicMile);
        }

        /// <summary>
        /// creates volume from value in mm³
        /// </summary>
        /// <param name="value">Volume value in mm³</param>
        public static Volume FromCubicMilimeters(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicMm);
        }

        /// <summary>
        /// creates volume from value in mm³
        /// </summary>
        /// <param name="value">Volume value in mm³</param>
        public static Volume FromCubicMilimeters(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicMm);
        }

        /// <summary>
        /// creates volume from value in mm³
        /// </summary>
        /// <param name="value">Volume value in mm³</param>
        public static Volume FromCubicMilimeters(int value)
        {
            return new Volume(value, VolumeUnits.CubicMm);
        }

        /// <summary>
        /// creates volume from value in mm³
        /// </summary>
        /// <param name="value">Volume value in mm³</param>
        public static Volume FromCubicMilimeters(long value)
        {
            return new Volume(value, VolumeUnits.CubicMm);
        }

        /// <summary>
        /// creates volume from value in nm³
        /// </summary>
        /// <param name="value">Volume value in nm³</param>
        public static Volume FromCubicNauticalMiles(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicNauticalMile);
        }

        /// <summary>
        /// creates volume from value in nm³
        /// </summary>
        /// <param name="value">Volume value in nm³</param>
        public static Volume FromCubicNauticalMiles(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicNauticalMile);
        }

        /// <summary>
        /// creates volume from value in nm³
        /// </summary>
        /// <param name="value">Volume value in nm³</param>
        public static Volume FromCubicNauticalMiles(int value)
        {
            return new Volume(value, VolumeUnits.CubicNauticalMile);
        }

        /// <summary>
        /// creates volume from value in nm³
        /// </summary>
        /// <param name="value">Volume value in nm³</param>
        public static Volume FromCubicNauticalMiles(long value)
        {
            return new Volume(value, VolumeUnits.CubicNauticalMile);
        }

        /// <summary>
        /// creates volume from value in yd³
        /// </summary>
        /// <param name="value">Volume value in yd³</param>
        public static Volume FromCubicYards(decimal value)
        {
            return new Volume(value, VolumeUnits.CubicYard);
        }

        /// <summary>
        /// creates volume from value in yd³
        /// </summary>
        /// <param name="value">Volume value in yd³</param>
        public static Volume FromCubicYards(double value)
        {
            return new Volume((decimal)value, VolumeUnits.CubicYard);
        }

        /// <summary>
        /// creates volume from value in yd³
        /// </summary>
        /// <param name="value">Volume value in yd³</param>
        public static Volume FromCubicYards(int value)
        {
            return new Volume(value, VolumeUnits.CubicYard);
        }

        /// <summary>
        /// creates volume from value in yd³
        /// </summary>
        /// <param name="value">Volume value in yd³</param>
        public static Volume FromCubicYards(long value)
        {
            return new Volume(value, VolumeUnits.CubicYard);
        }

        public static Volume Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Volume));
            return new Volume(parseResult.Value, new VolumeUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public VolumeUnit Unit { get; }

        public static readonly VolumeUnit BaseUnit = VolumeUnits.CubicMeter;

        public static readonly Volume Zero = new Volume(0, BaseUnit);

    }
}
