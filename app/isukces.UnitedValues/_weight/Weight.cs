using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public partial struct Weight
    {
        public static Weight FromKg(decimal kg) => new Weight(kg, WeightUnits.Kg);
        public static Weight FromKg(long kg) => new Weight(kg, WeightUnits.Kg);
        public static Weight FromKg(double kg) => new Weight((decimal)kg, WeightUnits.Kg);

        public static Weight FromTons(decimal tons) => new Weight(tons, WeightUnits.Tone);
        public static Weight FromTons(double tons) => new Weight((decimal)tons, WeightUnits.Tone);
        public static Weight FromTons(long tons) => new Weight(tons, WeightUnits.Tone);


        public static Density operator /(Weight w, Volume v)
        {
            return new Density(w.Value / v.Value, w.Unit, v.Unit);
        }


        public Weight ConvertToKg() => ConvertTo(WeightUnits.Kg);


        public Weight RoundKg(Weight w, int decimalPlaces)
        {
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }
    }


    public static class WeightUnits
    {
        public static IEnumerable<UnitDefinition<WeightUnit>> All
        {
            get
            {
                yield return Kg;
                yield return Gram;
                yield return Tone;
            }
        }

        public static readonly UnitDefinition<WeightUnit> Kg = new UnitDefinition<WeightUnit>("kg", 1);
        public static readonly UnitDefinition<WeightUnit> Gram = new UnitDefinition<WeightUnit>("g", 0.001m);
        public static readonly UnitDefinition<WeightUnit> Tone = new UnitDefinition<WeightUnit>("t", 1000, "ton", "tons");
    }
}