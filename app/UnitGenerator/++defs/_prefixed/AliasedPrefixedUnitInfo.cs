using iSukces.UnitedValues;

namespace UnitGenerator;

public class AliasedPrefixedUnitInfo : PrefixedUnitInfo, IRelatedUnitDefinition
{
    public AliasedPrefixedUnitInfo(
        string fieldName,
        UnitShortCodeSource unitShortCode,
        string scaleFactor,
        string fromMethodNameSufix,
        TypeCodeAliases aliases)
        : base(fieldName, unitShortCode, scaleFactor, fromMethodNameSufix)
    {
        Aliases = aliases;
    }

    public override string ToString()
    {
        return
            $"UnitShortName={UnitShortCode}, Multiplicator={ScaleFactor}, NameSingular={Aliases?.NameSingular}, NamePlural={Aliases?.NamePlural}";
    }

    public TypeCodeAliases Aliases     { get; }
        
    public string     Description     { get; set; }
    public UnitSystem System          { get; set; }
    public string     UnitConstructor { get; set; }
    public bool       AddFromMethod   { get; set; }
}
