using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace iSukces.UnitedValues;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: BasicUnitGenerator, DerivedUnitGenerator
[Serializable]
public partial class SquareTimeUnit : IUnit, IEquatable<SquareTimeUnit>, IDecomposableUnit, IDerivedDecomposableUnit
{
    /// <summary>
    /// creates instance of SquareTimeUnit
    /// </summary>
    /// <param name="unitName">name of unit</param>
    public SquareTimeUnit(string unitName)
    {
        if (unitName is null)
            throw new NullReferenceException(nameof(unitName));
        unitName = unitName.Trim();
        if (unitName.Length == 0)
            throw new ArgumentException(nameof(unitName));
        UnitName = unitName;
    }

    /// <summary>
    /// creates instance of SquareTimeUnit
    /// </summary>
    /// <param name="baseUnit">based on</param>
    /// <param name="unitName">name of unit</param>
    public SquareTimeUnit(TimeUnit baseUnit, string unitName = null)
    {
        if (baseUnit is null)
            throw new NullReferenceException(nameof(baseUnit));
        BaseUnit = baseUnit;
        unitName = unitName?.Trim();
        UnitName = string.IsNullOrEmpty(unitName) ? baseUnit.UnitName + "²" : unitName;
    }

    public IReadOnlyList<DecomposableUnitItem> Decompose()
    {
        // generator : BasicUnitGenerator.Add_Decompose
        return new[] { GetBasicUnit() };
    }

    public bool Equals(SquareTimeUnit? other)
    {
        return String.Equals(UnitName, other?.UnitName);
    }

    public override bool Equals(object? obj) => obj is SquareTimeUnit tmp && Equals(tmp);

    public DecomposableUnitItem GetBasicUnit()
    {
        // generator : BasicUnitGenerator.Add_Decompose
        var tmp = GetTimeUnit();
        return new DecomposableUnitItem(tmp, 2);
    }

    public override int GetHashCode()
    {
        return UnitName?.GetHashCode() ?? 0;
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    [RelatedUnitSource(RelatedUnitSourceUsage.ProvidesRelatedUnit, 10)]
    public TimeUnit GetTimeUnit()
    {
        // generator : BasicUnitGenerator.Add_ConvertOtherPower
        return GlobalUnitRegistry.Relations.GetOrThrow<SquareTimeUnit, TimeUnit>(this);
    }

    /// <summary>
    /// Returns unit name
    /// </summary>
    public override string ToString()
    {
        return UnitName;
    }

    bool IEquatable<SquareTimeUnit>.Equals(SquareTimeUnit other)
    {
        return Equals(other);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator !=(SquareTimeUnit left, SquareTimeUnit right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left">first value to compare</param>
    /// <param name="right">second value to compare</param>
    public static bool operator ==(SquareTimeUnit left, SquareTimeUnit right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Converts UnitDefinition&lt;SquareTimeUnit&gt; into SquareTimeUnit implicitly.
    /// </summary>
    /// <param name="src"></param>
    public static implicit operator SquareTimeUnit(UnitDefinition<SquareTimeUnit> src)
    {
        return src.Unit;
    }

    /// <summary>
    /// name of unit
    /// </summary>
    public string UnitName { get; }

    /// <summary>
    /// based on
    /// </summary>
    [RelatedUnitSource(RelatedUnitSourceUsage.DoNotUse)]
    public TimeUnit BaseUnit { get; }

}

[UnitsContainer]
public static partial class SquareTimeUnits
{
    public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
    {
        factors.RegisterMany(All);
    }

    public static SquareTimeUnit TryRecoverUnitFromName([JetBrains.Annotations.NotNull] string unitName)
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
        return new SquareTimeUnit(unitName);
    }

    internal static void Register(UnitRelationsDictionary dict)
    {
        dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareMiliSecond, TimeUnits.MiliSecond);
        dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.MiliSecond, SquareMiliSecond);
        dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareSecond, TimeUnits.Second);
        dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Second, SquareSecond);
        dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareMinute, TimeUnits.Minute);
        dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Minute, SquareMinute);
        dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareHour, TimeUnits.Hour);
        dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Hour, SquareHour);
        dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareYear, TimeUnits.Year);
        dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Year, SquareYear);
    }

    /// <summary>
    /// All known squareTime units
    /// </summary>
    public static IReadOnlyList<UnitDefinition<SquareTimeUnit>> All
    {
        get
        {
            return new []
            {
                SquareMiliSecond,
                SquareSecond,
                SquareMinute,
                SquareHour,
                SquareYear
            };
        }
    }

    internal static readonly SquareTimeUnit SquareMiliSecondSquareTimeUnit = new SquareTimeUnit(TimeUnits.MiliSecond);

    public static readonly UnitDefinition<SquareTimeUnit> SquareMiliSecond = new UnitDefinition<SquareTimeUnit>(SquareMiliSecondSquareTimeUnit, 0.001m * 0.001m);

    internal static readonly SquareTimeUnit SquareSecondSquareTimeUnit = new SquareTimeUnit(TimeUnits.Second);

    public static readonly UnitDefinition<SquareTimeUnit> SquareSecond = new UnitDefinition<SquareTimeUnit>(SquareSecondSquareTimeUnit, 1m);

    internal static readonly SquareTimeUnit SquareMinuteSquareTimeUnit = new SquareTimeUnit(TimeUnits.Minute);

    public static readonly UnitDefinition<SquareTimeUnit> SquareMinute = new UnitDefinition<SquareTimeUnit>(SquareMinuteSquareTimeUnit, 60m * 60m);

    internal static readonly SquareTimeUnit SquareHourSquareTimeUnit = new SquareTimeUnit(TimeUnits.Hour);

    public static readonly UnitDefinition<SquareTimeUnit> SquareHour = new UnitDefinition<SquareTimeUnit>(SquareHourSquareTimeUnit, 3600m * 3600m);

    internal static readonly SquareTimeUnit SquareYearSquareTimeUnit = new SquareTimeUnit(TimeUnits.Year);

    public static readonly UnitDefinition<SquareTimeUnit> SquareYear = new UnitDefinition<SquareTimeUnit>(SquareYearSquareTimeUnit, 31556925.993600m * 31556925.993600m);

}
