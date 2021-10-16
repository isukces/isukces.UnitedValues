using System;
using System.Linq;

namespace UnitGenerator
{
    public class ThermalUnit
    {
        public ThermalUnit(Type type, Type inversed)
        {
            Source = new TypesGroup(new XValueTypeName(type.Name));
            Inversed = new TypesGroup(new XValueTypeName(inversed.Name));
        }


        public TypesGroup Inversed { get; }

        public TypesGroup Source { get; }

        public string TargetUnitTypename => Inversed.Unit.GetTypename();

        public string TargetContainerTypename => Inversed.Container.GetTypename();

        /*public BasicUnit InversionBaseUnit
        {
            get
            {
                var items  = BasicUnitDefs.All.Items;
                var search = Source.Value;
                return items.Single(a => a.UnitTypes.Value == search);
            }
        }*/
        /*

        public TypeAndFieldName BaseUnitValueSource
        {
            get
            {
                var related = InversionBaseUnit;

                var baseUnit = new TypeAndFieldName(
                    TargetContainerTypename,
                    related.BaseUnitField + TargetUnitTypename);
                return baseUnit;
            }
        }*/
       
    }
}