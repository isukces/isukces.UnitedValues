using System.Collections.Generic;
using System.IO;
using iSukces.Code;
using iSukces.Code.AutoCode;

namespace UnitGenerator.Local;

public class KeysGeneratorRunner
{
    public static void Run(string basePath)
    {
        var gen = new KeysGenerator();
        var a   = typeof(KeysGeneratorRunner).Assembly;

        AddString(nameof(XValueTypeName), nameof(XValueTypeName.ValueTypeName));
        AddString(nameof(XUnitTypeName), nameof(XUnitTypeName.TypeName));
        AddString(nameof(XUnitContainerTypeName), nameof(XUnitContainerTypeName.TypeName));

        var file = new CsFile
        {
            Nullable = FileNullableOption.GlobalEnabled,
        };
        file.AddImportNamespace("System");
        IAutoCodeGeneratorContext ctx =
            new AutoCodeGenerator.SimpleAutoCodeGeneratorContext(file,
                type =>
                {
                    var c = file.GetOrCreateClass(type);
                    return GeneratorCommon.Setup(c);
                });

        gen.AssemblyStart(a, ctx);
        gen.AssemblyEnd(a, ctx);

        var filename = Path.Combine(basePath, "Keys.auto.cs");
        file.SaveIfDifferent(filename);
        return;

        void AddString(string n, string p = "Value")
        {
            gen.Add(new KeysGeneratorDef(n, a, WrappedTypes.String, p));
        }
    }
}