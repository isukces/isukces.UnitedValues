using iSukces.Code.CodeWrite;
using iSukces.UnitedValues;
using Self = UnitGenerator.FractionValuesGenerator;

namespace UnitGenerator
{
    internal class FractionValuesGenerator : BaseCompositeValuesGenerator<FractionUnit>
    {
        public FractionValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }


        protected override ConstructorParameterInfo[] GetConstructorProperties()
        {
            return new[]
            {
                new ConstructorParameterInfo(ValuePropName,
                    ValuePropertyType,
                    null,
                    "value"),
                new ConstructorParameterInfo(UnitPropName,
                    Cfg.UnitTypes.Unit.GetTypename(), null, "unit")
            };
        }


        protected override CompositeUnitGeneratorInfo GetInfo()
        {
            return CompositeUnitGeneratorInfo.Make(Cfg);
        }

        protected override void Add_Parse()
        {
            const string splitMethodName = nameof(Common) + "." + nameof(Common.SplitUnitNameBySlash);
            Add_Parse(splitMethodName);
        }


        protected override string GetTypename(FractionUnit cfg)
        {
            return Cfg.UnitTypes.Value.ValueTypeName;
        }

        protected override void Add_FromMethods()
        {
            var collection  = CommonFractionalUnitDefs.All;
            var commonUnits = collection.GetBy(Cfg.UnitTypes.Unit);
            if (commonUnits.Length == 0) return;
            foreach (var i in commonUnits)
            {
                var u = new RelatedUnitInfo(i.TargetPropertyName,
                    i.GetUnitName(),
                    i.TargetPropertyName);
                BasicUnitValuesGenerator.Add_FromMethods(
                    i.Type.Value,
                    i.Type,
                    Target,
                    u);
            }
        }
        
        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }
    }
}