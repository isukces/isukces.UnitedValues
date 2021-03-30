// ReSharper disable All
// generator: ProductValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(TorqueJsonConverter))]
    public partial struct Torque : IUnitedValue<TorqueUnit>, IEquatable<Torque>, IFormattable
    {
        /// <summary>
        /// creates instance of Torque
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Torque(decimal value, TorqueUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Torque(decimal value, ForceUnit leftUnit, LengthUnit rightUnit)
        {
            Value = value;
            Unit = new TorqueUnit(leftUnit, rightUnit);
        }

        public Torque ConvertTo(TorqueUnit newUnit)
        {
            // generator : ProductValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Force(Value, Unit.LeftUnit);
            var b = new Length(1, Unit.RightUnit);
            a = a.ConvertTo(newUnit.LeftUnit);
            b = b.ConvertTo(newUnit.RightUnit);
            return new Torque(a.Value / b.Value, newUnit);
        }

        public bool Equals(Torque other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<TorqueUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<TorqueUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit?.GetHashCode() ?? 0;
            }
        }

        public Torque Round(int decimalPlaces)
        {
            return new Torque(Math.Round(Value, decimalPlaces), Unit);
        }

        public string SerializeToJson()
        {
            // generator : ProductValuesGenerator.Add_SerializeToJson
            var l = Unit.LeftUnit.UnitName ?? string.Empty;
            var r = Unit.RightUnit.UnitName ?? string.Empty;
            if (l.Length==1 && r.Length==1)
                return ToString();
            return Value.ToString(CultureInfo.InvariantCulture) + l + Common.TimesSign + r;
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

        public Torque WithLeftUnit(ForceUnit newUnit)
        {
            // generator : ProductValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.LeftUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithLeftUnit(newUnit);
            return new Torque(oldFactor / newFactor * Value, resultUnit);
        }

        public Torque WithRightUnit(LengthUnit newUnit)
        {
            // generator : ProductValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.RightUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithRightUnit(newUnit);
            return new Torque(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(Torque left, Torque right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(Torque left, Torque right)
        {
            return left.Equals(right);
        }

        public static Torque Parse(string value)
        {
            // generator : ProductValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Torque));
            var units = Common.SplitUnitNameByTimesSign(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid Torque unit");
            var counterUnit = new ForceUnit(units[0]);
            var denominatorUnit = new LengthUnit(units[1]);
            return new Torque(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public TorqueUnit Unit { get; }

    }
}
