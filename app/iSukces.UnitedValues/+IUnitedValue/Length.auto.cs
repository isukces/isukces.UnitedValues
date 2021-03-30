// ReSharper disable All
// generator: BasicUnitValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(LengthJsonConverter))]
    public partial struct Length : IUnitedValue<LengthUnit>, IEquatable<Length>, IComparable<Length>, IFormattable
    {
        /// <summary>
        /// creates instance of Length
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Length(decimal value, [JetBrains.Annotations.NotNull] LengthUnit unit)
        {
            Value = value;
            if (unit is null)
                throw new NullReferenceException(nameof(unit));
            Unit = unit;
        }

        public int CompareTo(Length other)
        {
            return UnitedValuesUtils.Compare<Length, LengthUnit>(this, other);
        }

        public Length ConvertTo(LengthUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Length(basic / factor, newUnit);
        }

        public bool Equals(Length other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<LengthUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<LengthUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Length Round(int decimalPlaces)
        {
            return new Length(Math.Round(Value, decimalPlaces), Unit);
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
        public static Length operator -(Length value)
        {
            return new Length(-value.Value, value.Unit);
        }

        public static Length operator -(Length left, Length right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Length(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Length left, Length right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Length operator *(Length value, decimal number)
        {
            return new Length(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Length operator *(decimal number, Length value)
        {
            return new Length(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Length operator /(Length value, decimal number)
        {
            return new Length(value.Value / number, value.Unit);
        }

        public static decimal operator /(Length left, Length right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Length operator +(Length left, Length right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Length(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Length left, Length right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Length left, Length right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates length from value in cm
        /// </summary>
        /// <param name="value">Length value in cm</param>
        public static Length FromCentimeters(decimal value)
        {
            return new Length(value, LengthUnits.Cm);
        }

        /// <summary>
        /// creates length from value in cm
        /// </summary>
        /// <param name="value">Length value in cm</param>
        public static Length FromCentimeters(double value)
        {
            return new Length((decimal)value, LengthUnits.Cm);
        }

        /// <summary>
        /// creates length from value in cm
        /// </summary>
        /// <param name="value">Length value in cm</param>
        public static Length FromCentimeters(int value)
        {
            return new Length(value, LengthUnits.Cm);
        }

        /// <summary>
        /// creates length from value in cm
        /// </summary>
        /// <param name="value">Length value in cm</param>
        public static Length FromCentimeters(long value)
        {
            return new Length(value, LengthUnits.Cm);
        }

        /// <summary>
        /// creates length from value in dm
        /// </summary>
        /// <param name="value">Length value in dm</param>
        public static Length FromDecimeters(decimal value)
        {
            return new Length(value, LengthUnits.Dm);
        }

        /// <summary>
        /// creates length from value in dm
        /// </summary>
        /// <param name="value">Length value in dm</param>
        public static Length FromDecimeters(double value)
        {
            return new Length((decimal)value, LengthUnits.Dm);
        }

        /// <summary>
        /// creates length from value in dm
        /// </summary>
        /// <param name="value">Length value in dm</param>
        public static Length FromDecimeters(int value)
        {
            return new Length(value, LengthUnits.Dm);
        }

        /// <summary>
        /// creates length from value in dm
        /// </summary>
        /// <param name="value">Length value in dm</param>
        public static Length FromDecimeters(long value)
        {
            return new Length(value, LengthUnits.Dm);
        }

        /// <summary>
        /// creates length from value in fh
        /// </summary>
        /// <param name="value">Length value in fh</param>
        public static Length FromFathom(decimal value)
        {
            return new Length(value, LengthUnits.Fathom);
        }

        /// <summary>
        /// creates length from value in fh
        /// </summary>
        /// <param name="value">Length value in fh</param>
        public static Length FromFathom(double value)
        {
            return new Length((decimal)value, LengthUnits.Fathom);
        }

        /// <summary>
        /// creates length from value in fh
        /// </summary>
        /// <param name="value">Length value in fh</param>
        public static Length FromFathom(int value)
        {
            return new Length(value, LengthUnits.Fathom);
        }

        /// <summary>
        /// creates length from value in fh
        /// </summary>
        /// <param name="value">Length value in fh</param>
        public static Length FromFathom(long value)
        {
            return new Length(value, LengthUnits.Fathom);
        }

        /// <summary>
        /// creates length from value in ft
        /// </summary>
        /// <param name="value">Length value in ft</param>
        public static Length FromFoot(decimal value)
        {
            return new Length(value, LengthUnits.Feet);
        }

        /// <summary>
        /// creates length from value in ft
        /// </summary>
        /// <param name="value">Length value in ft</param>
        public static Length FromFoot(double value)
        {
            return new Length((decimal)value, LengthUnits.Feet);
        }

        /// <summary>
        /// creates length from value in ft
        /// </summary>
        /// <param name="value">Length value in ft</param>
        public static Length FromFoot(int value)
        {
            return new Length(value, LengthUnits.Feet);
        }

        /// <summary>
        /// creates length from value in ft
        /// </summary>
        /// <param name="value">Length value in ft</param>
        public static Length FromFoot(long value)
        {
            return new Length(value, LengthUnits.Feet);
        }

        /// <summary>
        /// creates length from value in fg
        /// </summary>
        /// <param name="value">Length value in fg</param>
        public static Length FromFurlongs(decimal value)
        {
            return new Length(value, LengthUnits.Furlong);
        }

        /// <summary>
        /// creates length from value in fg
        /// </summary>
        /// <param name="value">Length value in fg</param>
        public static Length FromFurlongs(double value)
        {
            return new Length((decimal)value, LengthUnits.Furlong);
        }

        /// <summary>
        /// creates length from value in fg
        /// </summary>
        /// <param name="value">Length value in fg</param>
        public static Length FromFurlongs(int value)
        {
            return new Length(value, LengthUnits.Furlong);
        }

        /// <summary>
        /// creates length from value in fg
        /// </summary>
        /// <param name="value">Length value in fg</param>
        public static Length FromFurlongs(long value)
        {
            return new Length(value, LengthUnits.Furlong);
        }

        /// <summary>
        /// creates length from value in inch
        /// </summary>
        /// <param name="value">Length value in inch</param>
        public static Length FromInches(decimal value)
        {
            return new Length(value, LengthUnits.Inch);
        }

        /// <summary>
        /// creates length from value in inch
        /// </summary>
        /// <param name="value">Length value in inch</param>
        public static Length FromInches(double value)
        {
            return new Length((decimal)value, LengthUnits.Inch);
        }

        /// <summary>
        /// creates length from value in inch
        /// </summary>
        /// <param name="value">Length value in inch</param>
        public static Length FromInches(int value)
        {
            return new Length(value, LengthUnits.Inch);
        }

        /// <summary>
        /// creates length from value in inch
        /// </summary>
        /// <param name="value">Length value in inch</param>
        public static Length FromInches(long value)
        {
            return new Length(value, LengthUnits.Inch);
        }

        /// <summary>
        /// creates length from value in km
        /// </summary>
        /// <param name="value">Length value in km</param>
        public static Length FromKilometers(decimal value)
        {
            return new Length(value, LengthUnits.Km);
        }

        /// <summary>
        /// creates length from value in km
        /// </summary>
        /// <param name="value">Length value in km</param>
        public static Length FromKilometers(double value)
        {
            return new Length((decimal)value, LengthUnits.Km);
        }

        /// <summary>
        /// creates length from value in km
        /// </summary>
        /// <param name="value">Length value in km</param>
        public static Length FromKilometers(int value)
        {
            return new Length(value, LengthUnits.Km);
        }

        /// <summary>
        /// creates length from value in km
        /// </summary>
        /// <param name="value">Length value in km</param>
        public static Length FromKilometers(long value)
        {
            return new Length(value, LengthUnits.Km);
        }

        /// <summary>
        /// creates length from value in m
        /// </summary>
        /// <param name="value">Length value in m</param>
        public static Length FromMeter(decimal value)
        {
            return new Length(value, LengthUnits.Meter);
        }

        /// <summary>
        /// creates length from value in m
        /// </summary>
        /// <param name="value">Length value in m</param>
        public static Length FromMeter(double value)
        {
            return new Length((decimal)value, LengthUnits.Meter);
        }

        /// <summary>
        /// creates length from value in m
        /// </summary>
        /// <param name="value">Length value in m</param>
        public static Length FromMeter(int value)
        {
            return new Length(value, LengthUnits.Meter);
        }

        /// <summary>
        /// creates length from value in m
        /// </summary>
        /// <param name="value">Length value in m</param>
        public static Length FromMeter(long value)
        {
            return new Length(value, LengthUnits.Meter);
        }

        /// <summary>
        /// creates length from value in mil
        /// </summary>
        /// <param name="value">Length value in mil</param>
        public static Length FromMiles(decimal value)
        {
            return new Length(value, LengthUnits.Mile);
        }

        /// <summary>
        /// creates length from value in mil
        /// </summary>
        /// <param name="value">Length value in mil</param>
        public static Length FromMiles(double value)
        {
            return new Length((decimal)value, LengthUnits.Mile);
        }

        /// <summary>
        /// creates length from value in mil
        /// </summary>
        /// <param name="value">Length value in mil</param>
        public static Length FromMiles(int value)
        {
            return new Length(value, LengthUnits.Mile);
        }

        /// <summary>
        /// creates length from value in mil
        /// </summary>
        /// <param name="value">Length value in mil</param>
        public static Length FromMiles(long value)
        {
            return new Length(value, LengthUnits.Mile);
        }

        /// <summary>
        /// creates length from value in mm
        /// </summary>
        /// <param name="value">Length value in mm</param>
        public static Length FromMilimeters(decimal value)
        {
            return new Length(value, LengthUnits.Mm);
        }

        /// <summary>
        /// creates length from value in mm
        /// </summary>
        /// <param name="value">Length value in mm</param>
        public static Length FromMilimeters(double value)
        {
            return new Length((decimal)value, LengthUnits.Mm);
        }

        /// <summary>
        /// creates length from value in mm
        /// </summary>
        /// <param name="value">Length value in mm</param>
        public static Length FromMilimeters(int value)
        {
            return new Length(value, LengthUnits.Mm);
        }

        /// <summary>
        /// creates length from value in mm
        /// </summary>
        /// <param name="value">Length value in mm</param>
        public static Length FromMilimeters(long value)
        {
            return new Length(value, LengthUnits.Mm);
        }

        /// <summary>
        /// creates length from value in nm
        /// </summary>
        /// <param name="value">Length value in nm</param>
        public static Length FromNauticalMiles(decimal value)
        {
            return new Length(value, LengthUnits.NauticalMile);
        }

        /// <summary>
        /// creates length from value in nm
        /// </summary>
        /// <param name="value">Length value in nm</param>
        public static Length FromNauticalMiles(double value)
        {
            return new Length((decimal)value, LengthUnits.NauticalMile);
        }

        /// <summary>
        /// creates length from value in nm
        /// </summary>
        /// <param name="value">Length value in nm</param>
        public static Length FromNauticalMiles(int value)
        {
            return new Length(value, LengthUnits.NauticalMile);
        }

        /// <summary>
        /// creates length from value in nm
        /// </summary>
        /// <param name="value">Length value in nm</param>
        public static Length FromNauticalMiles(long value)
        {
            return new Length(value, LengthUnits.NauticalMile);
        }

        /// <summary>
        /// creates length from value in yd
        /// </summary>
        /// <param name="value">Length value in yd</param>
        public static Length FromYards(decimal value)
        {
            return new Length(value, LengthUnits.Yard);
        }

        /// <summary>
        /// creates length from value in yd
        /// </summary>
        /// <param name="value">Length value in yd</param>
        public static Length FromYards(double value)
        {
            return new Length((decimal)value, LengthUnits.Yard);
        }

        /// <summary>
        /// creates length from value in yd
        /// </summary>
        /// <param name="value">Length value in yd</param>
        public static Length FromYards(int value)
        {
            return new Length(value, LengthUnits.Yard);
        }

        /// <summary>
        /// creates length from value in yd
        /// </summary>
        /// <param name="value">Length value in yd</param>
        public static Length FromYards(long value)
        {
            return new Length(value, LengthUnits.Yard);
        }

        public static Length Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Length));
            return new Length(parseResult.Value, new LengthUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public LengthUnit Unit { get; }

        public static readonly LengthUnit BaseUnit = LengthUnits.Meter;

        public static readonly Length Zero = new Length(0, BaseUnit);

    }
}
