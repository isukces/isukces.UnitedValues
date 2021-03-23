namespace UnitGenerator
{
    public class DerivedUnitDefinition : DerivedUnitItem, IDerivedUnitDefinition
    {
        public DerivedUnitDefinition(
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