using System.IO;

namespace UnitGenerator
{
    public class FractionUnitGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var infos     = FractionUnitDefs.All;
            var path   = Path.Combine(basePath, "+fractionUnits");
            var generator = new FractionUnitGenerator(path, nameSpace);
            generator.Generate(infos.Items);

            var gen2 = new CommonFractionalUnitsGenerator(nameSpace);
            gen2.Generate(CommonFractionalUnitDefs.All);
            
            path = Path.Combine(path, "+common");
            gen2.Save(path);
        }
    }
}