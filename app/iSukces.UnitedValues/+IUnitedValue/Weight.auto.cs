// ReSharper disable All
// generator: BasicUnitValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(WeightJsonConverter))]
    public partial struct Weight : IUnitedValue<WeightUnit>, IEquatable<Weight>, IComparable<Weight>, IFormattable
    {
        /// <summary>
        /// creates instance of Weight
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Weight(decimal value, WeightUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public int CompareTo(Weight other)
        {
            return UnitedValuesUtils.Compare<Weight, WeightUnit>(this, other);
        }

        public Weight ConvertTo(WeightUnit newUnit)
        {
            // generator : BasicUnitValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Weight(basic / factor, newUnit);
        }

        public bool Equals(Weight other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<WeightUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<WeightUnit> unitedValue ? Equals(unitedValue) : false;
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
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public Weight Round(int decimalPlaces)
        {
            return new Weight(Math.Round(Value, decimalPlaces), Unit);
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
        public static Weight operator -(Weight value)
        {
            return new Weight(-value.Value, value.Unit);
        }

        public static Weight operator -(Weight left, Weight right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Weight(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Weight left, Weight right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Weight operator *(Weight value, decimal number)
        {
            return new Weight(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Weight operator *(decimal number, Weight value)
        {
            return new Weight(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Weight operator /(Weight value, decimal number)
        {
            return new Weight(value.Value / number, value.Unit);
        }

        public static decimal operator /(Weight left, Weight right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Weight operator +(Weight left, Weight right)
        {
            // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Weight(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Weight left, Weight right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Weight left, Weight right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Weight left, Weight right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Weight left, Weight right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Weight left, Weight right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates weight from value in g
        /// </summary>
        /// <param name="value">Weight value in g</param>
        public static Weight FromGrams(decimal value)
        {
            return new Weight(value, WeightUnits.Gram);
        }

        /// <summary>
        /// creates weight from value in g
        /// </summary>
        /// <param name="value">Weight value in g</param>
        public static Weight FromGrams(double value)
        {
            return new Weight((decimal)value, WeightUnits.Gram);
        }

        /// <summary>
        /// creates weight from value in g
        /// </summary>
        /// <param name="value">Weight value in g</param>
        public static Weight FromGrams(int value)
        {
            return new Weight(value, WeightUnits.Gram);
        }

        /// <summary>
        /// creates weight from value in g
        /// </summary>
        /// <param name="value">Weight value in g</param>
        public static Weight FromGrams(long value)
        {
            return new Weight(value, WeightUnits.Gram);
        }

        /// <summary>
        /// creates weight from value in kg
        /// </summary>
        /// <param name="value">Weight value in kg</param>
        public static Weight FromKg(decimal value)
        {
            return new Weight(value, WeightUnits.Kg);
        }

        /// <summary>
        /// creates weight from value in kg
        /// </summary>
        /// <param name="value">Weight value in kg</param>
        public static Weight FromKg(double value)
        {
            return new Weight((decimal)value, WeightUnits.Kg);
        }

        /// <summary>
        /// creates weight from value in kg
        /// </summary>
        /// <param name="value">Weight value in kg</param>
        public static Weight FromKg(int value)
        {
            return new Weight(value, WeightUnits.Kg);
        }

        /// <summary>
        /// creates weight from value in kg
        /// </summary>
        /// <param name="value">Weight value in kg</param>
        public static Weight FromKg(long value)
        {
            return new Weight(value, WeightUnits.Kg);
        }

        /// <summary>
        /// creates weight from value in t
        /// </summary>
        /// <param name="value">Weight value in t</param>
        public static Weight FromTons(decimal value)
        {
            return new Weight(value, WeightUnits.Tone);
        }

        /// <summary>
        /// creates weight from value in t
        /// </summary>
        /// <param name="value">Weight value in t</param>
        public static Weight FromTons(double value)
        {
            return new Weight((decimal)value, WeightUnits.Tone);
        }

        /// <summary>
        /// creates weight from value in t
        /// </summary>
        /// <param name="value">Weight value in t</param>
        public static Weight FromTons(int value)
        {
            return new Weight(value, WeightUnits.Tone);
        }

        /// <summary>
        /// creates weight from value in t
        /// </summary>
        /// <param name="value">Weight value in t</param>
        public static Weight FromTons(long value)
        {
            return new Weight(value, WeightUnits.Tone);
        }

        public static Weight Parse(string value)
        {
            // generator : BasicUnitValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Weight));
            return new Weight(parseResult.Value, new WeightUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public WeightUnit Unit { get; }

        public static readonly WeightUnit BaseUnit = WeightUnits.Kg;

        public static readonly Weight Zero = new Weight(0, BaseUnit);

    }
}
