// ReSharper disable All
// generator: ProductValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(MassDetlaKelvinJsonConverter))]
    public partial struct MassDetlaKelvin : IUnitedValue<MassDetlaKelvinUnit>, IEquatable<MassDetlaKelvin>, IFormattable
    {
        /// <summary>
        /// creates instance of MassDetlaKelvin
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public MassDetlaKelvin(decimal value, MassDetlaKelvinUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public MassDetlaKelvin(decimal value, MassUnit leftUnit, KelvinTemperatureUnit rightUnit)
        {
            Value = value;
            Unit = new MassDetlaKelvinUnit(leftUnit, rightUnit);
        }

        public MassDetlaKelvin ConvertTo(MassDetlaKelvinUnit newUnit)
        {
            // generator : ProductValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Mass(Value, Unit.LeftUnit);
            var b = new DeltaKelvinTemperature(1, Unit.RightUnit);
            a = a.ConvertTo(newUnit.LeftUnit);
            b = b.ConvertTo(newUnit.RightUnit);
            return new MassDetlaKelvin(a.Value / b.Value, newUnit);
        }

        public bool Equals(MassDetlaKelvin other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<MassDetlaKelvinUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<MassDetlaKelvinUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public MassDetlaKelvin Round(int decimalPlaces)
        {
            return new MassDetlaKelvin(Math.Round(Value, decimalPlaces), Unit);
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

        public MassDetlaKelvin WithLeftUnit(MassUnit newUnit)
        {
            // generator : ProductValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.LeftUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithLeftUnit(newUnit);
            return new MassDetlaKelvin(oldFactor / newFactor * Value, resultUnit);
        }

        public MassDetlaKelvin WithRightUnit(KelvinTemperatureUnit newUnit)
        {
            // generator : ProductValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.RightUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithRightUnit(newUnit);
            return new MassDetlaKelvin(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(MassDetlaKelvin left, MassDetlaKelvin right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(MassDetlaKelvin left, MassDetlaKelvin right)
        {
            return left.Equals(right);
        }

        public static MassDetlaKelvin Parse(string value)
        {
            // generator : ProductValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(MassDetlaKelvin));
            var units = Common.SplitUnitNameByTimesSign(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid MassDetlaKelvin unit");
            var counterUnit = new MassUnit(units[0]);
            var denominatorUnit = new KelvinTemperatureUnit(units[1]);
            return new MassDetlaKelvin(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public MassDetlaKelvinUnit Unit { get; }

    }
}
