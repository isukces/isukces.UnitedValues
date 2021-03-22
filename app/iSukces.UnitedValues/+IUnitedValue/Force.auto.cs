// ReSharper disable All
// generator: BasicUnitedValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(ForceJsonConverter))]
    public partial struct Force : IUnitedValue<ForceUnit>, IEquatable<Force>, IComparable<Force>, IFormattable
    {
        /// <summary>
        /// creates instance of Force
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Force(decimal value, ForceUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public int CompareTo(Force other)
        {
            return UnitedValuesUtils.Compare<Force, ForceUnit>(this, other);
        }

        public Force ConvertTo(ForceUnit newUnit)
        {
            // generator : BasicUnitedValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            return new Force(basic / factor, newUnit);
        }

        public bool Equals(Force other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<ForceUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<ForceUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Force Round(int decimalPlaces)
        {
            return new Force(Math.Round(Value, decimalPlaces), Unit);
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
        public static Force operator -(Force value)
        {
            return new Force(-value.Value, value.Unit);
        }

        public static Force operator -(Force left, Force right)
        {
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return -right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Force(left.Value - right.Value, left.Unit);
        }

        public static bool operator !=(Force left, Force right)
        {
            return left.CompareTo(right) != 0;
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Force operator *(Force value, decimal number)
        {
            return new Force(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements * operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static Force operator *(decimal number, Force value)
        {
            return new Force(value.Value * number, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        public static Force operator /(Force value, decimal number)
        {
            return new Force(value.Value / number, value.Unit);
        }

        public static decimal operator /(Force left, Force right)
        {
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            right = right.ConvertTo(left.Unit);
            return left.Value / right.Value;
        }

        public static Force operator +(Force left, Force right)
        {
            // generator : BasicUnitedValuesGenerator.Add_Algebra
            if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit.UnitName))
                return right;
            if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit.UnitName))
                return left;
            right = right.ConvertTo(left.Unit);
            return new Force(left.Value + right.Value, left.Unit);
        }

        public static bool operator <(Force left, Force right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Force left, Force right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Force left, Force right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator >(Force left, Force right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Force left, Force right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// creates force from value in kN
        /// </summary>
        /// <param name="value">Force value in kN</param>
        public static Force FromKiloNewton(decimal value)
        {
            return new Force(value, ForceUnits.KiloNewton);
        }

        /// <summary>
        /// creates force from value in kN
        /// </summary>
        /// <param name="value">Force value in kN</param>
        public static Force FromKiloNewton(double value)
        {
            return new Force((decimal)value, ForceUnits.KiloNewton);
        }

        /// <summary>
        /// creates force from value in kN
        /// </summary>
        /// <param name="value">Force value in kN</param>
        public static Force FromKiloNewton(int value)
        {
            return new Force(value, ForceUnits.KiloNewton);
        }

        /// <summary>
        /// creates force from value in kN
        /// </summary>
        /// <param name="value">Force value in kN</param>
        public static Force FromKiloNewton(long value)
        {
            return new Force(value, ForceUnits.KiloNewton);
        }

        /// <summary>
        /// creates force from value in MN
        /// </summary>
        /// <param name="value">Force value in MN</param>
        public static Force FromMegaNewton(decimal value)
        {
            return new Force(value, ForceUnits.MegaNewton);
        }

        /// <summary>
        /// creates force from value in MN
        /// </summary>
        /// <param name="value">Force value in MN</param>
        public static Force FromMegaNewton(double value)
        {
            return new Force((decimal)value, ForceUnits.MegaNewton);
        }

        /// <summary>
        /// creates force from value in MN
        /// </summary>
        /// <param name="value">Force value in MN</param>
        public static Force FromMegaNewton(int value)
        {
            return new Force(value, ForceUnits.MegaNewton);
        }

        /// <summary>
        /// creates force from value in MN
        /// </summary>
        /// <param name="value">Force value in MN</param>
        public static Force FromMegaNewton(long value)
        {
            return new Force(value, ForceUnits.MegaNewton);
        }

        /// <summary>
        /// creates force from value in mN
        /// </summary>
        /// <param name="value">Force value in mN</param>
        public static Force FromMiliNewton(decimal value)
        {
            return new Force(value, ForceUnits.MiliNewton);
        }

        /// <summary>
        /// creates force from value in mN
        /// </summary>
        /// <param name="value">Force value in mN</param>
        public static Force FromMiliNewton(double value)
        {
            return new Force((decimal)value, ForceUnits.MiliNewton);
        }

        /// <summary>
        /// creates force from value in mN
        /// </summary>
        /// <param name="value">Force value in mN</param>
        public static Force FromMiliNewton(int value)
        {
            return new Force(value, ForceUnits.MiliNewton);
        }

        /// <summary>
        /// creates force from value in mN
        /// </summary>
        /// <param name="value">Force value in mN</param>
        public static Force FromMiliNewton(long value)
        {
            return new Force(value, ForceUnits.MiliNewton);
        }

        /// <summary>
        /// creates force from value in N
        /// </summary>
        /// <param name="value">Force value in N</param>
        public static Force FromNewton(decimal value)
        {
            return new Force(value, ForceUnits.Newton);
        }

        /// <summary>
        /// creates force from value in N
        /// </summary>
        /// <param name="value">Force value in N</param>
        public static Force FromNewton(double value)
        {
            return new Force((decimal)value, ForceUnits.Newton);
        }

        /// <summary>
        /// creates force from value in N
        /// </summary>
        /// <param name="value">Force value in N</param>
        public static Force FromNewton(int value)
        {
            return new Force(value, ForceUnits.Newton);
        }

        /// <summary>
        /// creates force from value in N
        /// </summary>
        /// <param name="value">Force value in N</param>
        public static Force FromNewton(long value)
        {
            return new Force(value, ForceUnits.Newton);
        }

        public static Force Parse(string value)
        {
            // generator : BasicUnitedValuesGenerator.Add_Parse
            var parseResult = CommonParse.Parse(value, typeof(Force));
            return new Force(parseResult.Value, new ForceUnit(parseResult.UnitName));
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public ForceUnit Unit { get; }

        public static readonly ForceUnit BaseUnit = ForceUnits.Newton;

        public static readonly Force Zero = new Force(0, BaseUnit);

    }
}
