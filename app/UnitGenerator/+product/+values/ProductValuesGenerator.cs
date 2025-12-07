using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using Self = UnitGenerator.ProductValuesGenerator;

namespace UnitGenerator;

internal class ProductValuesGenerator : BaseCompositeValuesGenerator<ProductUnit>
{
    public ProductValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
    {
    }

    protected override void Add_FromMethods()
    {
    }

    protected override void Add_Parse()
    {
        const string splitMethodName = nameof(Common) + "." + nameof(Common.SplitUnitNameByTimesSign);
        Add_Parse(splitMethodName);
    }

    protected override void GenerateOne()
    {
        base.GenerateOne();
        Add_SerializeToJson();
    }

    protected override Writers GetConstructorProperties()
    {
        return new Writers([
            new ConstructorParameterInfo(ValuePropName,
                ValuePropertyType,
                null,
                "value"),
            new ConstructorParameterInfo(UnitPropName,
                (CsType)Cfg.UnitTypes.Unit.TypeName, null, "unit")
        ]);
    }

    protected override CompositeUnitGeneratorInfo GetInfo()
    {
        return CompositeUnitGeneratorInfo.Make(Cfg);
    }


    protected override string GetTypename(ProductUnit cfg)
    {
        return Cfg.UnitTypes.Value.ValueTypeName;
    }

    protected override void PrepareFile(CsFile file)
    {
        base.PrepareFile(file);
        file.AddImportNamespace("Newtonsoft.Json");
    }

    private void Add_SerializeToJson()
    {
        var cw = Ext.Create<Self>();
        cw.WriteLine("var l = Unit.LeftUnit.UnitName ?? string.Empty;");
        cw.WriteLine("var r = Unit.RightUnit.UnitName ?? string.Empty;");
        cw.SingleLineIf("l.Length==1 && r.Length==1", "return ToString();");
        cw.WriteLine("return Value.ToString(CultureInfo.InvariantCulture) + l + Common.TimesSign + r;");
        Target.AddMethod("SerializeToJson", CsType.String)
            .WithBody(cw);
    }
}
