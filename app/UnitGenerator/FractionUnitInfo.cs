using System.ComponentModel;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class FractionUnitInfo : IUnitConfig
    {
        public FractionUnitInfo(string name, string unit, string counterUnit, string denominatorUnit)
        {
            Name            = name;
            CounterUnit     = counterUnit;
            DenominatorUnit = denominatorUnit;
            Unit            = unit;
        }

        public override string ToString()
        {
            return $"Name={Name}, CounterUnit={CounterUnit}, DenominatorUnit={DenominatorUnit}";
        }

        public string Name { get; }
        public string Unit { get; }

        public string CounterUnit { get; }

        public string DenominatorUnit { get; }
    }
}