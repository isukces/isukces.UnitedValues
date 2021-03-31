using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using JetBrains.Annotations;

namespace UnitGenerator
{
    public class DerivedUnitGenerator : BaseGenerator<RelatedUnit>
    {
        public DerivedUnitGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Related         = RelatedUnitGeneratorDefs.All.GetPowers(Cfg.Name.ToUnitTypeName());
            Target.IsStatic = true;
            Add_AllProperty();
            Add_Properties();
            Add_Register();
            Add_RegisterUnitExchangeFactors();
            Add_TryRecoverUnitFromName();
        }
        

        private void Add_TryRecoverUnitFromName()
        {
            var cw = Ext.Create(GetType());

            const ArgChecking flags = ArgChecking.NormalizedString;
            cw.CheckArgument("unitName", flags, Target);
            cw.Open("foreach (var i in All)");
            cw.SingleLineIf("unitName == i.UnitName", "return i.Unit;");
            cw.Close();

            var resultTypeName = Cfg.Name.ToUnitTypeName().GetTypename();
            cw.WriteReturn(new Args("unitName").Create(resultTypeName));
            var m = Target.AddMethod("TryRecoverUnitFromName", resultTypeName)
                .WithStatic()
                .WithBody(cw);
            var p = m.AddParam("unitName", "string");
            p.WithAttribute(CsAttribute.Make<NotNullAttribute>(Target));
        }

        private void Add_RegisterUnitExchangeFactors()
        {
            Target.WithAttributeFromName(nameof(UnitsContainerAttribute));
            var m = Target.AddMethod("RegisterUnitExchangeFactors", "void")
                .WithStatic()
                .WithBody("factors.RegisterMany(All);");
            m.AddParam<UnitExchangeFactors>("factors", Target);
        }


        protected override string GetTypename(RelatedUnit cfg)
        {
            return cfg.Name.ToUnitTypeName().ToUnitContainerTypeName().TypeName;
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
                var unitTypeName = Cfg.Name.ToUnitTypeName().GetTypename();

                var n2 = i.FieldName + unitTypeName;
                {
                    var args       = i.UnitShortCode.GetCreationArgs(Related);
                    var constValue = args.Create(unitTypeName);

                    Target.AddField(n2, unitTypeName)
                        .WithIsReadOnly()
                        .WithVisibility(Visibilities.Private)
                        .WithConstValue(constValue)
                        .WithStatic();
                }
                {
                    var args = new[]
                    {
                        n2,
                        i.ScaleFactor
                    };

                    if (i.Aliases != null)
                        args = i.Aliases.Plus(args);

                    var unitDefinitionType = new Args(unitTypeName)
                        .MakeGenericType("UnitDefinition");

                    // public static readonly UnitDefinition<LengthUnit> Km
                    // = new UnitDefinition<LengthUnit>("km", 1000m);
                    var value = new Args(args).Create(unitDefinitionType);
                    Target.AddField(i.FieldName, unitDefinitionType)
                        .WithIsReadOnly()
                        .WithStatic()
                        .WithConstValue(value);
                }
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

        public RelatedUnitsFamily Related { get; set; }
    }
}