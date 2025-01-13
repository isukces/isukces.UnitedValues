using System.IO;

namespace UnitGenerator;

public class InversedUnitGeneratorRunner
{
    public static void Run(string basePath, string nameSpace)
    {
        var infos     = InversedUnitDefs.All;
        var path      = Path.Combine(basePath, "+inversedUnits");
        var generator = new InversedUnitGenerator(path, nameSpace);
        generator.Generate(infos.Items);

        var gen2 = new InversedUnitContainerGenerator(path, nameSpace);
        gen2.Generate(infos.Items);
        /*
        var gen2 = new CommonInversedUnitsGenerator(nameSpace);
        gen2.Generate(InversedUnitDefs.All);

        path = Path.Combine(path, "+common");
        gen2.Save(path);
    */
    }
}
