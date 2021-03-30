using System.IO;

namespace UnitGenerator
{
    public class DerivedUnitGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var arr  = RelatedUnitGeneratorDefs.All;
            var path = Path.Combine(basePath, "+derivedUnits");
            var ano  = new DerivedUnitGenerator(path, nameSpace);
            ano.Generate(arr.Items);
        }
    }
}