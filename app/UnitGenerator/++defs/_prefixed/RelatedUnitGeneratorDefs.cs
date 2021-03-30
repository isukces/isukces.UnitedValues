using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class RelatedUnitGeneratorDefs
    {
        private static RelatedUnit[] GetAllItems()
        {
            var arr = new[]
            {
                new RelatedUnit(nameof(Mass))
                    .WithPrefixedUnit("kg", null, 1)
                    .WithPrefixedUnit("t", null, 1000, null, TypeCodeAliases.Make("tone", "tons"))
                    .WithPrefixedUnit("g", null, 0.001m, null, TypeCodeAliases.Make("gram", "grams")),
                new RelatedUnit(nameof(Length)).WithLengths(1),
                
                new RelatedUnit(nameof(Area)).WithLengths(2),
                
                new RelatedUnit(nameof(Volume)).WithLengths(3),

                new RelatedUnit(nameof(Force))
                    .WithPrefixedUnit("N", "Newton", 1)
                    .WithPrefixedUnits("N", "Newton", CommonPrefixes.Kilo | CommonPrefixes.Mega | CommonPrefixes.Mili),

                new RelatedUnit(nameof(Time)).WithTime(1),
                new RelatedUnit(nameof(SquareTime)).WithTime(2),

                new RelatedUnit(nameof(CelsiusTemperature))
                    .WithPrefixedUnit("°C", "Degree", 1),
                new RelatedUnit(nameof(KelvinTemperature))
                    .WithPrefixedUnit("K", "Degree", 1),

                new RelatedUnit(nameof(Energy))
                    .WithPrefixedUnit("J", "Joule", 1)
                    .WithPrefixedUnits("J", "Joule", CommonPrefixes.Kilo | CommonPrefixes.Mega | CommonPrefixes.Giga)
                    .WithPrefixedUnit("Wh", "WattHour", 3600)
                    .WithPrefixedUnit("kWh", "KiloWattHour", 3600_000)
                    .WithPrefixedUnit("MWh", "MegaWattHour", 3600_000_000)
                    .WithPrefixedUnit("GWh", "GigaWattHour", 3600_000_000_000)
                    .WithPrefixedUnit("cal", "Calorie", 4.1855m)
                    .WithPrefixedUnit("kcal", "KiloCalorie", 4185.5m)
            };
            return arr;
        }

        public static RelatedUnitCollection All
        {
            get
            {
                if (!(_all is null))
                    return _all;
                var items = GetAllItems();
                _all = new RelatedUnitCollection(items);

                return _all;
            }
        }

        private static RelatedUnitCollection _all;
    }
}