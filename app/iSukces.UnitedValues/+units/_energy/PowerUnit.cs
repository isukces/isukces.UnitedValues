using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace iSukces.UnitedValues;

partial class PowerUnit
{
    [RelatedUnitSourceAttribute(RelatedUnitSourceUsage.ProvidesRelatedUnit)]
    public static UnitDefinition<PowerUnit> CratePowerUnitFromEnergyAndTime(EnergyUnit energy, TimeUnit time)
    {
        var energyFactor = GlobalUnitRegistry.Factors.GetThrow(energy);

        var tmp = PowerUnits.All.Where(a => a.Multiplication == energyFactor).Take(1).ToArray();
        if (time == TimeUnits.Second)
            if (tmp.Length > 0)
                return new UnitDefinition<PowerUnit>(tmp[0].Unit, 1);

        var timeFactor = GlobalUnitRegistry.Factors.GetThrow(time);

        if (tmp.Length > 0)
            return new UnitDefinition<PowerUnit>(tmp[0].Unit, 1);
        var search = energyFactor / timeFactor;

        tmp = PowerUnits.All.Where(a => a.Multiplication == search).Take(1).ToArray();
        if (tmp.Length > 0)
            return new UnitDefinition<PowerUnit>(tmp[0].Unit, 1);
        return new UnitDefinition<PowerUnit>(PowerUnits.Watt, search);
    }
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitGenerator, DerivedUnitGenerator
[Serializable]
public partial class PowerUnit : IUnit, IEquatable<PowerUnit>
{
    /// <summary>
    /// creates instance of PowerUnit
    /// </summary>
    /// <param name="unitName">name of unit</param>
    public PowerUnit(string unitName)
    {
        if (unitName is null)
            throw new NullReferenceException(nameof(unitName));
        unitName = unitName.Trim();
        if (unitName.Length == 0)
            throw new ArgumentException(nameof(unitName));
        UnitName = unitName;
    }

    public bool Equals(PowerUnit other)
    {
        return String.Equals(UnitName, other?.UnitName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is PowerUnit tmp && Equals(tmp);
    }

    public override int GetHashCode()
    {
        return UnitName?.GetHashCode() ?? 0;
    }

    /// <summary>
    /// Returns unit name
    /// </summary>
    public override string ToString()
    {
        return UnitName;
    }

    bool IEquatable<PowerUnit>.Equals(PowerUnit other)
    {
        return Equals(other);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(PowerUnit left, PowerUnit right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(PowerUnit left, PowerUnit right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Converts UnitDefinition&lt;PowerUnit&gt; into PowerUnit implicitly.
    /// </summary>
    /// <param name="src"></param>
    public static implicit operator PowerUnit(UnitDefinition<PowerUnit> src)
    {
        return src.Unit;
    }

    /// <summary>
    /// name of unit
    /// </summary>
    public string UnitName { get; }

}

[UnitsContainer]
public static partial class PowerUnits
{
    public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
    {
        factors.RegisterMany(All);
    }

    public static PowerUnit TryRecoverUnitFromName([JetBrains.Annotations.NotNull] string unitName)
    {
        // generator : DerivedUnitGenerator.Add_TryRecoverUnitFromName
        if (unitName is null)
            throw new NullReferenceException(nameof(unitName));
        unitName = unitName.Trim();
        if (unitName.Length == 0)
            throw new ArgumentException(nameof(unitName));
        foreach (var i in All)
        {
            if (unitName == i.UnitName)
                return i.Unit;
        }
        return new PowerUnit(unitName);
    }

    /// <summary>
    /// All known power units
    /// </summary>
    public static IReadOnlyList<UnitDefinition<PowerUnit>> All
    {
        get
        {
            return new []
            {
                Watt,
                GigaJoulePerYear,
                KiloWatt,
                MegaWatt,
                GigaWatt,
                MiliWatt
            };
        }
    }

    internal static readonly PowerUnit WattPowerUnit = new PowerUnit("W");

    public static readonly UnitDefinition<PowerUnit> Watt = new UnitDefinition<PowerUnit>(WattPowerUnit, 1m);

    internal static readonly PowerUnit GigaJoulePerYearPowerUnit = new PowerUnit("GJ/year");

    public static readonly UnitDefinition<PowerUnit> GigaJoulePerYear = new UnitDefinition<PowerUnit>(GigaJoulePerYearPowerUnit, 31.688764621839531948700358345m);

    internal static readonly PowerUnit KiloWattPowerUnit = new PowerUnit("kW");

    public static readonly UnitDefinition<PowerUnit> KiloWatt = new UnitDefinition<PowerUnit>(KiloWattPowerUnit, 1000m);

    internal static readonly PowerUnit MegaWattPowerUnit = new PowerUnit("MW");

    public static readonly UnitDefinition<PowerUnit> MegaWatt = new UnitDefinition<PowerUnit>(MegaWattPowerUnit, 1000000m);

    internal static readonly PowerUnit GigaWattPowerUnit = new PowerUnit("GW");

    public static readonly UnitDefinition<PowerUnit> GigaWatt = new UnitDefinition<PowerUnit>(GigaWattPowerUnit, 1000000000m);

    internal static readonly PowerUnit MiliWattPowerUnit = new PowerUnit("mW");

    public static readonly UnitDefinition<PowerUnit> MiliWatt = new UnitDefinition<PowerUnit>(MiliWattPowerUnit, 0.001m);

}
