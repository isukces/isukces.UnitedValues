using System.ComponentModel;

namespace UnitGenerator;

[ImmutableObject(true)]
public class FractionUnit : IUnitInfo
{
    private FractionUnit(TypesGroup unitTypes, TypesGroup counterUnit, TypesGroup denominatorUnit)
    {
        UnitTypes       = unitTypes;
        CounterUnit     = counterUnit;
        DenominatorUnit = denominatorUnit;
    }

    public static FractionUnit Make<T1, T2, T3>()
    {
        return new FractionUnit(
            new TypesGroup(typeof(T1).Name),
            new TypesGroup(typeof(T2).Name),
            new TypesGroup(typeof(T3).Name)
        );
    }

    public static FractionUnit Make<T2, T3>(string name)
    {
        return new FractionUnit(
            new TypesGroup(name),
            new TypesGroup(typeof(T2).Name),
            new TypesGroup(typeof(T3).Name)
        );
    }

    public override string ToString()
    {
        return $"Name={UnitTypes.Value}, CounterUnit={CounterUnit.Unit}, DenominatorUnit={DenominatorUnit.Unit}";
    }

    public TypesGroup UnitTypes { get; }

    public TypesGroup CounterUnit { get; }

    public TypesGroup DenominatorUnit { get; }
}
