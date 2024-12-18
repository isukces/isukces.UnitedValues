using System;
using System.Globalization;
using Newtonsoft.Json;

namespace iSukces.UnitedValues;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionValuesGenerator, UnitJsonConverterGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator
[Serializable]
[JsonConverter(typeof(MassStreamJsonConverter))]
public partial struct MassStream : IUnitedValue<MassStreamUnit>, IEquatable<MassStream>, IFormattable
{
    /// <summary>
    /// creates instance of MassStream
    /// </summary>
    /// <param name="value">value</param>
    /// <param name="unit">unit</param>
    public MassStream(decimal value, MassStreamUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public MassStream(decimal value, MassUnit counterUnit, TimeUnit denominatorUnit)
    {
        Value = value;
        Unit = new MassStreamUnit(counterUnit, denominatorUnit);
    }

    public MassStream ConvertTo(MassStreamUnit newUnit)
    {
        // generator : FractionValuesGenerator.Add_ConvertTo
        if (Unit.Equals(newUnit))
            return this;
        var a = new Mass(Value, Unit.CounterUnit);
        var b = new Time(1, Unit.DenominatorUnit);
        a = a.ConvertTo(newUnit.CounterUnit);
        b = b.ConvertTo(newUnit.DenominatorUnit);
        return new MassStream(a.Value / b.Value, newUnit);
    }

    public bool Equals(MassStream other)
    {
        // generator : FractionValuesGenerator
        return Value == other.Value && Unit is not null && Unit.Equals(other.Unit);
    }

    public bool Equals(IUnitedValue<MassStreamUnit>? other)
    {
        // generator : FractionValuesGenerator
        if (other is null)
            return false;
        return Value == other.Value && Unit is not null && Unit.Equals(other.Unit);
    }

    public override bool Equals(object? other)
    {
        // generator : FractionValuesGenerator
        return other is IUnitedValue<MassStreamUnit> value && Equals(value);
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

    public MassStream Round(int decimalPlaces)
    {
        return new MassStream(Math.Round(Value, decimalPlaces), Unit);
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

    public MassStream WithCounterUnit(MassUnit newUnit)
    {
        // generator : FractionValuesGenerator.Add_WithCounterUnit
        var oldUnit = Unit.CounterUnit;
        if (oldUnit == newUnit)
            return this;
        var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
        var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
        var resultUnit = Unit.WithCounterUnit(newUnit);
        return new MassStream(oldFactor / newFactor * Value, resultUnit);
    }

    public MassStream WithDenominatorUnit(TimeUnit newUnit)
    {
        // generator : FractionValuesGenerator.Add_WithDenominatorUnit
        var oldUnit = Unit.DenominatorUnit;
        if (oldUnit == newUnit)
            return this;
        var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
        var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
        var resultUnit = Unit.WithDenominatorUnit(newUnit);
        return new MassStream(newFactor / oldFactor * Value, resultUnit);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(MassStream left, MassStream right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="energyMassDensity">left factor (multiplicand)</param>
    /// <param name="massStream">rigth factor (multiplier)</param>
    public static Power operator *(EnergyMassDensity energyMassDensity, MassStream massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateOperator
        // scenario with hint
        // .Is<EnergyMassDensity, MassStream, Power>("*")
        // hint location HandleCreateOperatorCode, line 38
        var massUnit = massStream.Unit.CounterUnit;
        var leftConverted = energyMassDensity.ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit));
        var rightConverted = massStream.ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second));
        var value = leftConverted.Value * rightConverted.Value;
        return new Power(value, PowerUnits.Watt);
        // scenario F1
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="massStream">left factor (multiplicand)</param>
    /// <param name="energyMassDensity">rigth factor (multiplier)</param>
    public static Power operator *(MassStream massStream, EnergyMassDensity energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateOperator
        // scenario with hint
        // .Is<MassStream, EnergyMassDensity, Power>("*")
        // hint location HandleCreateOperatorCode, line 49
        var massUnit = massStream.Unit.CounterUnit;
        var leftConverted = energyMassDensity.ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit));
        var rightConverted = massStream.ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second));
        var value = leftConverted.Value * rightConverted.Value;
        return new Power(value, PowerUnits.Watt);
        // scenario F1
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="energyMassDensity">left factor (multiplicand)</param>
    /// <param name="massStream">rigth factor (multiplier)</param>
    public static Power? operator *(EnergyMassDensity? energyMassDensity, MassStream massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (energyMassDensity is null)
            return null;
        return energyMassDensity.Value * massStream;
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="massStream">left factor (multiplicand)</param>
    /// <param name="energyMassDensity">rigth factor (multiplier)</param>
    public static Power? operator *(MassStream? massStream, EnergyMassDensity energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null)
            return null;
        return massStream.Value * energyMassDensity;
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="energyMassDensity">left factor (multiplicand)</param>
    /// <param name="massStream">rigth factor (multiplier)</param>
    public static Power? operator *(EnergyMassDensity energyMassDensity, MassStream? massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null)
            return null;
        return energyMassDensity * massStream.Value;
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="massStream">left factor (multiplicand)</param>
    /// <param name="energyMassDensity">rigth factor (multiplier)</param>
    public static Power? operator *(MassStream massStream, EnergyMassDensity? energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (energyMassDensity is null)
            return null;
        return massStream * energyMassDensity.Value;
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="energyMassDensity">left factor (multiplicand)</param>
    /// <param name="massStream">rigth factor (multiplier)</param>
    public static Power? operator *(EnergyMassDensity? energyMassDensity, MassStream? massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (energyMassDensity is null || massStream is null)
            return null;
        return energyMassDensity.Value * massStream.Value;
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    /// <param name="massStream">left factor (multiplicand)</param>
    /// <param name="energyMassDensity">rigth factor (multiplier)</param>
    public static Power? operator *(MassStream? massStream, EnergyMassDensity? energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null || energyMassDensity is null)
            return null;
        return massStream.Value * energyMassDensity.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
    public static VolumeStream operator /(MassStream massStream, Density density)
    {
        // generator : MultiplyAlgebraGenerator.CreateOperator
        // scenario with hint
        // .Is<MassStream, Density, VolumeStream>("/")
        // hint location GetBasicOperatorHints, line 31
        var massStreamUnit = massStream.Unit;
        var densityUnit = density.Unit;
        var tmp1 = densityUnit.DenominatorUnit;
        var targetRightUnit = new DensityUnit(massStreamUnit.CounterUnit, tmp1);
        var resultUnit = new VolumeStreamUnit(tmp1, massStreamUnit.DenominatorUnit);
        var densityConverted = density.ConvertTo(targetRightUnit);
        var value = massStream.Value / densityConverted.Value;
        return new VolumeStream(value, resultUnit);
        // scenario F1
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static Density operator /(MassStream massStream, VolumeStream volumeStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateOperator
        // scenario with hint
        // .Is<MassStream, VolumeStream, Density>("/")
        // hint location GetBasicOperatorHints, line 31
        var volumeStreamUnit = volumeStream.Unit;
        var tmp1 = volumeStreamUnit.CounterUnit;
        var massStreamUnit = massStream.Unit;
        var targetRightUnit = new VolumeStreamUnit(tmp1, massStreamUnit.DenominatorUnit);
        var resultUnit = new DensityUnit(massStreamUnit.CounterUnit, tmp1);
        var volumeStreamConverted = volumeStream.ConvertTo(targetRightUnit);
        var value = massStream.Value / volumeStreamConverted.Value;
        return new Density(value, resultUnit);
        // scenario F1
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
    public static VolumeStream? operator /(MassStream? massStream, Density density)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null)
            return null;
        return massStream.Value / density;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static Density? operator /(MassStream? massStream, VolumeStream volumeStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null)
            return null;
        return massStream.Value / volumeStream;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
    public static VolumeStream? operator /(MassStream massStream, Density? density)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (density is null)
            return null;
        return massStream / density.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static Density? operator /(MassStream massStream, VolumeStream? volumeStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (volumeStream is null)
            return null;
        return massStream / volumeStream.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
    public static VolumeStream? operator /(MassStream? massStream, Density? density)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null || density is null)
            return null;
        return massStream.Value / density.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
    /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static Density? operator /(MassStream? massStream, VolumeStream? volumeStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null || volumeStream is null)
            return null;
        return massStream.Value / volumeStream.Value;
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(MassStream left, MassStream right)
    {
        return left.Equals(right);
    }

    public static MassStream Parse(string value)
    {
        // generator : FractionValuesGenerator.Add_Parse
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value));
        var r = CommonParse.Parse(value, typeof(MassStream));
        var units = Common.SplitUnitNameBySlash(r.UnitName);
        if (units.Length != 2)
            throw new Exception($"{r.UnitName} is not valid MassStream unit");
        var counterUnit = new MassUnit(units[0]);
        var denominatorUnit = new TimeUnit(units[1]);
        return new MassStream(r.Value, counterUnit, denominatorUnit);
    }

    /// <summary>
    /// value
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// unit
    /// </summary>
    public MassStreamUnit Unit { get; }

}

public partial class MassStreamJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(MassStreamUnit);
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
            if (objectType == typeof(MassStream))
                return MassStream.Parse((string)reader.Value);
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
