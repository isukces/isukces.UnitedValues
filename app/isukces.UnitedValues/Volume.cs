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
            AddDefinition(VolumeUnitDefinition.QubicKm);
            AddDefinition(VolumeUnitDefinition.QubicMeter);
            AddDefinition(VolumeUnitDefinition.QubicMm);

            AddDefinition(VolumeUnitDefinition.QubicCm);
            AddDefinition(VolumeUnitDefinition.QubicFeet);
            AddDefinition(VolumeUnitDefinition.QubicInch);
        }
    }

    public partial struct VolumeUnitDefinition
    {
        public static readonly VolumeUnitDefinition QubicMeter
            = new VolumeUnitDefinition("m" + Qubic, 1, "m3");

        public static readonly VolumeUnitDefinition QubicKm
            = new VolumeUnitDefinition("km" + Qubic, 1000 * 1000 * 1000, "km3");

        public static readonly VolumeUnitDefinition QubicMm
            = new VolumeUnitDefinition("mm" + Qubic, 0.001m * 0.001m * 0.001m, "mm3");

        public static readonly VolumeUnitDefinition QubicCm
            = new VolumeUnitDefinition("cm" + Qubic, 0.01m * 0.01m * 0.01m, "cm3");

        public static readonly VolumeUnitDefinition QubicInch
            = new VolumeUnitDefinition("inch" + Qubic, 0.0254m * 0.0254m * 0.0254m, "inch3");

        public static readonly VolumeUnitDefinition QubicFeet
            = new VolumeUnitDefinition("ft" + Qubic, 0.0254m * 12 * 0.0254m * 12 * 0.0254m * 12, "ft3");

        public const string Qubic = "³";
    }
}