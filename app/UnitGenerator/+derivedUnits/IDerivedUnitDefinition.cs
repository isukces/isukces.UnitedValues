namespace UnitGenerator
{
    public interface IDerivedUnitDefinition
    {
        string PropertyName        { get; }
        string UnitShortName       { get; }
        string FromMethodNameSufix { get; }
    }
}