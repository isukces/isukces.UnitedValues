using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class MultiplyAlgebraGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            var c = new MultiplicationAlgebraConfig()
                .WithMul<Length, Length, Area>(true)
                .WithMul<Length, Area, Volume>(true)
                
                
                .WithDiv<Force, Area, Pressure>(false)
                
                // .WithDiv<>()
                ;

            var tmp = new MultiplyAlgebraGenerator(nameSpace);
            tmp.CreateOperators(c);
            var path = Path.Combine(basePath, "+mulAlgebra");
            tmp.Save(path);
        }
    }
}