using System.IO;

namespace UnitGenerator;

public class ThermalValuesGeneratorRunner
{
    public static void Run(string basePath, string nameSpace)
    {
        var infos     = ThermaUnitDefs.All;
        var path      = Path.Combine(basePath, "+IUnitedValue", "+thermal");
        var generator = new ThermalValuesGenerator(path, nameSpace);
        generator.Generate(infos.Items);

        path = Path.Combine(basePath, "+jsonConverters", "+Thermal");
        var jsonConverter =
            new UnitJsonConverterGenerator(path, nameSpace)
            {
                ClassicImpl = true
            };
        // jsonConverter.Generate(infos.Items);
    }
}
