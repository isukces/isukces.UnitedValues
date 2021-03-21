using System;
using System.Collections.Generic;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public class UnitExtensionsGenerator : BaseGenerator<UnitInfo>
    {
        public UnitExtensionsGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            cl.IsStatic = true;

            CsMethod Add1(string itemType, Action<CsCodeWriter> actions)
            {
                var cw = new CsCodeWriter();
                cw.WriteLine();
                cw.SingleLineIf("items is null", ReturnValue(Cfg.Name + ".Zero"));

                actions(cw);
                var m = cl.AddMethod("Sum", Cfg.Name)
                    .WithStatic()
                    .WithBody(cw);
                m.AddParam("items", MakeGenericType<IEnumerable<int>>(cl, itemType)).UseThis = true;
                return m;
            }

            Add1(Cfg.Name, cw =>
            {
                cw.WriteLine("var c = items.ToArray();");
                cw.SingleLineIf("c.Length == 0", ReturnValue(Cfg.Name + ".Zero"));
                cw.SingleLineIf("c.Length == 1", ReturnValue("c[0]"));
                cw.WriteLine("var unit  = c[0].Unit;");
                cw.WriteLine("var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);");
                cw.WriteLine(ReturnValue($"new {Cfg.Name}(value, unit)"));
            });

            Add1(Cfg.Name + "?", cw =>
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
            mm.AddParam("map", "Func<T, " + Cfg.Name + ">");
        }

        protected override string GetTypename(UnitInfo unit)
        {
            return unit.Name + "Extensions";
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("System.Linq");
            file.AddImportNamespace("System.Collections.Generic");
        }
    }
}