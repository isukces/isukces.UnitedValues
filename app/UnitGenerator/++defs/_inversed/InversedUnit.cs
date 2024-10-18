using System;
using System.Linq;
using iSukces.Code;

namespace UnitGenerator
{
    public class InversedUnit
    {
        public InversedUnit(Type type)
        {
            Source = new TypesGroup(new XValueTypeName(type.Name));
            const string inversed = "Inversed";
            var          a        = new TypesGroup(new XValueTypeName(inversed + type.Name));
            var          b        = new TypesGroup(new XValueTypeName(inversed + Source.Value.CoreName));
            Target = new TypesGroup(a.Value, b.Unit, b.Container);
        }


        public TypesGroup Target { get; }

        public TypesGroup Source { get; }

        public CsType TargetUnitTypename => (CsType)Target.Unit.GetTypename();

        public CsType TargetContainerTypename => (CsType)Target.Container.GetTypename();

        public BasicUnit InversionBaseUnit
        {
            get
            {
                var items  = BasicUnitDefs.All.Items;
                var search = Source.Value;
                return items.Single(a => a.UnitTypes.Value == search);
            }
        }

        public TypeAndFieldName BaseUnitValueSource
        {
            get
            {
                var related = InversionBaseUnit;

                var baseUnit = new TypeAndFieldName(
                    TargetContainerTypename,
                    related.BaseUnitField + TargetUnitTypename.Declaration);
                return baseUnit;
            }
        }
    }
}