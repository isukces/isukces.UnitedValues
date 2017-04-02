using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public partial struct Volume
    {
        public static Volume FromKm(decimal m) => new Volume(m, VolumeUnitDefinition.QubicKm);
        public static Volume FromKm(long m) => new Volume(m, VolumeUnitDefinition.QubicKm);
        public static Volume FromKm(double m) => new Volume((decimal)m, VolumeUnitDefinition.QubicKm);


        public static Volume FromMeter(decimal m) => new Volume(m, VolumeUnitDefinition.QubicMeter);
        public static Volume FromMeter(long m) => new Volume(m, VolumeUnitDefinition.QubicMeter);
        public static Volume FromMeter(double m) => new Volume((decimal)m, VolumeUnitDefinition.QubicMeter);


        public Volume ConvertToMeter()
        {
            return ConvertTo(VolumeUnitDefinition.QubicMeter);
        }
    }

    public partial struct VolumeUnit
    {
        static VolumeUnit()
        {
            KnownUnits = new Dictionary<VolumeUnit, decimal>();
            foreach (var i in VolumeUnitDefinition.All)
                AddDefinition(i);           
        }
    }

    public partial struct VolumeUnitDefinition
    {
        public const string Qubic = "³";
    }
}