using System;
using System.Globalization;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    internal class InversedUnitContainerGenerator : BaseGenerator<InversedUnit>
    {
        public InversedUnitContainerGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        private static string Inverse(string number)
        {
            if (number == "1m")
                return number;
            if (decimal.TryParse(number.TrimEnd('m'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                return $"1m / {number}";
            if (number.Contains("*"))
                return $"1m / ({number})";
            throw new NotImplementedException();
        }


        protected override void GenerateOne()
        {
            Target.Kind     = CsNamespaceMemberKind.Class;
            Target.IsStatic = true;

            _relatedUnit =
                RelatedUnitGeneratorDefs.All.Items.Single(w => w.Name.ValueTypeName == Cfg.Source.Value.CoreName);
            Add_StaticFields();

            Add_GetInversedUnit();
            // Add_AllProperty();
            Add_StaticConstructor();
        }

        private void Add_StaticFields()
        {
            foreach (var i in _relatedUnit.Units)
            {
                var unitTypeName = Cfg.TargetUnitTypename;
                var f1Name       = i.FieldName + unitTypeName;
                var f1Type       = unitTypeName;

                var v = Cfg.Source.Container.GetTypename() + "." + i.FieldName + Cfg.Source.Unit.GetTypename();
                v = new Args(v).Create(f1Type);
                Target.AddField(f1Name, f1Type)
                    .WithStatic()
                    .WithIsReadOnly()
                    .WithVisibility(Visibilities.Internal)
                    .WithConstValue(v)
                    .Description = $"unit 1/{i.UnitShortCode.EffectiveValue}";

                var unitDefinitionType = new Args(unitTypeName)
                    .MakeGenericType("UnitDefinition");

                var value = new Args(f1Name, Inverse(i.ScaleFactor)).Create(unitDefinitionType);
                Target.AddField(i.FieldName, unitDefinitionType)
                    .WithIsReadOnly()
                    .WithStatic()
                    .WithConstValue(value)
                    .Description = $"unit 1/{i.UnitShortCode.EffectiveValue} with factor";
            }
        }

        private void Add_StaticConstructor()
        {
            var cw    = Ext.Create(GetType());
            var array = new Args(_relatedUnit.Units.Select(q => q.FieldName).ToArray());
            array.CreateArray(cw, "All = ");
            var c = Target.AddConstructor().WithStatic().WithBody(cw);

            Target.AddField("All", AllPropertyTypeName).WithStatic().WithIsReadOnly()
                .Description = $"All known {Cfg.TargetUnitTypename.FirstLower()} units";
        }

        private string AllPropertyTypeName => $"IReadOnlyList<UnitDefinition<{Cfg.TargetUnitTypename}>>";

        protected override string GetTypename(InversedUnit cfg)
        {
            return cfg.TargetContainerTypename;
        }

        /*private void Add_AllProperty()
        {
            var cw    = new CsCodeWriter();
            var array = new Args(_relatedUnit.Units.Select(q => q.FieldName).ToArray());
            array.CreateArray(cw, "return ");

            Target.AddProperty("All", AllPropertyTypeName)
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithStatic()
                .WithOwnGetter("return _all;")
                .Description = $"All known {Cfg.TargetUnitTypename.FirstLower()} units";
        }*/

        private void Add_GetInversedUnit()
        {
            var cs = Ext.Create(GetType());
            cs.Open("for (var index = All.Count - 1; index >= 0; index--)");
            cs.WriteLine("var tmp = All[index].Unit;");
            cs.SingleLineIfReturn("unit.Equals(tmp.BaseUnit)", "tmp");
            cs.Close();
            cs.WithThrowNotImplementedException();

            var m = Target.AddMethod("Get" + Cfg.TargetUnitTypename, Cfg.TargetUnitTypename)
                .WithStatic()
                .WithBody(cs);
            m.AddParam("unit", Cfg.Source.Unit.GetTypename());
        }

        private RelatedUnit _relatedUnit;
    }
}