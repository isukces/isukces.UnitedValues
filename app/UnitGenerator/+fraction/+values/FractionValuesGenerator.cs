using System;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using Self = UnitGenerator.FractionValuesGenerator;

namespace UnitGenerator;

internal class FractionValuesGenerator : BaseCompositeValuesGenerator<FractionUnit>
{
    public FractionValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
    {
    }

    protected override void Add_GetBaseUnitValue()
    {
        var cs = Ext.Create<BasicUnitValuesGenerator>();
        cs.WriteLine("var factor1 = GlobalUnitRegistry.Factors.Get(Unit.CounterUnit);");
        cs.WriteLine("var factor2 = GlobalUnitRegistry.Factors.Get(Unit.DenominatorUnit);");
        cs.SingleLineIf("(factor1.HasValue && factor2.HasValue)", ReturnValue("Value * factor1.Value / factor2.Value"));
        var exceptionMessage = new CsExpression("Unable to find multiplication for unit ".CsEncode())
                               + new CsExpression("Unit");

        cs.Throw<Exception>(exceptionMessage.ToString());
        Target.AddMethod("GetBaseUnitValue", ValuePropertyType)
            .WithBody(cs);

    }


    protected override Col1 GetConstructorProperties()
    {
        return new Col1(new[]
        {
            new ConstructorParameterInfo(ValuePropName,
                ValuePropertyType,
                null,
                "value"),
            new ConstructorParameterInfo(UnitPropName,
                (CsType)Cfg.UnitTypes.Unit.GetTypename(), null, "unit")
        });
    }


    protected override CompositeUnitGeneratorInfo GetInfo()
    {
        return CompositeUnitGeneratorInfo.Make(Cfg);
    }

    protected override void Add_Parse()
    {
        const string splitMethodName = nameof(Common) + "." + nameof(Common.SplitUnitNameBySlash);
        //Add_Parse(splitMethodName);

        bool isBasicUnit(TypesGroup g)
        {
            if (!_resolver.TryGetValue(g.Unit.GetTypename(), out var t)) return false;
            if (t.Implements<ICompositeUnit>())
                return false;
            return true;

        }

        if (isBasicUnit(Cfg.CounterUnit) && isBasicUnit(Cfg.DenominatorUnit))

            Add_Parse(splitMethodName);
        else
            Add_Parse(null);
    }


    protected override string GetTypename(FractionUnit cfg)
    {
        return Cfg.UnitTypes.Value.ValueTypeName;
    }

    protected override void Add_FromMethods()
    {
        var collection  = CommonFractionalUnitDefs.All;
        var commonUnits = collection.GetBy(Cfg.UnitTypes.Unit);
        if (commonUnits.Length == 0)
        {
            return;
        }
        foreach (var i in commonUnits)
        {
            var u = new RelatedUnitInfo(i.TargetPropertyName,
                UnitShortCodeSource.MakeDirect(i.GetUnitName()),
                i.TargetPropertyName);
            BasicUnitValuesGenerator.Add_FromMethods(
                GetType(),
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
