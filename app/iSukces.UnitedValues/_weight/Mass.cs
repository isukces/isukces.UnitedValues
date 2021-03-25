using System;

namespace iSukces.UnitedValues
{
    public partial struct Mass
    {
        /// <summary>
        ///     Div
        /// </summary>
        /// <returns></returns>
        public static LinearDensity operator /(Mass mass, Length length)
        {
            return new LinearDensity(mass.Value / length.Value, mass.Unit, length.Unit);
        }

 


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