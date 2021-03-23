using System;
using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGeneratorRunner
    {
        public static DerivedUnitCollection GetAll()
        {
            return _lazy.Value;
        }

        public static DerivedUnit[] GetAllItems()
        {
            var arr = new[]
            {
                new DerivedUnit(nameof(Weight))
                    .WithUnit("kg", null, 1)
                    .WithUnit("t", "Tone", 1000, "ton", fromMethodNameSufix: "Tons")
                    .WithUnit("g", "Gram", 0.001m, fromMethodNameSufix: "Grams"),
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
            var arr  = GetAll();
            var path = Path.Combine(basePath, "+derivedUnits");
            var ano  = new DerivedUnitGenerator(path, nameSpace);
            ano.Generate(arr.Items);
        }

        private static readonly Lazy<DerivedUnitCollection> _lazy =
            new Lazy<DerivedUnitCollection>(() => new DerivedUnitCollection(GetAllItems()));
    }
}