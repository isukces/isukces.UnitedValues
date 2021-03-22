using System.ComponentModel;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class FractionUnitInfo : IUnitConfig
    {
        public FractionUnitInfo(TypesGoup names, TypesGoup counterUnit, TypesGoup denominatorUnit)
        {
            Names           = names;
            CounterUnit     = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public static FractionUnitInfo Make<T1, T2, T3>()
        {
            return new FractionUnitInfo(
                new TypesGoup(typeof(T1).Name),
                new TypesGoup(typeof(T2).Name),
                new TypesGoup(typeof(T3).Name)
            );
        }

        public override string ToString()
        {
            return $"Name={Names.Value}, CounterUnit={CounterUnit.Unit}, DenominatorUnit={DenominatorUnit.Unit}";
        }

        public TypesGoup Names         { get; }
        public string    ValueTypeName => Names.Value;
        public string    UnitTypeName  => Names.Unit;

        public TypesGoup CounterUnit { get; }

        public TypesGoup DenominatorUnit { get; }
    }
}