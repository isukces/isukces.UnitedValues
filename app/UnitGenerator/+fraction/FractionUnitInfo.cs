using System.ComponentModel;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class FractionUnitInfo : IUnitConfig
    {
        public FractionUnitInfo(ValueGroup names, ValueGroup counterUnit, ValueGroup denominatorUnit)
        {
            Names           = names;
            CounterUnit     = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public override string ToString()
        {
            return $"Name={Names.ValueTypeName}, CounterUnit={CounterUnit.UnitTypeName}, DenominatorUnit={DenominatorUnit.UnitTypeName}";
        }

        public ValueGroup Names { get; }
        public string     ValueTypeName  => Names.ValueTypeName;
        public string     UnitTypeName  => Names.UnitTypeName;

        public ValueGroup CounterUnit { get; }

        public ValueGroup DenominatorUnit { get; }

        public static FractionUnitInfo Make<T1, T2, T3>()
        {
            return new FractionUnitInfo(
                new ValueGroup(typeof(T1).Name),
                new ValueGroup(typeof(T2).Name),
                new ValueGroup(typeof(T3).Name)
            );
        }
    }
}