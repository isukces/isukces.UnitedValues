using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGeneratorDefs
    {
        public static DerivedUnit[] GetAllItems()
        {
            var arr = new[]
            {
                new DerivedUnit(nameof(Mass))
                    .WithUnit("kg", null, 1)
                    .WithUnit("t", null, 1000, null, TypeCodeAliases.Make("tone", "tons"))
                    .WithUnit("g", null, 0.001m, null, TypeCodeAliases.Make("gram", "grams")),
                new DerivedUnit(nameof(Length)).WithLengths(1),
                new DerivedUnit(nameof(Area)).WithLengths(2),
                new DerivedUnit(nameof(Volume)).WithLengths(3),

                new DerivedUnit(nameof(Force))
                    .WithUnit("N", "Newton", 1)
                    .WithUnits("N", "Newton", Q123.Kilo | Q123.Mega | Q123.Mili),

                new DerivedUnit(nameof(Time)).WithTime(1),
                new DerivedUnit(nameof(SquareTime)).WithTime(2),

                new DerivedUnit(nameof(CelsiusTemperature))
                    .WithUnit("°C", "Degree", 1),
                new DerivedUnit(nameof(KelvinTemperature))
                    .WithUnit("K", "Degree", 1),
                
                new DerivedUnit(nameof(Energy))
                    .WithUnit("J", "Joule", 1)
                    .WithUnits("J", "Joule", Q123.Kilo | Q123.Mega | Q123.Giga)
                
                    .WithUnit("Wh", "WattHour", 3600)
                    .WithUnit("kWh", "KiloWattHour", 3600_000)
                    .WithUnit("MWh", "MegaWattHour", 3600_000_000)
                    .WithUnit("GWh", "GigaWattHour", 3600_000_000_000)
                
                    .WithUnit("cal", "Calorie", 4.1855m)
                    .WithUnit("kcal", "KiloCalorie", 4185.5m)

            };
            return arr;
        }

        public static DerivedUnitCollection All
        {
            get
            {
                if (!(_all is null))
                    return _all;
                var items = GetAllItems();
                _all = new DerivedUnitCollection(items);

                return _all;
            }
        }

        private static DerivedUnitCollection _all;
    }

    [Flags]
    public enum Q123
    {
        Kilo = 1,
        Mega = 2,
        Giga = 4,
        Mili = 8,
        Micro = 16
    };
}