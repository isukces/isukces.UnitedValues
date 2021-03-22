// ReSharper disable All
// generator: BasicUnitedValuesGenerator
using Newtonsoft.Json;
using System;
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
            Unit = unit;
        }

        public Volume ConvertTo(VolumeUnit newUnit)
        {
            // generator : BasicUnitedValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.Get(newUnit);
            if (factor is null)
                throw new Exception("Unable to find multiplication for unit " + newUnit);
            return new Volume(basic / factor.Value, newUnit);
        }

        public bool Equals(Volume other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<VolumeUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<VolumeUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            // generator : BasicUnitedValuesGenerator.Add_GetBaseUnitValue
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
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
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
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
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
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Volume operator +(Volume left, Volume right)
        {
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Volume(left.Value + right.Value, left.Unit);
        }

        public static Volume Parse(string value)
        {
            // generator : BasicUnitedValuesGenerator.Add_Parse
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
