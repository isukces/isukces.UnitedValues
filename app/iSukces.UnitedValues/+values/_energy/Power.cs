using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace iSukces.UnitedValues;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitValuesGenerator, UnitJsonConverterGenerator, UnitExtensionsGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator
[Serializable]
[JsonConverter(typeof(PowerJsonConverter))]
public partial struct Power : IUnitedValue<PowerUnit>, IEquatable<Power>, IComparable<Power>, IFormattable
{
    /// <summary>
    /// creates instance of Power
    /// </summary>
    /// <param name="value">value</param>
    /// <param name="unit">unit</param>
    public Power(decimal value, PowerUnit unit)
    {
        Value = value;
        if (unit is null)
            throw new NullReferenceException(nameof(unit));
        _unit = unit;
    }

    public int CompareTo(Power other)
    {
        return UnitedValuesUtils.Compare<Power, PowerUnit>(this, other);
    }

    public Power ConvertTo(PowerUnit newUnit)
    {
        // generator : BasicUnitValuesGenerator.Add_ConvertTo
        if (Unit.Equals(newUnit))
            return this;
        var basic = GetBaseUnitValue();
        var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
        return new Power(basic / factor, newUnit);
    }

    public bool Equals(Power other)
    {
        return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
    }

    public bool Equals(IUnitedValue<PowerUnit> other)
    {
        if (other is null)
            return false;
        return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
    }

    public override bool Equals(object other)
    {
        return other is IUnitedValue<PowerUnit> unitedValue ? Equals(unitedValue) : false;
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

    public Power Round(int decimalPlaces)
    {
        return new Power(Math.Round(Value, decimalPlaces), Unit);
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
    public static Power operator -(Power value)
    {
        return new Power(-value.Value, value.Unit);
    }

    public static Power operator -(Power left, Power right)
    {
        // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
        if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
            return -right;
        if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
            return left;
        right = right.ConvertTo(left.Unit);
        return new Power(left.Value - right.Value, left.Unit);
    }

    public static bool operator !=(Power left, Power right)
    {
        return left.CompareTo(right) != 0;
    }

    /// <summary>
    /// implements * operator
    /// </summary>
    /// <param name="value"></param>
    /// <param name="number"></param>
    public static Power operator *(Power value, decimal number)
    {
        return new Power(value.Value * number, value.Unit);
    }

    /// <summary>
    /// implements * operator
    /// </summary>
    /// <param name="number"></param>
    /// <param name="value"></param>
    public static Power operator *(decimal number, Power value)
    {
        return new Power(value.Value * number, value.Unit);
    }

    /// <summary>
    /// implements / operator
    /// </summary>
    /// <param name="value"></param>
    /// <param name="number"></param>
    public static Power operator /(Power value, decimal number)
    {
        return new Power(value.Value / number, value.Unit);
    }

    public static decimal operator /(Power left, Power right)
    {
        // generator : BasicUnitValuesGenerator.Add_Algebra_MulDiv
        right = right.ConvertTo(left.Unit);
        return left.Value / right.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
    public static MassStream operator /(Power power, EnergyMassDensity energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
        // scenario with hint
        // .Is<Power, EnergyMassDensity, MassStream>("/")
        // hint location HandleCreateOperatorCode, line 16
        var ru = energyMassDensity.Unit;
        var energy = new Energy(energyMassDensity.Value, ru.CounterUnit);
        var time = energy / power;
        var value = 1 / time.Value;
        return new MassStream(value, new MassStreamUnit(ru.DenominatorUnit, time.Unit));
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static EnergyMassDensity operator /(Power power, MassStream massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
        // scenario with hint
        // .Is<Power, MassStream, EnergyMassDensity>("/")
        // hint location HandleCreateOperatorCode, line 27
        var massUnit = massStream.Unit.CounterUnit;
        var leftConverted = power.ConvertTo(PowerUnits.Watt);
        var rightConverted = massStream.ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second));
        var value = leftConverted.Value / rightConverted.Value;
        return new EnergyMassDensity(value, new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit));
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
    public static MassStream? operator /(Power? power, EnergyMassDensity energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null)
            return null;
        return power.Value / energyMassDensity;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static EnergyMassDensity? operator /(Power? power, MassStream massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null)
            return null;
        return power.Value / massStream;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
    public static MassStream? operator /(Power power, EnergyMassDensity? energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (energyMassDensity is null)
            return null;
        return power / energyMassDensity.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static EnergyMassDensity? operator /(Power power, MassStream? massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (massStream is null)
            return null;
        return power / massStream.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
    public static MassStream? operator /(Power? power, EnergyMassDensity? energyMassDensity)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null || energyMassDensity is null)
            return null;
        return power.Value / energyMassDensity.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
    public static EnergyMassDensity? operator /(Power? power, MassStream? massStream)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null || massStream is null)
            return null;
        return power.Value / massStream.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
    public static LinearPowerLoss operator /(Power power, Length length)
    {
        // generator : MultiplyAlgebraGenerator.CreateOperator
        // scenario with hint
        // hint location HandleCreateOperatorCode, line 23 Def_Power_Length_LinearPowerLoss
        var value = power.Value / length.Value;
        return new LinearPowerLoss(value, new LinearPowerLossUnit(power.Unit, length.Unit));
        // scenario F3
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="linearPowerLoss">a divisor (denominator) - a value which dividend is divided by</param>
    public static Length operator /(Power power, LinearPowerLoss linearPowerLoss)
    {
        // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
        // scenario A
        // linearpowerloss unit will be synchronized with power unit
        var unit = new LinearPowerLossUnit(power.Unit, linearPowerLoss.Unit.DenominatorUnit);
        var linearPowerLossConverted    = linearPowerLoss.WithCounterUnit(power.Unit);
        var value = power.Value / linearPowerLossConverted.Value;
        return new Length(value, linearPowerLoss.Unit.DenominatorUnit);
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
    public static LinearPowerLoss? operator /(Power? power, Length length)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null)
            return null;
        return power.Value / length;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="linearPowerLoss">a divisor (denominator) - a value which dividend is divided by</param>
    public static Length? operator /(Power? power, LinearPowerLoss linearPowerLoss)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null)
            return null;
        return power.Value / linearPowerLoss;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
    public static LinearPowerLoss? operator /(Power power, Length? length)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (length is null)
            return null;
        return power / length.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="linearPowerLoss">a divisor (denominator) - a value which dividend is divided by</param>
    public static Length? operator /(Power power, LinearPowerLoss? linearPowerLoss)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (linearPowerLoss is null)
            return null;
        return power / linearPowerLoss.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
    public static LinearPowerLoss? operator /(Power? power, Length? length)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null || length is null)
            return null;
        return power.Value / length.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="linearPowerLoss">a divisor (denominator) - a value which dividend is divided by</param>
    public static Length? operator /(Power? power, LinearPowerLoss? linearPowerLoss)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null || linearPowerLoss is null)
            return null;
        return power.Value / linearPowerLoss.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
    public static Irradiance operator /(Power power, Area area)
    {
        // generator : MultiplyAlgebraGenerator.CreateOperator
        // scenario with hint
        // hint location HandleCreateOperatorCode, line 22 Def_Power_Length_LinearPowerLoss
        var value = power.Value / area.Value;
        return new Irradiance(value, new IrradianceUnit(power.Unit, area.Unit));
        // scenario F3
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="irradiance">a divisor (denominator) - a value which dividend is divided by</param>
    public static Area operator /(Power power, Irradiance irradiance)
    {
        // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
        // scenario A
        // irradiance unit will be synchronized with power unit
        var unit = new IrradianceUnit(power.Unit, irradiance.Unit.DenominatorUnit);
        var irradianceConverted    = irradiance.WithCounterUnit(power.Unit);
        var value = power.Value / irradianceConverted.Value;
        return new Area(value, irradiance.Unit.DenominatorUnit);
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
    public static Irradiance? operator /(Power? power, Area area)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null)
            return null;
        return power.Value / area;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="irradiance">a divisor (denominator) - a value which dividend is divided by</param>
    public static Area? operator /(Power? power, Irradiance irradiance)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null)
            return null;
        return power.Value / irradiance;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
    public static Irradiance? operator /(Power power, Area? area)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (area is null)
            return null;
        return power / area.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="irradiance">a divisor (denominator) - a value which dividend is divided by</param>
    public static Area? operator /(Power power, Irradiance? irradiance)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (irradiance is null)
            return null;
        return power / irradiance.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
    public static Irradiance? operator /(Power? power, Area? area)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null || area is null)
            return null;
        return power.Value / area.Value;
    }

    /// <summary>
    /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
    /// </summary>
    /// <param name="power">a dividend (counter) - a value that is being divided</param>
    /// <param name="irradiance">a divisor (denominator) - a value which dividend is divided by</param>
    public static Area? operator /(Power? power, Irradiance? irradiance)
    {
        // generator : MultiplyAlgebraGenerator.CreateCode
        if (power is null || irradiance is null)
            return null;
        return power.Value / irradiance.Value;
    }

    public static Power operator +(Power left, Power right)
    {
        // generator : BasicUnitValuesGenerator.Add_Algebra_PlusMinus
        if (left.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(left.Unit?.UnitName))
            return right;
        if (right.Value.Equals(decimal.Zero) && string.IsNullOrEmpty(right.Unit?.UnitName))
            return left;
        right = right.ConvertTo(left.Unit);
        return new Power(left.Value + right.Value, left.Unit);
    }

    public static bool operator <(Power left, Power right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(Power left, Power right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator ==(Power left, Power right)
    {
        return left.CompareTo(right) == 0;
    }

    public static bool operator >(Power left, Power right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(Power left, Power right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <summary>
    /// creates power from value in GJ/year
    /// </summary>
    /// <param name="value">Power value in GJ/year</param>
    public static Power FromGigaJoulePerYear(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.GigaJoulePerYear);
    }

    /// <summary>
    /// creates power from value in GJ/year
    /// </summary>
    /// <param name="value">Power value in GJ/year</param>
    public static Power FromGigaJoulePerYear(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power((decimal)value, PowerUnits.GigaJoulePerYear);
    }

    /// <summary>
    /// creates power from value in GJ/year
    /// </summary>
    /// <param name="value">Power value in GJ/year</param>
    public static Power FromGigaJoulePerYear(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.GigaJoulePerYear);
    }

    /// <summary>
    /// creates power from value in GJ/year
    /// </summary>
    /// <param name="value">Power value in GJ/year</param>
    public static Power FromGigaJoulePerYear(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.GigaJoulePerYear);
    }

    /// <summary>
    /// creates power from value in GW
    /// </summary>
    /// <param name="value">Power value in GW</param>
    public static Power FromGigaWatt(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.GigaWatt);
    }

    /// <summary>
    /// creates power from value in GW
    /// </summary>
    /// <param name="value">Power value in GW</param>
    public static Power FromGigaWatt(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power((decimal)value, PowerUnits.GigaWatt);
    }

    /// <summary>
    /// creates power from value in GW
    /// </summary>
    /// <param name="value">Power value in GW</param>
    public static Power FromGigaWatt(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.GigaWatt);
    }

    /// <summary>
    /// creates power from value in GW
    /// </summary>
    /// <param name="value">Power value in GW</param>
    public static Power FromGigaWatt(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.GigaWatt);
    }

    /// <summary>
    /// creates power from value in kW
    /// </summary>
    /// <param name="value">Power value in kW</param>
    public static Power FromKiloWatt(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.KiloWatt);
    }

    /// <summary>
    /// creates power from value in kW
    /// </summary>
    /// <param name="value">Power value in kW</param>
    public static Power FromKiloWatt(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power((decimal)value, PowerUnits.KiloWatt);
    }

    /// <summary>
    /// creates power from value in kW
    /// </summary>
    /// <param name="value">Power value in kW</param>
    public static Power FromKiloWatt(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.KiloWatt);
    }

    /// <summary>
    /// creates power from value in kW
    /// </summary>
    /// <param name="value">Power value in kW</param>
    public static Power FromKiloWatt(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.KiloWatt);
    }

    /// <summary>
    /// creates power from value in MW
    /// </summary>
    /// <param name="value">Power value in MW</param>
    public static Power FromMegaWatt(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.MegaWatt);
    }

    /// <summary>
    /// creates power from value in MW
    /// </summary>
    /// <param name="value">Power value in MW</param>
    public static Power FromMegaWatt(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power((decimal)value, PowerUnits.MegaWatt);
    }

    /// <summary>
    /// creates power from value in MW
    /// </summary>
    /// <param name="value">Power value in MW</param>
    public static Power FromMegaWatt(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.MegaWatt);
    }

    /// <summary>
    /// creates power from value in MW
    /// </summary>
    /// <param name="value">Power value in MW</param>
    public static Power FromMegaWatt(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.MegaWatt);
    }

    /// <summary>
    /// creates power from value in mW
    /// </summary>
    /// <param name="value">Power value in mW</param>
    public static Power FromMiliWatt(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.MiliWatt);
    }

    /// <summary>
    /// creates power from value in mW
    /// </summary>
    /// <param name="value">Power value in mW</param>
    public static Power FromMiliWatt(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power((decimal)value, PowerUnits.MiliWatt);
    }

    /// <summary>
    /// creates power from value in mW
    /// </summary>
    /// <param name="value">Power value in mW</param>
    public static Power FromMiliWatt(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.MiliWatt);
    }

    /// <summary>
    /// creates power from value in mW
    /// </summary>
    /// <param name="value">Power value in mW</param>
    public static Power FromMiliWatt(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.MiliWatt);
    }

    /// <summary>
    /// creates power from value in W
    /// </summary>
    /// <param name="value">Power value in W</param>
    public static Power FromWatt(decimal value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.Watt);
    }

    /// <summary>
    /// creates power from value in W
    /// </summary>
    /// <param name="value">Power value in W</param>
    public static Power FromWatt(double value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power((decimal)value, PowerUnits.Watt);
    }

    /// <summary>
    /// creates power from value in W
    /// </summary>
    /// <param name="value">Power value in W</param>
    public static Power FromWatt(int value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.Watt);
    }

    /// <summary>
    /// creates power from value in W
    /// </summary>
    /// <param name="value">Power value in W</param>
    public static Power FromWatt(long value)
    {
        // generator : BasicUnitValuesGenerator.Add_FromMethods
        return new Power(value, PowerUnits.Watt);
    }

    public static Power Parse(string value)
    {
        // generator : BasicUnitValuesGenerator.Add_Parse
        var parseResult = CommonParse.Parse(value, typeof(Power));
        if (string.IsNullOrEmpty(parseResult.UnitName))
            return new Power(parseResult.Value, Power.BaseUnit);
        return new Power(parseResult.Value, new PowerUnit(parseResult.UnitName));
    }

    /// <summary>
    /// value
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// unit
    /// </summary>
    [JetBrains.Annotations.NotNull]
    public PowerUnit Unit
    {
        get { return _unit ?? BaseUnit; }
    }

    private PowerUnit _unit;

    public static readonly PowerUnit BaseUnit = PowerUnits.Watt;

    public static readonly Power Zero = new Power(0, BaseUnit);

}

public static partial class PowerExtensions
{
    public static Power Sum(this IEnumerable<Power> items)
    {
        if (items is null)
            return Power.Zero;
        var c = items.ToArray();
        if (c.Length == 0)
            return Power.Zero;
        if (c.Length == 1)
            return c[0];
        var unit  = c[0].Unit;
        var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
        return new Power(value, unit);
    }

    public static Power Sum(this IEnumerable<Power?> items)
    {
        if (items is null)
            return Power.Zero;
        return items.Where(a => a != null).Select(a => a.Value).Sum();
    }

    public static Power Sum<T>(this IEnumerable<T> items, Func<T, Power> map)
    {
        if (items is null)
            return Power.Zero;
        return items.Select(map).Sum();
    }

}

public partial class PowerJsonConverter : AbstractUnitJsonConverter<Power, PowerUnit>
{
    protected override Power Make(decimal value, string unit)
    {
        unit = unit?.Trim();
        return new Power(value, string.IsNullOrEmpty(unit) ? Power.BaseUnit : new PowerUnit(unit));
    }

    protected override Power Parse(string txt)
    {
        return Power.Parse(txt);
    }

}
