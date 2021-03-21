using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues
{
    public partial struct Weight
    {
        public static Weight FromKg(decimal kg)
        {
            return new Weight(kg, WeightUnits.Kg);
        }

        public static Weight FromKg(long kg)
        {
            return new Weight(kg, WeightUnits.Kg);
        }

        public static Weight FromKg(double kg)
        {
            return new Weight((decimal)kg, WeightUnits.Kg);
        }

        public static Weight FromTons(decimal tons)
        {
            return new Weight(tons, WeightUnits.Tone);
        }

        public static Weight FromTons(double tons)
        {
            return new Weight((decimal)tons, WeightUnits.Tone);
        }

        public static Weight FromTons(long tons)
        {
            return new Weight(tons, WeightUnits.Tone);
        }

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