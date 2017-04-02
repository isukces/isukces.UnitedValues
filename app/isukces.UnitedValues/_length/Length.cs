using System;

namespace isukces.UnitedValues
{
    public partial struct Length
    {
        public static Length FromKm(decimal m) => new Length(m, LengthUnitDefinition.Km);
        public static Length FromKm(long m) => new Length(m, LengthUnitDefinition.Km);
        public static Length FromKm(double m) => new Length((decimal)m, LengthUnitDefinition.Km);


        public static Length FromMeter(decimal m) => new Length(m, LengthUnitDefinition.Meter);
        public static Length FromMeter(long m) => new Length(m, LengthUnitDefinition.Meter);
        public static Length FromMeter(double m) => new Length((decimal)m, LengthUnitDefinition.Meter);


        public Length ConvertToMeter()
        {
            return ConvertTo(LengthUnitDefinition.Meter);
        }


        public Length RoundKg(Length w, int decimalPlaces)
        {
            return FromMeter(Math.Round(w.Value, decimalPlaces));
        }
    }
}