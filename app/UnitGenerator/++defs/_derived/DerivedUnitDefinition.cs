using iSukces.Code;

namespace UnitGenerator
{
    public class DerivedUnitDefinition : IDerivedUnitDefinition
    {
        public DerivedUnitDefinition(string unitShortName, string multiplicator, string nameSingular, string namePlural,
            string propertyName, string fromMethodNameSufix)
        {
            if (string.IsNullOrEmpty(namePlural) && !string.IsNullOrEmpty(nameSingular))
                namePlural = nameSingular + "s";
            UnitShortName       = unitShortName;
            Multiplicator       = multiplicator;
            NameSingular        = nameSingular;
            NamePlural          = namePlural;
            FromMethodNameSufix = fromMethodNameSufix;

            if (string.IsNullOrEmpty(propertyName))
                propertyName = UnitShortName;
            PropertyName = propertyName.FirstUpper();
        }

        public override string ToString()
        {
            return
                $"UnitShortName={UnitShortName}, Multiplicator={Multiplicator}, NameSingular={NameSingular}, NamePlural={NamePlural}";
        }

        public string UnitShortName { get; }

        public string Multiplicator { get; }

        public string NameSingular { get; }

        public string NamePlural          { get; }
        public string FromMethodNameSufix { get; }
        public string PropertyName        { get; }
    }
}