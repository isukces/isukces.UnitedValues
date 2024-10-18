using System;
using System.Globalization;
using Newtonsoft.Json;

namespace iSukces.UnitedValues;

partial struct PressureDrop
{
    public static PressureDrop FromPascalPerMeter(decimal value)
    {
        return new PressureDrop(value, PressureUnits.Pascal, LengthUnits.Meter);
    }
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionValuesGenerator, UnitJsonConverterGenerator
[Serializable]
[JsonConverter(typeof(PressureDropJsonConverter))]
public partial struct PressureDrop : IUnitedValue<PressureDropUnit>, IEquatable<PressureDrop>, IFormattable
{
    /// <summary>
    /// creates instance of PressureDrop
    /// </summary>
    /// <param name="value">value</param>
    /// <param name="unit">unit</param>
    public PressureDrop(decimal value, PressureDropUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public PressureDrop(decimal value, PressureUnit counterUnit, LengthUnit denominatorUnit)
    {
        Value = value;
        Unit = new PressureDropUnit(counterUnit, denominatorUnit);
    }

    public PressureDrop ConvertTo(PressureDropUnit newUnit)
    {
        // generator : FractionValuesGenerator.Add_ConvertTo
        if (Unit.Equals(newUnit))
            return this;
        var a = new Pressure(Value, Unit.CounterUnit);
        var b = new Length(1, Unit.DenominatorUnit);
        a = a.ConvertTo(newUnit.CounterUnit);
        b = b.ConvertTo(newUnit.DenominatorUnit);
        return new PressureDrop(a.Value / b.Value, newUnit);
    }

    public bool Equals(PressureDrop other)
    {
        // generator : FractionValuesGenerator
        return Value == other.Value && Unit is not null && Unit.Equals(other.Unit);
    }

    public bool Equals(IUnitedValue<PressureDropUnit>? other)
    {
        // generator : FractionValuesGenerator
        if (other is null)
            return false;
        return Value == other.Value && Unit is not null && Unit.Equals(other.Unit);
    }

    public override bool Equals(object? other)
    {
        // generator : FractionValuesGenerator
        return other is IUnitedValue<PressureDropUnit> value && Equals(value);
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

    public PressureDrop Round(int decimalPlaces)
    {
        return new PressureDrop(Math.Round(Value, decimalPlaces), Unit);
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

    public PressureDrop WithCounterUnit(PressureUnit newUnit)
    {
        // generator : FractionValuesGenerator.Add_WithCounterUnit
        var oldUnit = Unit.CounterUnit;
        if (oldUnit == newUnit)
            return this;
        var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
        var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
        var resultUnit = Unit.WithCounterUnit(newUnit);
        return new PressureDrop(oldFactor / newFactor * Value, resultUnit);
    }

    public PressureDrop WithDenominatorUnit(LengthUnit newUnit)
    {
        // generator : FractionValuesGenerator.Add_WithDenominatorUnit
        var oldUnit = Unit.DenominatorUnit;
        if (oldUnit == newUnit)
            return this;
        var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
        var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
        var resultUnit = Unit.WithDenominatorUnit(newUnit);
        return new PressureDrop(newFactor / oldFactor * Value, resultUnit);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(PressureDrop left, PressureDrop right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(PressureDrop left, PressureDrop right)
    {
        return left.Equals(right);
    }

    public static PressureDrop Parse(string value)
    {
        // generator : FractionValuesGenerator.Add_Parse
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value));
        var r = CommonParse.Parse(value, typeof(PressureDrop));
        var units = Common.SplitUnitNameBySlash(r.UnitName);
        if (units.Length != 2)
            throw new Exception($"{r.UnitName} is not valid PressureDrop unit");
        var counterUnit = new PressureUnit(units[0]);
        var denominatorUnit = new LengthUnit(units[1]);
        return new PressureDrop(r.Value, counterUnit, denominatorUnit);
    }

    /// <summary>
    /// value
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// unit
    /// </summary>
    public PressureDropUnit Unit { get; }

}

public partial class PressureDropJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(PressureDropUnit);
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
            if (objectType == typeof(PressureDrop))
                return PressureDrop.Parse((string)reader.Value);
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
