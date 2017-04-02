using System;
using System.Globalization;

namespace isukces.UnitedValues
{
    public partial struct Weight
    {
        public static Weight FromKg(decimal kg) => new Weight(kg, WeightUnitDefinition.Kg);
        public static Weight FromKg(long kg) => new Weight(kg, WeightUnitDefinition.Kg);
        public static Weight FromKg(double kg) => new Weight((decimal)kg, WeightUnitDefinition.Kg);

        public static Weight FromTons(decimal tons) => new Weight(tons, WeightUnitDefinition.Tone);
        public static Weight FromTons(double tons) => new Weight((decimal)tons, WeightUnitDefinition.Tone);
        public static Weight FromTons(long tons) => new Weight(tons, WeightUnitDefinition.Tone);


        public Weight ConvertToKg() => ConvertTo(WeightUnitDefinition.Kg);


        public Weight RoundKg(Weight w, int decimalPlaces)
        {
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }
         
    }
}