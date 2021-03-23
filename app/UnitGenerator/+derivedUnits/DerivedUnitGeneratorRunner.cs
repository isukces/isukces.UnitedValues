using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGeneratorRunner
    {
        public static DerivedUnit[] GetAllItems()
        {
            var arr = new[]
            {
                new DerivedUnit(nameof(Weight))
                    .WithUnit("kg", null, 1)
                    .WithUnit("t", null, 1000, null, TypeCodeAliases.Make("tone", "tons"))
                    .WithUnit("g", null, 0.001m, null, TypeCodeAliases.Make("gram", "grams")),
                new DerivedUnit(nameof(Length)).WithLengths(1),
                new DerivedUnit(nameof(Area)).WithLengths(2),
                new DerivedUnit(nameof(Volume)).WithLengths(3),

                new DerivedUnit(nameof(Force))
                    .WithUnit("N", "Newton", 1)
                    .WithUnit("kN", "KiloNewton", 1000)
                    .WithUnit("MN", "MegaNewton", 1000_000)
                    .WithUnit("mN", "MiliNewton", 0.001m),

                new DerivedUnit(nameof(Time)).WithTime(1),
                new DerivedUnit(nameof(SquareTime)).WithTime(2),

                new DerivedUnit(nameof(CelsiusTemperature))
                    .WithUnit("°C", "Degree", 1),
                new DerivedUnit(nameof(KelvinTemperature))
                    .WithUnit("K", "Degree", 1)
            };
            return arr;
        }

        public static void Run(string basePath, string nameSpace)
        {
            var arr  = All;
            var path = Path.Combine(basePath, "+derivedUnits");
            var ano  = new DerivedUnitGenerator(path, nameSpace);
            ano.Generate(arr.Items);
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
}