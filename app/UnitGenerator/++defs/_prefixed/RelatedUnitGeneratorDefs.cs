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
                    .WithPrefixedUnit("g", null, 0.001m, null, TypeCodeAliases.Make("gram", "grams"))
                    .WithPrefixedUnit("oz", "Ounce", 0.001m * 28.349523125m, extraSettings: info =>
                    {
                        // https://pl.wikipedia.org/wiki/Uncja
                        info.Description = "International ounce";
                        info.System      = UnitSystem.Imperial;
                        // ℥
                    })
                    .WithPrefixedUnit("oz t", "TroyOunce", 0.001m * 31.1034768m, extraSettings: info =>
                    {
                        // https://pl.wikipedia.org/wiki/Uncja
                        info.Description = "International troy ounce";
                        info.System      = UnitSystem.Imperial;
                        // ℥
                    })
                    .WithPrefixedUnit("lbs", "Pound", 0.45359237m, extraSettings: info =>
                    {
                        // https://en.wikipedia.org/wiki/Pound_(mass)
                        // info.Description = "International troy ounce";
                        info.System = UnitSystem.Imperial;
                        // ℥
                    }),
                new RelatedUnit(nameof(Length)).WithLengths(1),

                new RelatedUnit(nameof(Area)).WithLengths(2),

                new RelatedUnit(nameof(Volume)).WithLengths(3),

                new RelatedUnit(nameof(Force))
                    .WithPrefixedUnit("N", "Newton", 1)
                    .WithPrefixedUnits("N", "Newton", CommonPrefixes.Kilo | CommonPrefixes.Mega | CommonPrefixes.Mili),

                GetPowerUnits(),

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
                    .WithPrefixedUnit("kcal", "KiloCalorie", 4185.5m),

                new RelatedUnit("Pressure")
                    .WithPrefixedUnit("Pa", "Pascal", 1)
                    .WithPrefixedUnit("hPa", "hectoPascal", 100)
                    .WithPrefixedUnits("Pa", "Pascal",
                        CommonPrefixes.Kilo | CommonPrefixes.Mega | CommonPrefixes.Giga),

                GetEnergyMassDensity(),
                GetLinearDensity()
            };
            return arr;
        }

        private static RelatedUnit GetEnergyMassDensity()
        {
            var unit = new RelatedUnit(nameof(EnergyMassDensity));

            void Add(string energyFieldName, string massFieldName)
            {
                unit = unit.AddFraction<EnergyMassDensityUnit>(
                    typeof( EnergyUnits), energyFieldName, 
                    typeof(MassUnits), massFieldName, true);
            }
            Add(nameof(EnergyUnits.KiloJoule), nameof(MassUnits.Kg));
            Add(nameof(EnergyUnits.MegaJoule), nameof(MassUnits.Kg));
            Add(nameof(EnergyUnits.MegaJoule), nameof(MassUnits.Tone));
            Add(nameof(EnergyUnits.GigaJoule), nameof(MassUnits.Tone));
            Add(nameof(EnergyUnits.KiloWattHour), nameof(MassUnits.Tone));
            return unit;
        }

        private static RelatedUnit GetLinearDensity()
        {
            var unit = new RelatedUnit(nameof(LinearDensity));

            void Add(string energyFieldName, string massFieldName)
            {
                unit = unit.AddFraction<LinearDensityUnit>(
                    typeof(MassUnits), energyFieldName,
                    typeof(LengthUnits), massFieldName, true);
            }

            Add(nameof(MassUnits.Kg), nameof(LengthUnits.Meter));
            return unit;
        }


        private static RelatedUnit GetPowerUnits()
        {
            const decimal secondsPerYear = 1_000_000_000m / Time.SecondsPerYear;
            return new RelatedUnit(nameof(Power))
                .WithPrefixedUnit("W", "Watt", 1)
                .WithPrefixedUnit("GJ/year", "GigaJoulePerYear", secondsPerYear)
                .WithPrefixedUnits("W", "Watt",
                    CommonPrefixes.Kilo | CommonPrefixes.Mega | CommonPrefixes.Giga | CommonPrefixes.Mili);
        }

        private static RelatedUnitCollection _all;

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
    }
}
