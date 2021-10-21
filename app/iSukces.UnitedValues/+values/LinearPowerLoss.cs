using System;
using System.Globalization;
using Newtonsoft.Json;

namespace iSukces.UnitedValues
{
    partial struct LinearPowerLoss
    {
        public static LinearPowerLoss FromWattPerMeter(decimal value)
        {
            return new LinearPowerLoss(value, PowerUnits.Watt, LengthUnits.Meter);
        }
    }
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionValuesGenerator, UnitJsonConverterGenerator

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(LinearPowerLossJsonConverter))]
    public partial struct LinearPowerLoss : IUnitedValue<LinearPowerLossUnit>, IEquatable<LinearPowerLoss>, IFormattable
    {
        /// <summary>
        /// creates instance of LinearPowerLoss
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public LinearPowerLoss(decimal value, LinearPowerLossUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public LinearPowerLoss(decimal value, PowerUnit counterUnit, LengthUnit denominatorUnit)
        {
            Value = value;
            Unit = new LinearPowerLossUnit(counterUnit, denominatorUnit);
        }

        public LinearPowerLoss ConvertTo(LinearPowerLossUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Power(Value, Unit.CounterUnit);
            var b = new Length(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new LinearPowerLoss(a.Value / b.Value, newUnit);
        }

        public bool Equals(LinearPowerLoss other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<LinearPowerLossUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<LinearPowerLossUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            // generator : BasicUnitValuesGenerator.Add_GetBaseUnitValue
            var factor1 = GlobalUnitRegistry.Factors.Get(Unit.CounterUnit);
            var factor2 = GlobalUnitRegistry.Factors.Get(Unit.DenominatorUnit);
            if ((factor1.HasValue && factor2.HasValue))
                return Value * factor1.Value / factor2.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit?.GetHashCode() ?? 0;
            }
        }

        public LinearPowerLoss Round(int decimalPlaces)
        {
            return new LinearPowerLoss(Math.Round(Value, decimalPlaces), Unit);
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

        public LinearPowerLoss WithCounterUnit(PowerUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new LinearPowerLoss(oldFactor / newFactor * Value, resultUnit);
        }

        public LinearPowerLoss WithDenominatorUnit(LengthUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new LinearPowerLoss(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(LinearPowerLoss left, LinearPowerLoss right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(LinearPowerLoss left, LinearPowerLoss right)
        {
            return left.Equals(right);
        }

        public static LinearPowerLoss Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(LinearPowerLoss));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid LinearPowerLoss unit");
            var counterUnit = new PowerUnit(units[0]);
            var denominatorUnit = new LengthUnit(units[1]);
            return new LinearPowerLoss(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public LinearPowerLossUnit Unit { get; }

    }

    public partial class LinearPowerLossJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LinearPowerLossUnit);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                if (objectType == typeof(LinearPowerLoss))
                    return LinearPowerLoss.Parse((string)reader.Value);
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is null)
                writer.WriteNull();
            else
                writer.WriteValue(value.ToString());
        }

    }
}
