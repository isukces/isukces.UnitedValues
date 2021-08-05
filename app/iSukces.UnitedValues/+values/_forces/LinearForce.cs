
using System;
using System.Globalization;
using Newtonsoft.Json;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionValuesGenerator, UnitJsonConverterGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(LinearForceJsonConverter))]
    public partial struct LinearForce : IUnitedValue<LinearForceUnit>, IEquatable<LinearForce>, IFormattable
    {
        /// <summary>
        /// creates instance of LinearForce
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public LinearForce(decimal value, LinearForceUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public LinearForce(decimal value, ForceUnit counterUnit, LengthUnit denominatorUnit)
        {
            Value = value;
            Unit = new LinearForceUnit(counterUnit, denominatorUnit);
        }

        public LinearForce ConvertTo(LinearForceUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Force(Value, Unit.CounterUnit);
            var b = new Length(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new LinearForce(a.Value / b.Value, newUnit);
        }

        public bool Equals(LinearForce other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<LinearForceUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<LinearForceUnit> unitedValue ? Equals(unitedValue) : false;
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

        public LinearForce Round(int decimalPlaces)
        {
            return new LinearForce(Math.Round(Value, decimalPlaces), Unit);
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

        public LinearForce WithCounterUnit(ForceUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new LinearForce(oldFactor / newFactor * Value, resultUnit);
        }

        public LinearForce WithDenominatorUnit(LengthUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new LinearForce(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(LinearForce left, LinearForce right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure operator /(LinearForce linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Pressure operator /(LinearForce linearForce, Length length)
            // scenario with hint
            // .Is<LinearForce, Length, Pressure>("/")
            // hint location HandleCreateOperatorCode, line 50 Def_LinearForce_Length_Pressure
            var leftConverted = linearForce.ConvertTo(new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter));
            var rightConverted = length.ConvertTo(LengthUnits.Meter);
            var value = leftConverted.Value / rightConverted.Value;
            return new Pressure(value, PressureUnits.Pascal);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(LinearForce linearForce, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Length operator /(LinearForce linearForce, Pressure pressure)
            // scenario with hint
            // .Is<LinearForce, Pressure, Length>("/")
            // hint location HandleCreateOperatorCode, line 43 Def_LinearForce_Length_Pressure
            var leftConverted = linearForce.ConvertTo(new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter));
            var rightConverted = pressure.ConvertTo(PressureUnits.Pascal);
            var value = leftConverted.Value / rightConverted.Value;
            return new Length(value, LengthUnits.Meter);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(LinearForce? linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return linearForce.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearForce? linearForce, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return linearForce.Value / pressure;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(LinearForce linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearForce / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearForce linearForce, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return linearForce / pressure.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(LinearForce? linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null || length is null)
                return null;
            return linearForce.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearForce? linearForce, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null || pressure is null)
                return null;
            return linearForce.Value / pressure.Value;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(LinearForce left, LinearForce right)
        {
            return left.Equals(right);
        }

        public static LinearForce Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(LinearForce));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid LinearForce unit");
            var counterUnit = new ForceUnit(units[0]);
            var denominatorUnit = new LengthUnit(units[1]);
            return new LinearForce(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public LinearForceUnit Unit { get; }

    }

    public partial class LinearForceJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LinearForceUnit);
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
                if (objectType == typeof(LinearForce))
                    return LinearForce.Parse((string)reader.Value);
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
