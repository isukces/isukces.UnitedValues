// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class MassUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        /// <summary>
        /// All known mass units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<MassUnit>> All
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

        public static readonly UnitDefinition<MassUnit> Kg = new UnitDefinition<MassUnit>("kg", 1m);

        public static readonly UnitDefinition<MassUnit> Tone = new UnitDefinition<MassUnit>("t", 1000m, "tone", "tons");

        public static readonly UnitDefinition<MassUnit> Gram = new UnitDefinition<MassUnit>("g", 0.001m, "gram", "grams");

    }
}
