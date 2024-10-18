using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace iSukces.UnitedValues;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitGenerator, DerivedUnitGenerator
[Serializable]
public partial class LengthUnit : IUnit, IEquatable<LengthUnit>
{
    /// <summary>
    /// creates instance of LengthUnit
    /// </summary>
    /// <param name="unitName">name of unit</param>
    public LengthUnit(string unitName)
    {
        if (unitName is null)
            throw new NullReferenceException(nameof(unitName));
        unitName = unitName.Trim();
        if (unitName.Length == 0)
            throw new ArgumentException(nameof(unitName));
        UnitName = unitName;
    }

    public bool Equals(LengthUnit? other)
    {
        return String.Equals(UnitName, other?.UnitName);
    }

    public override bool Equals(object? obj) => obj is LengthUnit tmp && Equals(tmp);

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    [RelatedUnitSource(RelatedUnitSourceUsage.ProvidesRelatedUnit, 10)]
    public AreaUnit GetAreaUnit()
    {
        // generator : BasicUnitGenerator.Add_ConvertOtherPower
        return GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(this);
    }

    public override int GetHashCode()
    {
        return UnitName?.GetHashCode() ?? 0;
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    [RelatedUnitSource(RelatedUnitSourceUsage.ProvidesRelatedUnit, 10)]
    public VolumeUnit GetVolumeUnit()
    {
        // generator : BasicUnitGenerator.Add_ConvertOtherPower
        return GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, VolumeUnit>(this);
    }

    /// <summary>
    /// Returns unit name
    /// </summary>
    public override string ToString()
    {
        return UnitName;
    }

    bool IEquatable<LengthUnit>.Equals(LengthUnit other)
    {
        return Equals(other);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(LengthUnit left, LengthUnit right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(LengthUnit left, LengthUnit right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Converts UnitDefinition&lt;LengthUnit&gt; into LengthUnit implicitly.
    /// </summary>
    /// <param name="src"></param>
    public static implicit operator LengthUnit(UnitDefinition<LengthUnit> src)
    {
        return src.Unit;
    }

    /// <summary>
    /// name of unit
    /// </summary>
    public string UnitName { get; }

}

[UnitsContainer]
public static partial class LengthUnits
{
    public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
    {
        factors.RegisterMany(All);
    }

    public static LengthUnit TryRecoverUnitFromName([JetBrains.Annotations.NotNull] string unitName)
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
        return new LengthUnit(unitName);
    }

    /// <summary>
    /// All known length units
    /// </summary>
    public static IReadOnlyList<UnitDefinition<LengthUnit>> All
    {
        get
        {
            return new []
            {
                Meter,
                Km,
                Dm,
                Cm,
                Mm,
                Inch,
                Feet,
                Yard,
                Furlong,
                Fathom,
                Mile,
                NauticalMile
            };
        }
    }

    internal static readonly LengthUnit MeterLengthUnit = new LengthUnit("m");

    public static readonly UnitDefinition<LengthUnit> Meter = new UnitDefinition<LengthUnit>(MeterLengthUnit, 1m);

    internal static readonly LengthUnit KmLengthUnit = new LengthUnit("km");

    public static readonly UnitDefinition<LengthUnit> Km = new UnitDefinition<LengthUnit>(KmLengthUnit, 1000m);

    internal static readonly LengthUnit DmLengthUnit = new LengthUnit("dm");

    public static readonly UnitDefinition<LengthUnit> Dm = new UnitDefinition<LengthUnit>(DmLengthUnit, 0.1m);

    internal static readonly LengthUnit CmLengthUnit = new LengthUnit("cm");

    public static readonly UnitDefinition<LengthUnit> Cm = new UnitDefinition<LengthUnit>(CmLengthUnit, 0.01m);

    internal static readonly LengthUnit MmLengthUnit = new LengthUnit("mm");

    public static readonly UnitDefinition<LengthUnit> Mm = new UnitDefinition<LengthUnit>(MmLengthUnit, 0.001m);

    internal static readonly LengthUnit InchLengthUnit = new LengthUnit("inch");

    public static readonly UnitDefinition<LengthUnit> Inch = new UnitDefinition<LengthUnit>(InchLengthUnit, 0.0254m);

    internal static readonly LengthUnit FeetLengthUnit = new LengthUnit("ft");

    public static readonly UnitDefinition<LengthUnit> Feet = new UnitDefinition<LengthUnit>(FeetLengthUnit, 0.3048m);

    internal static readonly LengthUnit YardLengthUnit = new LengthUnit("yd");

    public static readonly UnitDefinition<LengthUnit> Yard = new UnitDefinition<LengthUnit>(YardLengthUnit, 0.9144m);

    internal static readonly LengthUnit FurlongLengthUnit = new LengthUnit("fg");

    public static readonly UnitDefinition<LengthUnit> Furlong = new UnitDefinition<LengthUnit>(FurlongLengthUnit, 201.1680m);

    internal static readonly LengthUnit FathomLengthUnit = new LengthUnit("fh");

    public static readonly UnitDefinition<LengthUnit> Fathom = new UnitDefinition<LengthUnit>(FathomLengthUnit, 1.8288m);

    internal static readonly LengthUnit MileLengthUnit = new LengthUnit("mil");

    public static readonly UnitDefinition<LengthUnit> Mile = new UnitDefinition<LengthUnit>(MileLengthUnit, 1609.344m);

    internal static readonly LengthUnit NauticalMileLengthUnit = new LengthUnit("nm");

    public static readonly UnitDefinition<LengthUnit> NauticalMile = new UnitDefinition<LengthUnit>(NauticalMileLengthUnit, 1852m);

}
