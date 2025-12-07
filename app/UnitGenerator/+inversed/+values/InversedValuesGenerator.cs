using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator;

internal class InversedValuesGenerator : BaseValuesGenerator<InversedUnit>
{
    public InversedValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
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
        var invTypes             = Cfg.InversionBaseUnit.UnitTypes;
        var unitConversionMethod = "Get" + invTypes.Unit.TypeName;
        var resultUnit           = $"value.Unit.{unitConversionMethod}()";
        Target.AddOperator("/", new CsArguments("number / value.Value", resultUnit), invTypes.Value.GetTypename())
            .WithLeftRightArguments(ValuePropertyType, Target.Name, "number", "value");
    }

    protected override Writers GetConstructorProperties()
    {
        return new Writers([
            new ConstructorParameterInfo(ValuePropName,
                ValuePropertyType, null, "value"),
            new ConstructorParameterInfo(UnitPropName,
                (CsType)UnitTypeName, null, "unit")
        ]);
    }

    protected override string GetTypename(InversedUnit cfg)
    {
        return Cfg.Target.Value.GetTypename();
    }

    private void Add_Properties()
    {
        Target.AddField("BaseUnit", (CsType)UnitTypeName)
            .WithStatic()
            .WithIsReadOnly()
            .WithConstValue(Cfg.BaseUnitValueSource.ToString());

        /*Target.AddField("Zero", Target.Name)
            .WithStatic()
            .WithIsReadOnly()
            .WithConstValue($"new {Target.Name}(0, BaseUnit)");*/
    }

    private string UnitTypeName => Cfg.TargetUnitTypename.Declaration;
}
