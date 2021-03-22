using iSukces.Code;

namespace UnitGenerator
{
    public class DerivedUnitDefinition
    {
        public DerivedUnitDefinition(string unitShortName, string multiplicator, string nameSingular, string namePlural,
            string propertyName)
        {
            if (string.IsNullOrEmpty(namePlural) && !string.IsNullOrEmpty(nameSingular))
                namePlural = nameSingular + "s";
            UnitShortName = unitShortName;
            Multiplicator = multiplicator;
            NameSingular  = nameSingular;
            NamePlural    = namePlural;

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

        public string NamePlural   { get; }
        public string PropertyName { get; }
    }
}