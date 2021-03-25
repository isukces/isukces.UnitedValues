using System;

namespace iSukces.UnitedValues
{
    public partial struct Mass
    {
        public Mass ConvertToKg()
        {
            return ConvertTo(MassUnits.Kg);
        }

        public Mass RoundKg(int decimalPlaces)
        {
            var w = ConvertToKg();
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }
    }
}