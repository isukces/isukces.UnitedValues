using System;

namespace iSukces.UnitedValues
{
    public partial struct Weight
    {
 

        /// <summary>
        ///     Div
        /// </summary>
        /// <returns></returns>
        public static LinearDensity operator /(Weight weight, Length length)
        {
            return new LinearDensity(weight.Value / length.Value, weight.Unit, length.Unit);
        }

        /// <summary>
        ///     Div
        /// </summary>
        /// <returns></returns>
        public static PlanarDensity operator /(Weight weight, Area area)
        {
            return new PlanarDensity(weight.Value / area.Value, weight.Unit, area.Unit);
        }

        /// <summary>
        ///     Div
        /// </summary>
        /// <returns></returns>
        public static Density operator /(Weight weight, Volume volume)
        {
            return new Density(weight.Value / volume.Value, weight.Unit, volume.Unit);
        }


        public Weight ConvertToKg()
        {
            return ConvertTo(WeightUnits.Kg);
        }


        public Weight RoundKg(int decimalPlaces)
        {
            var w = ConvertToKg();
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }
    }
}