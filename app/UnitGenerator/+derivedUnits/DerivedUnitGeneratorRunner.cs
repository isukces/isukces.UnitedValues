using System;
using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGeneratorRunner
    {
        public static DerivedUnitInfoCollection GetAll()
        {
            return _lazy.Value;
        }

        public static DerivedUnitInfo[] GetAllItems()
        {
            var arr = new[]
            {
                new DerivedUnitInfo(nameof(Weight))
                    .WithUnit("kg", null, 1)
                    .WithUnit("t", "Tone", 1000, "ton", fromMethodNameSufix: "Tons")
                    .WithUnit("g", "Gram", 0.001m, fromMethodNameSufix: "Grams"),
                new DerivedUnitInfo(nameof(Length)).WithLengths(1),
                new DerivedUnitInfo(nameof(Area)).WithLengths(2),
                new DerivedUnitInfo(nameof(Volume)).WithLengths(3),

                new DerivedUnitInfo(nameof(Force))
                    .WithUnit("N", "Newton", 1)
                    .WithUnit("kN", "KiloNewton", 1000)
                    .WithUnit("MN", "MegaNewton", 1000_000)
                    .WithUnit("mN", "MiliNewton", 0.001m),

                new DerivedUnitInfo(nameof(Time)).WithTime(1),
                new DerivedUnitInfo(nameof(SquareTime)).WithTime(2)
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

        private static readonly Lazy<DerivedUnitInfoCollection> _lazy =
            new Lazy<DerivedUnitInfoCollection>(() => new DerivedUnitInfoCollection(GetAllItems()));
    }
}