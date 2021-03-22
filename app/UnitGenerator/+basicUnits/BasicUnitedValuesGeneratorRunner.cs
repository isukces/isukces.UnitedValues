using System.IO;
using System.Linq;

namespace UnitGenerator
{
    public class BasicUnitedValuesGeneratorRunner : PrimitiveValuesDefinitions
    {
        public static void Run(string basePath, string nameSpace)
        {
            var infos         = All();
            var unitGenerator = new UnitGenerator(Path.Combine(basePath, "+IUnits"), nameSpace);
            unitGenerator.Generate(infos.Select(a => a.UnitTypeName).Distinct());

            var unitedValues = new BasicUnitedValuesGenerator(Path.Combine(basePath, "+IUnitedValue"), nameSpace);
            unitedValues.Generate(infos);

            var jsonConverter = new UnitJsonConverterGenerator(Path.Combine(basePath, "+jsonConverters"), nameSpace);
            jsonConverter.Generate(infos);

            var ext = new UnitExtensionsGenerator(Path.Combine(basePath, "+extensions"), nameSpace);
            ext.Generate(infos);
        }
    }
}