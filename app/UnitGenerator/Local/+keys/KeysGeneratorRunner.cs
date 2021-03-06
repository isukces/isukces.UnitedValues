using System.Collections.Generic;
using System.IO;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.CodeWrite;

namespace UnitGenerator.Local
{
    public class KeysGeneratorRunner
    {
        public static void Run(string basePath)
        {
            var gen = new KeysGenerator();
            var a   = typeof(KeysGeneratorRunner).Assembly;

            void AddString(string n, string p = "Value")
            {
                gen.Add(new KeysGeneratorDef(n, a, WrappedTypes.String, p));
            }

            AddString(nameof(XValueTypeName), nameof(XValueTypeName.ValueTypeName));
            AddString(nameof(XUnitTypeName), nameof(XUnitTypeName.TypeName));
            AddString(nameof(XUnitContainerTypeName), nameof(XUnitContainerTypeName.TypeName));

            var file = new CsFile();
            file.AddImportNamespace("System");
            var classes = new Dictionary<TypeProvider, CsClass>();
            IAutoCodeGeneratorContext ctx =
                new AutoCodeGenerator.SimpleAutoCodeGeneratorContext(file,
                    type =>
                    {
                        var c = file.GetOrCreateClass(type, classes);
                        c.IsPartial = true;
                        return c;
                    });

            gen.AssemblyStart(a, ctx);
            gen.AssemblyEnd(a, ctx);

            var filename = Path.Combine(basePath, "Keys.auto.cs");
            file.SaveIfDifferent(filename);
        }
    }
}