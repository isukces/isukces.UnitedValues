using System;
using System.Globalization;
using Newtonsoft.Json;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionValuesGenerator, UnitJsonConverterGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(AccelerationJsonConverter))]
    public partial struct Acceleration : IUnitedValue<AccelerationUnit>, IEquatable<Acceleration>, IFormattable
    {
        /// <summary>
        /// creates instance of Acceleration
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Acceleration(decimal value, AccelerationUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Acceleration(decimal value, LengthUnit counterUnit, SquareTimeUnit denominatorUnit)
        {
            Value = value;
            Unit = new AccelerationUnit(counterUnit, denominatorUnit);
        }

        public Acceleration ConvertTo(AccelerationUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Length(Value, Unit.CounterUnit);
            var b = new SquareTime(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new Acceleration(a.Value / b.Value, newUnit);
        }

        public bool Equals(Acceleration other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<AccelerationUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<AccelerationUnit> unitedValue ? Equals(unitedValue) : false;
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
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public Acceleration Round(int decimalPlaces)
        {
            return new Acceleration(Math.Round(Value, decimalPlaces), Unit);
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

        public Acceleration WithCounterUnit(LengthUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new Acceleration(oldFactor / newFactor * Value, resultUnit);
        }

        public Acceleration WithDenominatorUnit(SquareTimeUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new Acceleration(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(Acceleration left, Acceleration right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="acceleration">rigth factor (multiplier)</param>
        public static Pressure operator *(PlanarDensity planarDensity, Acceleration acceleration)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<PlanarDensity, Acceleration, Pressure>("*")
            // hint location HandleCreateOperatorCode, line 41
            var leftConverted = planarDensity.ConvertTo(PlanarDensityUnits.KgPerSquareMeter);
            var rightConverted = acceleration.ConvertTo(AccelerationUnits.MetersPerSquareSeconds);
            var value = leftConverted.Value * rightConverted.Value;
            return new Pressure(value, PressureUnits.Pascal);
            // scenario F1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="acceleration">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Pressure operator *(Acceleration acceleration, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Acceleration, PlanarDensity, Pressure>("*")
            // hint location HandleCreateOperatorCode, line 48
            var leftConverted = acceleration.ConvertTo(AccelerationUnits.MetersPerSquareSeconds);
            var rightConverted = planarDensity.ConvertTo(PlanarDensityUnits.KgPerSquareMeter);
            var value = leftConverted.Value * rightConverted.Value;
            return new Pressure(value, PressureUnits.Pascal);
            // scenario F1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="acceleration">rigth factor (multiplier)</param>
        public static Pressure? operator *(PlanarDensity? planarDensity, Acceleration acceleration)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return planarDensity.Value * acceleration;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="acceleration">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Pressure? operator *(Acceleration? acceleration, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (acceleration is null)
                return null;
            return acceleration.Value * planarDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="acceleration">rigth factor (multiplier)</param>
        public static Pressure? operator *(PlanarDensity planarDensity, Acceleration? acceleration)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (acceleration is null)
                return null;
            return planarDensity * acceleration.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="acceleration">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Pressure? operator *(Acceleration acceleration, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return acceleration * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="acceleration">rigth factor (multiplier)</param>
        public static Pressure? operator *(PlanarDensity? planarDensity, Acceleration? acceleration)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null || acceleration is null)
                return null;
            return planarDensity.Value * acceleration.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="acceleration">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Pressure? operator *(Acceleration? acceleration, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (acceleration is null || planarDensity is null)
                return null;
            return acceleration.Value * planarDensity.Value;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(Acceleration left, Acceleration right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// creates acceleration from value in m/s²
        /// </summary>
        /// <param name="value">Acceleration value in m/s²</param>
        public static Acceleration FromMetersPerSquareSeconds(decimal value)
        {
            // generator : FractionValuesGenerator.Add_FromMethods
            return new Acceleration(value, AccelerationUnits.MetersPerSquareSeconds);
        }

        /// <summary>
        /// creates acceleration from value in m/s²
        /// </summary>
        /// <param name="value">Acceleration value in m/s²</param>
        public static Acceleration FromMetersPerSquareSeconds(double value)
        {
            // generator : FractionValuesGenerator.Add_FromMethods
            return new Acceleration((decimal)value, AccelerationUnits.MetersPerSquareSeconds);
        }

        /// <summary>
        /// creates acceleration from value in m/s²
        /// </summary>
        /// <param name="value">Acceleration value in m/s²</param>
        public static Acceleration FromMetersPerSquareSeconds(int value)
        {
            // generator : FractionValuesGenerator.Add_FromMethods
            return new Acceleration(value, AccelerationUnits.MetersPerSquareSeconds);
        }

        /// <summary>
        /// creates acceleration from value in m/s²
        /// </summary>
        /// <param name="value">Acceleration value in m/s²</param>
        public static Acceleration FromMetersPerSquareSeconds(long value)
        {
            // generator : FractionValuesGenerator.Add_FromMethods
            return new Acceleration(value, AccelerationUnits.MetersPerSquareSeconds);
        }

        public static Acceleration Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Acceleration));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid Acceleration unit");
            var counterUnit = new LengthUnit(units[0]);
            var denominatorUnit = new SquareTimeUnit(units[1]);
            return new Acceleration(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public AccelerationUnit Unit { get; }

    }

    public partial class AccelerationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AccelerationUnit);
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
                if (objectType == typeof(Acceleration))
                    return Acceleration.Parse((string)reader.Value);
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
