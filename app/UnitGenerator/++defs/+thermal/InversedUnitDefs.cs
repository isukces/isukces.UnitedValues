using System.Collections.Generic;
using iSukces.UnitedValues;


namespace UnitGenerator
{
    public class ThermaUnitDefs
    {
        public static ThermaUnitsCollection All
        {
            get
            {
                if (_all is null)

                    _all = new ThermaUnitsCollection(new[]
                    {
                        new ThermalUnit(typeof(ThermalResistance),typeof(ThermalConductivity)),
                        new ThermalUnit(typeof(ThermalConductivity),typeof(ThermalResistance)),
                    });
                return _all;
            }
        }

        private static ThermaUnitsCollection _all;
    }
}