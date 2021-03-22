namespace iSukces.UnitedValues
{
    public partial struct Length
    {
        public static Length FromKm(decimal m)
        {
            return new Length(m, LengthUnits.Km);
        }

        public static Length FromKm(long m)
        {
            return new Length(m, LengthUnits.Km);
        }

        public static Length FromKm(double m)
        {
            return new Length((decimal)m, LengthUnits.Km);
        }


        public static Length FromMeter(decimal m)
        {
            return new Length(m, LengthUnits.Meter);
        }

        public static Length FromMeter(long m)
        {
            return new Length(m, LengthUnits.Meter);
        }

        public static Length FromMeter(double m)
        {
            return new Length((decimal)m, LengthUnits.Meter);
        }

        public static Length FromMm(decimal m)
        {
            return new Length(m, LengthUnits.Mm);
        }

        public static Length FromMm(long m)
        {
            return new Length(m, LengthUnits.Mm);
        }

        public static Length FromMm(double m)
        {
            return new Length((decimal)m, LengthUnits.Mm);
        }


        public Length ConvertToMeter()
        {
            return ConvertTo(LengthUnits.Meter);
        }
    }
}