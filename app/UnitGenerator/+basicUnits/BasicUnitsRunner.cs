using System.IO;
using System.Linq;

namespace UnitGenerator
{
    public class BasicUnitsRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var data = @"
Force,+,Newton
Weight,+,Kg
Length,+,Meter
Area,-,SquareMeter
Volume,-,QubicMeter
";
            var infos = data.Split('\n', '\r')
                .Select(UnitInfo.Parse).Where(a => a != null)
                .ToArray();
            var unitGenerator = new UnitGenerator(Path.Combine(basePath, "+IUnits"), nameSpace);
            unitGenerator.Generate(infos.Select(a => a.UnitTypeName).Distinct());

            var unitedValues = new UnitedValuesGenerator(Path.Combine(basePath, "+IUnitedValue"), nameSpace);
            unitedValues.Generate(infos);

            var jsonConverter = new UnitJsonConverterGenerator(Path.Combine(basePath, "+jsonConverters"), nameSpace);
            jsonConverter.Generate(infos);

            var ext = new UnitExtensionsGenerator(Path.Combine(basePath, "+extensions"), nameSpace);
            ext.Generate(infos);
        }
    }
}