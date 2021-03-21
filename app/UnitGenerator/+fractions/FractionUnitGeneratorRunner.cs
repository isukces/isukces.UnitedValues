using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class FractionUnitGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var infos = new[]
            {
                new FractionUnitInfo(new ValueGroup("LinearDensity"), nameof(WeightUnit), nameof(LengthUnit)),
                new FractionUnitInfo(new ValueGroup("Density"), nameof(WeightUnit), nameof(VolumeUnit)),
                new FractionUnitInfo(new ValueGroup("PlanarDensity"), nameof(WeightUnit), nameof(AreaUnit))
            };
            var generator = new FractionUnitGenerator(Path.Combine(basePath, "+fractionUnits"), nameSpace);
            generator.Generate(infos);
            var path = Path.Combine(basePath, "+jsonConverters");
            var jsonConverter =
                new UnitJsonConverterGenerator(path, nameSpace)
                {
                    ClassicImpl = true
                };
            jsonConverter.Generate(infos);
        }
    }
}