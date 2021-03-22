using System.IO;

namespace UnitGenerator
{
    public class FractionValuesGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var infos     = FractionUnitGeneratorRunner.GetFractionUnits();
            var path      = Path.Combine(basePath, "+IUnits", "+fraction");
            var generator = new FractionValuesGenerator(path, nameSpace);
            generator.Generate(infos);

            path = Path.Combine(basePath, "+jsonConverters", "+fraction");
            var jsonConverter =
                new UnitJsonConverterGenerator(path, nameSpace)
                {
                    ClassicImpl = true
                };
            jsonConverter.Generate(infos);
        }
    }
}