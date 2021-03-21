namespace iSukces.UnitedValues
{
    public partial struct Volume
    {
        public static Volume FromKm(decimal m)
        {
            return new Volume(m, VolumeUnits.QubicKm);
        }

        public static Volume FromKm(long m)
        {
            return new Volume(m, VolumeUnits.QubicKm);
        }

        public static Volume FromKm(double m)
        {
            return new Volume((decimal)m, VolumeUnits.QubicKm);
        }


        public static Volume FromMeter(decimal m)
        {
            return new Volume(m, VolumeUnits.QubicMeter);
        }

        public static Volume FromMeter(long m)
        {
            return new Volume(m, VolumeUnits.QubicMeter);
        }

        public static Volume FromMeter(double m)
        {
            return new Volume((decimal)m, VolumeUnits.QubicMeter);
        }


        public Volume ConvertToMeter()
        {
            return ConvertTo(VolumeUnits.QubicMeter);
        }
    }

    public partial struct VolumeUnit
    {
        public const string Qubic = "³";
    }
}