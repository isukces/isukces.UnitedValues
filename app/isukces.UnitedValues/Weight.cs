using System;
using System.Collections.Generic;

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


        public static Density operator /(Weight w, Volume v)
        {
            return new Density(w.Value / v.Value, w.Unit, v.Unit);
        }


        public Weight ConvertToKg() => ConvertTo(WeightUnitDefinition.Kg);


        public Weight RoundKg(Weight w, int decimalPlaces)
        {
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }
    }

    public partial struct WeightUnit
    {
        static WeightUnit()
        {
            KnownUnits = new Dictionary<WeightUnit, decimal>();
            AddDefinition(WeightUnitDefinition.Kg);
            AddDefinition(WeightUnitDefinition.Tone);
            AddDefinition(WeightUnitDefinition.Gram);
        }
    }

    public partial struct WeightUnitDefinition
    {
        public static readonly WeightUnitDefinition Kg = new WeightUnitDefinition("kg", 1);
        public static readonly WeightUnitDefinition Gram = new WeightUnitDefinition("g", 0.001m);
        public static readonly WeightUnitDefinition Tone = new WeightUnitDefinition("t", 1000, "ton", "tons");
    }
}