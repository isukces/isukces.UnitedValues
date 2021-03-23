namespace UnitGenerator
{
    public interface IDerivedUnitDefinition
    {
        string FieldName           { get; }
        string UnitShortCode       { get; }
        string FromMethodNameSufix { get; }
    }
}