using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class FractionUnitGeneratorRunner
    {
        public static FractionUnitInfo[] GetFractionUnits()
        {
            return Ext.GetStaticFieldsValues<FractionUnitGeneratorRunner, FractionUnitInfo>();
        }

        public static void Run(string basePath, string nameSpace)
        {
            var infos     = GetFractionUnits();
            var generator = new FractionUnitGenerator(Path.Combine(basePath, "+fractionUnits"), nameSpace);
            generator.Generate(infos);
        }


        public static readonly FractionUnitInfo LinearDensity = FractionUnitInfo.Make<LinearDensity, Weight, Length>();
        public static readonly FractionUnitInfo Density = FractionUnitInfo.Make<Density, Weight, Volume>();
        public static readonly FractionUnitInfo PlanarDensity = FractionUnitInfo.Make<PlanarDensity, Weight, Area>();
    }
}