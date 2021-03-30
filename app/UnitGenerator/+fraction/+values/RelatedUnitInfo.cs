using iSukces.Code;

namespace UnitGenerator
{
    public class RelatedUnitInfo : IRelatedUnitDefinition
    {
        public RelatedUnitInfo(string fieldName, string unitShortCode, string fromMethodNameSufix)
        {
            unitShortCode       = unitShortCode?.Trim();
            fieldName           = fieldName.CoalesceNullOrWhiteSpace(unitShortCode);
            FieldName           = fieldName.Trim().FirstUpper();
            UnitShortCode       = unitShortCode;
            FromMethodNameSufix = fromMethodNameSufix;
        }

        public override string ToString()
        {
            return $"FieldName={FieldName}, UnitShortCode={UnitShortCode}, FromMethodNameSufix={FromMethodNameSufix}";
        }

        public string FieldName { get; }

        public string UnitShortCode { get; }

        public string FromMethodNameSufix { get; }
    }
}