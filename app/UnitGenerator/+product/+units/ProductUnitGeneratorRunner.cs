using System.IO;

namespace UnitGenerator
{
    public class ProductUnitGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var infos     = ProductUnitDefs.All;
            var path      = Path.Combine(basePath, "+productUnits");
            var generator = new ProductUnitGenerator(path, nameSpace);
            generator.Generate(infos.Items);

            /*
            var gen2 = new CommonProductalUnitsGenerator(nameSpace);
            gen2.Generate(CommonProductalUnitDefs.All);
            
            path = Path.Combine(path, "+common");
            gen2.Save(path);
        */
        }
    }
}