using System.Linq;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGenerator : BaseGenerator<DerivedUnitInfo>
    {
        public DerivedUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Target.IsStatic = true;
            Add_AllProperty();
            Add_Properties();
            Add_Register();
        }

        protected override string GetTypename(DerivedUnitInfo cfg)
        {
            return cfg.Name + "Units";
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("System.Collections.Generic");
        }

        private void Add_AllProperty()
        {
            var cw = new CsCodeWriter();
            cw.Open("return new []");
            var max = Cfg.Units.Count - 1;
            for (var index = 0; index <= max; index++)
            {
                var i = Cfg.Units[index];
                cw.WriteLine(i.PropertyName + (index < max ? "," : ""));
            }

            cw.DecIndent();
            cw.WriteLine("};");
            Target.AddProperty("All", "IReadOnlyList<UnitDefinition<" + Cfg.Name + "Unit>>")
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithStatic()
                .WithOwnGetter(cw.Code)
                .Description = $"All known {Cfg.Name.FirstLower()} units";
        }

        private void Add_Properties()
        {
            foreach (var i in Cfg.Units)
            {
                var type = "UnitDefinition<" + Cfg.Name + "Unit>";
                var args = new[]
                {
                    i.UnitShortName.CsEncode(),
                    i.Multiplicator,
                    i.NameSingular.CsEncode(),
                    i.NamePlural.CsEncode()
                }.Where(a => a != "null");

                var value = new Args(args).Create(type);
                Target.AddField(i.PropertyName, type)
                    .WithIsReadOnly()
                    .WithStatic()
                    .WithConstValue(value);
            }
        }

        private void Add_Register()
        {
            if (Cfg.PrefixRelations.Count == 0)
                return;
            var cw = new CsCodeWriter();
            foreach (var i in Cfg.PrefixRelations)
            foreach (var u in Cfg.Units)
            {
                var o  = u.PropertyName.Substring(i.My.Length);
                var p1 = u.PropertyName;
                var p2 = i.OtherUnitContainer + "s." + i.Other + o;
                var q  = $"dict.AddRelated<{i.MyUnitContainer}, {i.OtherUnitContainer}>({p1}, {p2});";
                cw.WriteLine(q);
                q = $"dict.AddRelated<{i.OtherUnitContainer}, {i.MyUnitContainer}>({p2}, {p1});";
                cw.WriteLine(q);
            }

            Target.AddMethod("Register", "void")
                .WithBody(cw)
                .WithStatic()
                .WithVisibility(Visibilities.Internal)
                .AddParam<UnitRelationsDictionary>("dict", Target);
        }
    }
}