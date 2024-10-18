using System.IO;

namespace UnitGenerator;

public class ProductValuesGeneratorRunner
{
    public static void Run(string basePath, string nameSpace)
    {
        var infos     = ProductUnitDefs.All;
        var path      = Path.Combine(basePath, "+IUnitedValue", "+Product");
        var generator = new ProductValuesGenerator(path, nameSpace);
        generator.Generate(infos.Items);

        path = Path.Combine(basePath, "+jsonConverters", "+Product");
        var jsonConverter =
            new UnitJsonConverterGenerator(path, nameSpace)
            {
                ClassicImpl = true
            };
        jsonConverter.Generate(infos.Items);
    }
}