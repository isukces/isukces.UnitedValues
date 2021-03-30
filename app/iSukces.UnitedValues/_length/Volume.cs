namespace iSukces.UnitedValues
{
    public partial struct Volume
    {
        public static Volume FromKm(decimal m)
        {
            return new Volume(m, VolumeUnits.CubicKm);
        }

        public static Volume FromKm(long m)
        {
            return new Volume(m, VolumeUnits.CubicKm);
        }

        public static Volume FromKm(double m)
        {
            return new Volume((decimal)m, VolumeUnits.CubicKm);
        }


        public static Volume FromMeter(decimal m)
        {
            return new Volume(m, VolumeUnits.CubicMeter);
        }

        public static Volume FromMeter(long m)
        {
            return new Volume(m, VolumeUnits.CubicMeter);
        }

        public static Volume FromMeter(double m)
        {
            return new Volume((decimal)m, VolumeUnits.CubicMeter);
        }


        public Volume ConvertToMeter()
        {
            return ConvertTo(VolumeUnits.CubicMeter);
        }
    }
}