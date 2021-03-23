using System;
using System.Collections.Generic;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public class UnitExtensionsGenerator : BaseGenerator<PrimitiveUnit>
    {
        public UnitExtensionsGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Target.IsStatic = true;

            CsMethod Add1(string itemType, Action<CsCodeWriter> actions)
            {
                var cw = new CsCodeWriter();
                cw.WriteLine();
                cw.SingleLineIf("items is null", ReturnValue(Cfg.ValueTypeName + ".Zero"));

                actions(cw);
                var m = Target.AddMethod("Sum", Cfg.ValueTypeName)
                    .WithStatic()
                    .WithBody(cw);
                m.AddParam("items", MakeGenericType<IEnumerable<int>>(Target, itemType)).UseThis = true;
                return m;
            }

            Add1(Cfg.ValueTypeName, cw =>
            {
                cw.WriteLine("var c = items.ToArray();");
                cw.SingleLineIf("c.Length == 0", ReturnValue(Cfg.ValueTypeName + ".Zero"));
                cw.SingleLineIf("c.Length == 1", ReturnValue("c[0]"));
                cw.WriteLine("var unit  = c[0].Unit;");
                cw.WriteLine("var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);");
                cw.WriteLine(ReturnValue($"new {Cfg.ValueTypeName}(value, unit)"));
            });

            Add1(Cfg.ValueTypeName + "?", cw =>
            {
                var c = "items.Where(a => a != null).Select(a => a.Value).Sum()";
                cw.WriteLine(ReturnValue(c));
            });

            var mm = Add1("T", cw =>
            {
                var c = "items.Select(map).Sum()";
                cw.WriteLine(ReturnValue(c));
            });

            mm.GenericArguments = new CsGenericArguments("T");
            mm.AddParam("map", "Func<T, " + Cfg.ValueTypeName + ">");
        }

        protected override string GetTypename(PrimitiveUnit cfg)
        {
            return cfg.ValueTypeName + "Extensions";
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("System.Linq");
            file.AddImportNamespace("System.Collections.Generic");
        }
    }
}