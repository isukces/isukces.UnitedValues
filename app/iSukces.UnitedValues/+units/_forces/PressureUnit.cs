using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace iSukces.UnitedValues;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitGenerator, DerivedUnitGenerator
[Serializable]
public partial class PressureUnit : IUnit, IEquatable<PressureUnit>
{
    /// <summary>
    /// creates instance of PressureUnit
    /// </summary>
    /// <param name="unitName">name of unit</param>
    public PressureUnit(string unitName)
    {
        if (unitName is null)
            throw new NullReferenceException(nameof(unitName));
        unitName = unitName.Trim();
        if (unitName.Length == 0)
            throw new ArgumentException(nameof(unitName));
        UnitName = unitName;
    }

    public bool Equals(PressureUnit? other)
    {
        return String.Equals(UnitName, other?.UnitName);
    }

    public override bool Equals(object? obj) => obj is PressureUnit tmp && Equals(tmp);

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

    bool IEquatable<PressureUnit>.Equals(PressureUnit other)
    {
        return Equals(other);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(PressureUnit left, PressureUnit right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(PressureUnit left, PressureUnit right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Converts UnitDefinition&lt;PressureUnit&gt; into PressureUnit implicitly.
    /// </summary>
    /// <param name="src"></param>
    public static implicit operator PressureUnit(UnitDefinition<PressureUnit> src)
    {
        return src.Unit;
    }

    /// <summary>
    /// name of unit
    /// </summary>
    public string UnitName { get; }

}

[UnitsContainer]
public static partial class PressureUnits
{
    public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
    {
        factors.RegisterMany(All);
    }

    public static PressureUnit TryRecoverUnitFromName([JetBrains.Annotations.NotNull] string unitName)
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
        return new PressureUnit(unitName);
    }

    /// <summary>
    /// All known pressure units
    /// </summary>
    public static IReadOnlyList<UnitDefinition<PressureUnit>> All
    {
        get
        {
            return new []
            {
                Pascal,
                HectoPascal,
                KiloPascal,
                MegaPascal,
                GigaPascal
            };
        }
    }

    internal static readonly PressureUnit PascalPressureUnit = new PressureUnit("Pa");

    public static readonly UnitDefinition<PressureUnit> Pascal = new UnitDefinition<PressureUnit>(PascalPressureUnit, 1m);

    internal static readonly PressureUnit HectoPascalPressureUnit = new PressureUnit("hPa");

    public static readonly UnitDefinition<PressureUnit> HectoPascal = new UnitDefinition<PressureUnit>(HectoPascalPressureUnit, 100m);

    internal static readonly PressureUnit KiloPascalPressureUnit = new PressureUnit("kPa");

    public static readonly UnitDefinition<PressureUnit> KiloPascal = new UnitDefinition<PressureUnit>(KiloPascalPressureUnit, 1000m);

    internal static readonly PressureUnit MegaPascalPressureUnit = new PressureUnit("MPa");

    public static readonly UnitDefinition<PressureUnit> MegaPascal = new UnitDefinition<PressureUnit>(MegaPascalPressureUnit, 1000000m);

    internal static readonly PressureUnit GigaPascalPressureUnit = new PressureUnit("GPa");

    public static readonly UnitDefinition<PressureUnit> GigaPascal = new UnitDefinition<PressureUnit>(GigaPascalPressureUnit, 1000000000m);

}
