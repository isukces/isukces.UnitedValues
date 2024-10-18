using System.Collections.Generic;
using iSukces.UnitedValues;
using Self = UnitGenerator.FractionUnitGenerator;

namespace UnitGenerator;

internal class FractionUnitGenerator : BaseCompositeUnitGenerator<FractionUnit>
{
    public FractionUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
    {
        }

    protected override IEnumerable<string> GetImplementedInterfaces()
    {
            var name = new CsArguments(Cfg.CounterUnit.Unit.GetTypename(), Cfg.DenominatorUnit.Unit.GetTypename())
                .MakeGenericType(nameof(IFractionalUnit));
            return new[] {name.Declaration};
        }

    protected override CompositeUnitGeneratorInfo GetInfo()
    {
            return CompositeUnitGeneratorInfo.Make(Cfg);
        }

    protected override Info2 GetInfo2()
    {
            return new Info2("/", new[]
            {
                new NameAndPower(nameof(FakeFractionalUnit.CounterUnit), 1),
                new NameAndPower(nameof(FakeFractionalUnit.DenominatorUnit), -1)
            });
        }


    protected override string GetTypename(FractionUnit cfg)
    {
            return Cfg.UnitTypes.Unit.GetTypename();
        }
}