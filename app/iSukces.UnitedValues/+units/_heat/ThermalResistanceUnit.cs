using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues;

public class ThermalResistanceUnit : IDecomposableUnit, IEquatable<ThermalResistanceUnit>
{
    public ThermalResistanceUnit(LengthUnit lengthUnit, PowerUnit powerUnit)
    {
        LengthUnit = lengthUnit;
        PowerUnit  = powerUnit;
    }

    public static bool operator ==(ThermalResistanceUnit left, ThermalResistanceUnit right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ThermalResistanceUnit left, ThermalResistanceUnit right)
    {
        return !Equals(left, right);
    }

    public IReadOnlyList<DecomposableUnitItem> Decompose()
    {
        return new[]
        {
            new DecomposableUnitItem(LengthUnit, 1),
            new DecomposableUnitItem(KelvinTemperatureUnits.Degree.Unit, 1),
            new DecomposableUnitItem(PowerUnit, -1)
        };
    }

    public bool Equals(ThermalResistanceUnit other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Equals(LengthUnit, other.LengthUnit) && Equals(PowerUnit, other.PowerUnit);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ThermalResistanceUnit)obj);
    }


    public override int GetHashCode()
    {
        unchecked
        {
            return ((LengthUnit != null ? LengthUnit.GetHashCode() : 0) * 397) ^
                   (PowerUnit != null ? PowerUnit.GetHashCode() : 0);
        }
    }

    public ThermalConductivityUnit GetThermalConductivityUnit()
    {
        return new ThermalConductivityUnit(LengthUnit, PowerUnit);
    }

    public override string ToString()
    {
        return UnitName;
    }

    public static KelvinTemperatureUnit Kelvin => KelvinTemperatureUnits.Degree.Unit;

    public LengthUnit LengthUnit { get; }
    public PowerUnit  PowerUnit  { get; }

    public string UnitName
    {
        get
        {
            var meter  = LengthUnit.UnitName;
            var kelvin = Kelvin.UnitName;
            var watt   = PowerUnit.UnitName;
            if (kelvin == "K" && meter != "m") // avoid mK means mili Kelvin
                return $"{meter}{kelvin}/{watt}";
            return $"{meter}*{kelvin}/{watt}";
        }
    }
}

public sealed class ThermalResistanceUnits
{
    public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
    {
        factors.RegisterMany(All);
    }


    /// <summary>
    ///     All known kelvinTemperature units
    /// </summary>
    public static IReadOnlyList<UnitDefinition<ThermalResistanceUnit>> All
    {
        get
        {
            return new[]
            {
                MeterKelvinPerWatt
            };
        }
    }

    #region Fields

    internal static readonly KelvinTemperatureUnit DegreeKelvinTemperatureUnit = new("K");

    public static readonly UnitDefinition<ThermalResistanceUnit> MeterKelvinPerWatt
        = new(
            new ThermalResistanceUnit(LengthUnits.Meter, PowerUnits.Watt), 1m);

    #endregion
}