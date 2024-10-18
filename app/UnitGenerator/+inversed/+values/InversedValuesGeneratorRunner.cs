using System.IO;

namespace UnitGenerator;

public class InversedValuesGeneratorRunner
{
    public static void Run(string basePath, string nameSpace)
    {
        var infos     = InversedUnitDefs.All;
        var path      = Path.Combine(basePath, "+IUnitedValue", "+inversed");
        var generator = new InversedValuesGenerator(path, nameSpace);
        generator.Generate(infos.Items);

        path = Path.Combine(basePath, "+jsonConverters", "+Inversed");
        var jsonConverter =
            new UnitJsonConverterGenerator(path, nameSpace)
            {
                ClassicImpl = true
            };
        // jsonConverter.Generate(infos.Items);
    }
}