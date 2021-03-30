using System.Collections.Generic;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitGenerator : BaseGenerator<DerivedUnit>
    {
        public DerivedUnitGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Target.IsStatic = true;
            Add_AllProperty();
            Add_Properties();
            Add_Register();

            Target.WithAttributeFromName(nameof(UnitsContainerAttribute));
            var m = Target.AddMethod("RegisterUnitExchangeFactors", "void")
                .WithStatic()
                .WithBody("factors.RegisterMany(All);");
            m.AddParam<UnitExchangeFactors>("factors", Target);
        }

        protected override string GetTypename(DerivedUnit cfg)
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
                cw.WriteLine(i.FieldName + (index < max ? "," : ""));
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
                var type = new Args(Cfg.Name + "Unit").MakeGenericType("UnitDefinition");
                var args = new[]
                {
                    i.UnitShortCode.CsEncode(),
                    i.ScaleFactor
                };

                if (i.Aliases != null)
                    args = i.Aliases.Plus(args);

                // public static readonly UnitDefinition<LengthUnit> Km
                // = new UnitDefinition<LengthUnit>("km", 1000m);
                var value = new Args(args).Create(type);
                Target.AddField(i.FieldName, type)
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
                var o  = u.FieldName.Substring(i.My.Length);
                var p1 = u.FieldName;
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