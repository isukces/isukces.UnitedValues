// ReSharper disable All
// generator: BasicUnitedValuesGenerator
using Newtonsoft.Json;
using System;
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
            Unit = unit;
        }

        public Area ConvertTo(AreaUnit newUnit)
        {
            // generator : BasicUnitedValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Area(basic / factor, newUnit);
        }

        public bool Equals(Area other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<AreaUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<AreaUnit> unitedValue ? Equals(unitedValue) : false;
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
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
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
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Area operator +(Area left, Area right)
        {
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Area(left.Value + right.Value, left.Unit);
        }

        public static Area Parse(string value)
        {
            // generator : BasicUnitedValuesGenerator.Add_Parse
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
