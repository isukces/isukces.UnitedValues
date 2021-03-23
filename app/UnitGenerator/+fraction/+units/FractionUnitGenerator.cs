using System.Collections.Generic;
using iSukces.UnitedValues;
using Self = UnitGenerator.FractionUnitGenerator;

namespace UnitGenerator
{
    internal class FractionUnitGenerator : BaseCompositeUnitGenerator<FractionUnit>
    {
        public FractionUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override Info2 GetInfo2()
        {
            return new Info2("/");
        }

        protected override IEnumerable<string> GetImplementedInterfaces()
        {
            var name = new Args(Cfg.CounterUnit.Unit, Cfg.DenominatorUnit.Unit)
                .MakeGenericType(nameof(IFractionalUnit));
            return new[] {name};
        }

        protected override CompositeUnitGeneratorInfo GetInfo()
        {
            return CompositeUnitGeneratorInfo.Make(Cfg);
        }


        protected override string GetTypename(FractionUnit cfg)
        {
            return Cfg.UnitTypes.Unit;
        }
    }
}