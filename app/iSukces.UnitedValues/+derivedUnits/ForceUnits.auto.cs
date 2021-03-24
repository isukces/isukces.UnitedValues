// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class ForceUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        /// <summary>
        /// All known force units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<ForceUnit>> All
        {
            get
            {
                return new []
                {
                    Newton,
                    KiloNewton,
                    MegaNewton,
                    MiliNewton
                };
            }
        }

        public static readonly UnitDefinition<ForceUnit> Newton = new UnitDefinition<ForceUnit>("N", 1m);

        public static readonly UnitDefinition<ForceUnit> KiloNewton = new UnitDefinition<ForceUnit>("kN", 1000m);

        public static readonly UnitDefinition<ForceUnit> MegaNewton = new UnitDefinition<ForceUnit>("MN", 1000000m);

        public static readonly UnitDefinition<ForceUnit> MiliNewton = new UnitDefinition<ForceUnit>("mN", 0.001m);

    }
}
