namespace UnitGenerator;

public interface IRelatedUnitDefinition
{
    string              FieldName           { get; }
    UnitShortCodeSource UnitShortCode       { get; }
    string              FromMethodNameSufix { get; }
}