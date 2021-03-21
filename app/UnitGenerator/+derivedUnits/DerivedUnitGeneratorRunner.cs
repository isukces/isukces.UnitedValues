using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var arr = new[]
            {
                new DerivedUnitInfo(nameof(Weight))
                    .WithUnit("kg", null, 1)
                    .WithUnit("t", "Tone", 1000, "ton")
                    .WithUnit("g", "Gram", 0.001m),
                new DerivedUnitInfo(nameof(Length)).WithLengths(1),
                new DerivedUnitInfo(nameof(Area)).WithLengths(2),
                new DerivedUnitInfo(nameof(Volume)).WithLengths(3)
            };
            var path = Path.Combine(basePath, "+derivedUnits");
            var ano     = new DerivedUnitGenerator(path, nameSpace);
            ano.Generate(arr);
        }
    }
}