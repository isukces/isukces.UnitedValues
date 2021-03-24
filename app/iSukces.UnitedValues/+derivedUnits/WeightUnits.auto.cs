// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class WeightUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        /// <summary>
        /// All known weight units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<WeightUnit>> All
        {
            get
            {
                return new []
                {
                    Kg,
                    Tone,
                    Gram
                };
            }
        }

        public static readonly UnitDefinition<WeightUnit> Kg = new UnitDefinition<WeightUnit>("kg", 1m);

        public static readonly UnitDefinition<WeightUnit> Tone = new UnitDefinition<WeightUnit>("t", 1000m, "tone", "tons");

        public static readonly UnitDefinition<WeightUnit> Gram = new UnitDefinition<WeightUnit>("g", 0.001m, "gram", "grams");

    }
}
