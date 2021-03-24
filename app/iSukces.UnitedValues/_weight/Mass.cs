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

        /// <summary>
        ///     Div
        /// </summary>
        /// <returns></returns>
        public static PlanarDensity operator /(Mass mass, Area area)
        {
            return new PlanarDensity(mass.Value / area.Value, mass.Unit, area.Unit);
        }

        /// <summary>
        ///     Div
        /// </summary>
        /// <returns></returns>
        public static Density operator /(Mass mass, Volume volume)
        {
            return new Density(mass.Value / volume.Value, mass.Unit, volume.Unit);
        }


        public Mass ConvertToKg()
        {
            return ConvertTo(WeightUnits.Kg);
        }


        public Mass RoundKg(int decimalPlaces)
        {
            var w = ConvertToKg();
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }
    }
}