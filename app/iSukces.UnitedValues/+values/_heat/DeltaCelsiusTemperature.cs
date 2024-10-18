using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace iSukces.UnitedValues;

public partial struct DeltaCelsiusTemperature
{
    public static implicit operator DeltaCelsiusTemperature(DeltaKelvinTemperature temp)
    {
        if (temp.Unit == KelvinTemperatureUnits.Degree)
            return new DeltaCelsiusTemperature(temp.Value, CelsiusTemperatureUnits.Degree);
        throw new NotSupportedException(
            CelsiusTemperature.MakeMessage(temp, Kelvin, Celsius));
    }

    public static implicit operator DeltaKelvinTemperature(DeltaCelsiusTemperature temp)
    {
        if (temp.Unit == CelsiusTemperatureUnits.Degree)
            return new DeltaKelvinTemperature(temp.Value, KelvinTemperatureUnits.Degree);
        throw new NotSupportedException(
            CelsiusTemperature.MakeMessage(temp, Celsius, Kelvin));
    }

    private const string Celsius = "Celsius temperature difference";
    private const string Kelvin  = "Kelvin temperature difference";
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitValuesGenerator, UnitJsonConverterGenerator, UnitExtensionsGenerator
[Serializable]
[JsonConverter(typeof(DeltaCelsiusTemperatureJsonConverter))]
public partial struct DeltaCelsiusTemperature : IUnitedValue<CelsiusTemperatureUnit>, IEquatable<DeltaCelsiusTemperature>, IComparable<DeltaCelsiusTemperature>, IFormattable
{
    /// <summary>
    /// creates instance of DeltaCelsiusTemperature
    /// </summary>
    /// <param name="value">value</param>
    /// <param name="unit">unit</param>
    public DeltaCelsiusTemperature(decimal value, CelsiusTemperatureUnit unit)
    {
        Value = value;
        if (unit is null)
            throw new NullReferenceException(nameof(unit));
        _unit = unit;
    }

    public int CompareTo(DeltaCelsiusTemperature other)
    {
        return UnitedValuesUtils.Compare<DeltaCelsiusTemperature, CelsiusTemperatureUnit>(this, other);
    }

    public DeltaCelsiusTemperature ConvertTo(CelsiusTemperatureUnit newUnit)
    {
        // generator : BasicUnitValuesGenerator.Add_ConvertTo
        if (Unit.Equals(newUnit))
            return this;
        var basic = GetBaseUnitValue();
        var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
        return new DeltaCelsiusTemperature(basic / factor, newUnit);
    }

    public bool Equals(DeltaCelsiusTemperature other)
    {
        return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
    }

    public bool Equals(IUnitedValue<CelsiusTemperatureUnit> other)
    {
        if (other is null)
            return false;
        return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
    }

    public override bool Equals(object other)
    {
        return other is IUnitedValue<CelsiusTemperatureUnit> unitedValue ? Equals(unitedValue) : false;
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

    public DeltaCelsiusTemperature Round(int decimalPlaces)
    {
        return new DeltaCelsiusTemperature(Math.Round(Value, decimalPlaces), Unit);
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
    public static DeltaCelsiusTemperature operator -(DeltaCelsiusTemperature value)
    {
        return new DeltaCelsiusTemperature(-value.Value, value.Unit);
    }

    public static DeltaCelsiusTemperature operator -(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
        if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
            return -right;
        if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
            return left;
        right = right.ConvertTo(left.Unit);
        return new DeltaCelsiusTemperature(left.Value - right.Value, left.Unit);
    }

    public static bool operator !=(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        return left.CompareTo(right) != 0;
    }

    /// <summary>
    /// implements * operator
    /// </summary>
    /// <param name="value"></param>
    /// <param name="number"></param>
    public static DeltaCelsiusTemperature operator *(DeltaCelsiusTemperature value, decimal number)
    {
        return new DeltaCelsiusTemperature(value.Value * number, value.Unit);
    }

    /// <summary>
    /// implements * operator
    /// </summary>
    /// <param name="number"></param>
    /// <param name="value"></param>
    public static DeltaCelsiusTemperature operator *(decimal number, DeltaCelsiusTemperature value)
    {
        return new DeltaCelsiusTemperature(value.Value * number, value.Unit);
    }

    /// <summary>
    /// implements / operator
    /// </summary>
    /// <param name="value"></param>
    /// <param name="number"></param>
    public static DeltaCelsiusTemperature operator /(DeltaCelsiusTemperature value, decimal number)
    {
        return new DeltaCelsiusTemperature(value.Value / number, value.Unit);
    }

    public static decimal operator /(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
        right = right.ConvertTo(left.Unit);
        return left.Value / right.Value;
    }

    public static DeltaCelsiusTemperature operator +(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
        if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
            return right;
        if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
            return left;
        right = right.ConvertTo(left.Unit);
        return new DeltaCelsiusTemperature(left.Value + right.Value, left.Unit);
    }

    public static bool operator <(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator ==(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        return left.CompareTo(right) == 0;
    }

    public static bool operator >(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(DeltaCelsiusTemperature left, DeltaCelsiusTemperature right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    /// creates deltaCelsiusTemperature from value in ----
    /// </summary>
    /// <param name="value">DeltaCelsiusTemperature value in ----</param>
    public static DeltaCelsiusTemperature FromDegree(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new DeltaCelsiusTemperature(value, CelsiusTemperatureUnits.Degree);
    }

    /// <summary>
    /// creates deltaCelsiusTemperature from value in ----
    /// </summary>
    /// <param name="value">DeltaCelsiusTemperature value in ----</param>
    public static DeltaCelsiusTemperature FromDegree(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new DeltaCelsiusTemperature((decimal)value, CelsiusTemperatureUnits.Degree);
    }

    /// <summary>
    /// creates deltaCelsiusTemperature from value in ----
    /// </summary>
    /// <param name="value">DeltaCelsiusTemperature value in ----</param>
    public static DeltaCelsiusTemperature FromDegree(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new DeltaCelsiusTemperature(value, CelsiusTemperatureUnits.Degree);
    }

    /// <summary>
    /// creates deltaCelsiusTemperature from value in ----
    /// </summary>
    /// <param name="value">DeltaCelsiusTemperature value in ----</param>
    public static DeltaCelsiusTemperature FromDegree(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new DeltaCelsiusTemperature(value, CelsiusTemperatureUnits.Degree);
    }

    public static DeltaCelsiusTemperature Parse(string value)
    {
        // generator : BasicUnitValuesGenerator.Add_Parse
        var parseResult = CommonParse.Parse(value, typeof(DeltaCelsiusTemperature));
        if (string.IsNullOrEmpty(parseResult.UnitName))
            return new DeltaCelsiusTemperature(parseResult.Value, DeltaCelsiusTemperature.BaseUnit);
        return new DeltaCelsiusTemperature(parseResult.Value, new CelsiusTemperatureUnit(parseResult.UnitName));
    }

    /// <summary>
    /// value
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// unit
    /// </summary>
    [JetBrains.Annotations.NotNull]
    public CelsiusTemperatureUnit Unit
    {
        get { return _unit ?? BaseUnit; }
    }

    private CelsiusTemperatureUnit _unit;

    public static readonly CelsiusTemperatureUnit BaseUnit = CelsiusTemperatureUnits.Degree;

    public static readonly DeltaCelsiusTemperature Zero = new DeltaCelsiusTemperature(0, BaseUnit);

}

public static partial class DeltaCelsiusTemperatureExtensions
{
    public static DeltaCelsiusTemperature Sum(this IEnumerable<DeltaCelsiusTemperature> items)
    {
        if (items is null)
            return DeltaCelsiusTemperature.Zero;
        var c = items.ToArray();
        if (c.Length == 0)
            return DeltaCelsiusTemperature.Zero;
        if (c.Length == 1)
            return c[0];
        var unit  = c[0].Unit;
        var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
        return new DeltaCelsiusTemperature(value, unit);
    }

    public static DeltaCelsiusTemperature Sum(this IEnumerable<DeltaCelsiusTemperature?> items)
    {
        if (items is null)
            return DeltaCelsiusTemperature.Zero;
        return items.Where(a => a != null).Select(a => a.Value).Sum();
    }

    public static DeltaCelsiusTemperature Sum<T>(this IEnumerable<T> items, Func<T, DeltaCelsiusTemperature> map)
    {
        if (items is null)
            return DeltaCelsiusTemperature.Zero;
        return items.Select(map).Sum();
    }

}

public partial class DeltaCelsiusTemperatureJsonConverter : AbstractUnitJsonConverter<DeltaCelsiusTemperature, CelsiusTemperatureUnit>
{
    protected override DeltaCelsiusTemperature Make(decimal value, string unit)
    {
        unit = unit?.Trim();
        return new DeltaCelsiusTemperature(value, string.IsNullOrEmpty(unit) ? DeltaCelsiusTemperature.BaseUnit : new CelsiusTemperatureUnit(unit));
    }

    protected override DeltaCelsiusTemperature Parse(string txt)
    {
        return DeltaCelsiusTemperature.Parse(txt);
    }

}
