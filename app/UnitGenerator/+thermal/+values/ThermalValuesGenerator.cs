using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;
using Self = UnitGenerator.InversedValuesGenerator;

namespace UnitGenerator
{
    internal class ThermalValuesGenerator : BaseValuesGenerator<ThermalUnit>
    {
        public ThermalValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }


        protected override void GenerateOne()
        {
            Target.Kind = CsNamespaceMemberKind.Struct;
            AddCommonValues_PropertiesAndConstructor(UnitTypeName);
            Add_GetBaseUnitValue();
            Target.ImplementedInterfaces.Add(new CsArguments(UnitTypeName).MakeGenericType("IUnitedValue"));
            Add_Properties();
            Add_Algebra_MinusUnary();
            Add_NumberDiv();
            /*
             foreach (var i in Cfg.Interfaces)
                Target.ImplementedInterfaces.Add(i);

            Target.Attributes.Add(new CsAttribute("Serializable"));
            Target.Attributes.Add(
                new CsAttribute("JsonConverter").WithArgumentCode("typeof(" + Cfg.UnitTypes.Value + "JsonConverter)"));
           
            
            Add_Parse();
            Add_Round(Cfg.UnitTypes);
            Add_Comparable();
            Add_Algebra_MulDiv();
            Add_Algebra_MinusUnary();
            Add_Algebra_PlusMinus();
            Add_ConvertTo();
            Add_FromMethods();*/
        }

        private void Add_NumberDiv()
        {
            TypesGroup invTypes             = Cfg.Source;
            var        unitConversionMethod = "Get" + invTypes.Unit.TypeName;
            var        resultUnit           = $"value.Unit.{unitConversionMethod}()";
            Target.AddOperator("/", new CsArguments("number / value.Value", resultUnit),
                    invTypes.Value.GetTypename())
                .WithLeftRightArguments(ValuePropertyType, Target.Name, "number", "value");
        }

        protected override Col1 GetConstructorProperties()
        {
            return new Col1(new[]
            {
                new ConstructorParameterInfo(ValuePropName,
                    ValuePropertyType, null, "value"),
                new ConstructorParameterInfo(UnitPropName,
                    (CsType)UnitTypeName, null, "unit")
            });
        }

        protected override string GetTypename(ThermalUnit cfg)
        {
            return Cfg.Inversed.Value.GetTypename();
        }

        private static void Add_Properties()
        {
        }

        private string UnitTypeName => Cfg.TargetUnitTypename.Declaration;
    }
}