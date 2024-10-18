using System.IO;

namespace UnitGenerator;

public class BasicUnitValuesGeneratorRunner : BasicUnitDefs
{
    public static void Run(string basePath, string nameSpace)
    {
        var infos         = All;
        var unitGenerator = new BasicUnitGenerator(Path.Combine(basePath, "+IUnits"), nameSpace);
        unitGenerator.Generate(infos.DistinctNames);

        var unitedValues = new BasicUnitValuesGenerator(Path.Combine(basePath, "+IUnitedValue"), nameSpace);
        unitedValues.Generate(infos.Items);

        var jsonConverter = new UnitJsonConverterGenerator(Path.Combine(basePath, "+jsonConverters"), nameSpace);
        jsonConverter.Generate(infos.Items);

        var ext = new UnitExtensionsGenerator(Path.Combine(basePath, "+extensions"), nameSpace);
        ext.Generate(infos.Items);
    }
}