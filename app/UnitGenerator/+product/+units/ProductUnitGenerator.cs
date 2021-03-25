using System.Collections.Generic;
using iSukces.UnitedValues;
using Self = UnitGenerator.ProductUnitGenerator;

namespace UnitGenerator
{
    internal class ProductUnitGenerator : BaseCompositeUnitGenerator<ProductUnit>
    {
        public ProductUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override IEnumerable<string> GetImplementedInterfaces()
        {
            var name = new Args(Cfg.CounterUnit.Unit, Cfg.DenominatorUnit.Unit)
                .MakeGenericType(nameof(IProductUnit));
            return new[] {name};
        }

        protected override CompositeUnitGeneratorInfo GetInfo()
        {
            return CompositeUnitGeneratorInfo.Make(Cfg);
        }

        protected override Info2 GetInfo2()
        {
            return new Info2("");
        }


        protected override string GetTypename(ProductUnit cfg)
        {
            return Cfg.UnitTypes.Unit;
        }
    }
}