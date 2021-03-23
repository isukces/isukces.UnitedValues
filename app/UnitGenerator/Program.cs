using System;
using System.IO;

namespace UnitGenerator
{
    internal class Program
    {
        private static DirectoryInfo FindProjectRootDirectory()
        {
            var projectRoot = new FileInfo(typeof(Program).Assembly.Location).Directory;
            while (true)
            {
                var ff = Path.Combine(projectRoot.FullName, ".gitignore ");
                if (File.Exists(ff))
                    break;
                projectRoot = projectRoot.Parent;
            }

            return projectRoot;
        }

        private static void Main(string[] args)
        {
            var projectRoot = FindProjectRootDirectory();
            var basePath    = Path.Combine(projectRoot.FullName, "app", "iSukces.UnitedValues");
            var nameSpace   = "iSukces.UnitedValues";

            BasicUnitValuesGeneratorRunner.Run(basePath, nameSpace);
            FractionUnitGeneratorRunner.Run(basePath, nameSpace);
            DerivedUnitGeneratorRunner.Run(basePath, nameSpace);
            FractionValuesGeneratorRunner.Run(basePath, nameSpace);

            // AlgebraGeneratorRunner.Run(basePath, nameSpace);
            MultiplyAlgebraGeneratorRunner.Run(basePath, nameSpace);

            Console.WriteLine("Done");
        }
    }
}