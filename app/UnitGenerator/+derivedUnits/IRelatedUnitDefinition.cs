namespace UnitGenerator
{
    public interface IRelatedUnitDefinition
    {
        string FieldName           { get; }
        string UnitShortCode       { get; }
        string FromMethodNameSufix { get; }
    }
}