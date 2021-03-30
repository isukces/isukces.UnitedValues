namespace UnitGenerator
{
    public class AliasedPrefixedUnitInfo : PrefixedUnitInfo, IRelatedUnitDefinition
    {
        public AliasedPrefixedUnitInfo(
            string fieldName,
            string unitShortCode,
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

        public TypeCodeAliases Aliases { get; }
    }
}