using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class FractionUnitGeneratorRunner
    {
        public static FractionUnitInfo[] GetFractionUnits()
        {
            var infos = new[]
            {
                FractionUnitInfo.Make<LinearDensity, Weight, Length>(),
                FractionUnitInfo.Make<Density, Weight, Volume>(),
                FractionUnitInfo.Make<PlanarDensity, Weight, Area>(),
            };
            return infos;
        }

        public static void Run(string basePath, string nameSpace)
        {
            var infos     = GetFractionUnits();
            var generator = new FractionUnitGenerator(Path.Combine(basePath, "+fractionUnits"), nameSpace);
            generator.Generate(infos);
        }
    }
}