using System.Collections.Generic;
using System.IO;

namespace UnitGenerator
{
    public class FractionUnitGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var infos     = FractionUnitDefs.AllFractionUnits;
            var generator = new FractionUnitGenerator(Path.Combine(basePath, "+fractionUnits"), nameSpace);
            generator.Generate(infos.Items);

            var gen2 = new CommonFractionalUnitsGenerator(nameSpace);
            gen2.Generate(CommonFractionalUnits.GetAll());
            gen2.Save(Path.Combine(basePath, "+++temp"));
        }
    }
}