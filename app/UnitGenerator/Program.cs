using System;
using System.IO;
using UnitGenerator.Local;

namespace UnitGenerator;

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
        var basePath    = Path.Combine(projectRoot.FullName, "app", "UnitGenerator");
        KeysGeneratorRunner.Run(basePath);

            
        basePath = Path.Combine(projectRoot.FullName, "app", "iSukces.UnitedValues");
            

        var nameSpace   = "iSukces.UnitedValues";

        BasicUnitValuesGeneratorRunner.Run(basePath, nameSpace);
        FractionUnitGeneratorRunner.Run(basePath, nameSpace);
        DerivedUnitGeneratorRunner.Run(basePath, nameSpace);
        FractionValuesGeneratorRunner.Run(basePath, nameSpace);
        ProductValuesGeneratorRunner.Run(basePath, nameSpace);

        // AlgebraGeneratorRunner.Run(basePath, nameSpace);
        MultiplyAlgebraGeneratorRunner.Run(basePath, nameSpace);
        ProductUnitGeneratorRunner.Run(basePath, nameSpace);

            
            
        InversedUnitGeneratorRunner.Run(basePath, nameSpace);
        InversedValuesGeneratorRunner.Run(basePath, nameSpace);
            
        ThermalValuesGeneratorRunner.Run(basePath, nameSpace);


        CsFilesManager.Instance.Flush();
        Check.Run();
        Console.WriteLine("Done");
    }
}
