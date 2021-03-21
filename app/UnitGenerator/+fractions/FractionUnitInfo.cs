using System.ComponentModel;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class FractionUnitInfo : IUnitConfig
    {
        public FractionUnitInfo(ValueGroup names, string counterUnit, string denominatorUnit)
        {
            Names           = names;
            CounterUnit     = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public override string ToString()
        {
            return $"Name={Names}, CounterUnit={CounterUnit}, DenominatorUnit={DenominatorUnit}";
        }

        public ValueGroup Names { get; }
        public string     ValueTypeName  => Names.ValueTypeName;
        public string     UnitTypeName  => Names.UnitTypeName;

        public string CounterUnit { get; }

        public string DenominatorUnit { get; }
    }
}