using iSukces.Code;

namespace UnitGenerator;

public class RelatedUnitInfo : IRelatedUnitDefinition
{
    public RelatedUnitInfo(string fieldName, UnitShortCodeSource unitShortCode, string fromMethodNameSufix)
    {
        // unitShortCode       = unitShortCode?.Trim();
        fieldName           = fieldName.CoalesceNullOrWhiteSpace(unitShortCode. EffectiveValue);
        FieldName           = fieldName.Trim().FirstUpper();
        UnitShortCode       = unitShortCode;
        FromMethodNameSufix = fromMethodNameSufix;
    }

    public override string ToString()
    {
        return $"FieldName={FieldName}, UnitShortCode={UnitShortCode}, FromMethodNameSufix={FromMethodNameSufix}";
    }

    public string FieldName { get; }

    public UnitShortCodeSource UnitShortCode { get; }

    public string FromMethodNameSufix { get; }
}
