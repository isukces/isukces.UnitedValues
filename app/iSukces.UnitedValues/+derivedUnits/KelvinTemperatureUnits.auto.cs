// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class KelvinTemperatureUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        /// <summary>
        /// All known kelvinTemperature units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<KelvinTemperatureUnit>> All
        {
            get
            {
                return new []
                {
                    Degree
                };
            }
        }

        public static readonly UnitDefinition<KelvinTemperatureUnit> Degree = new UnitDefinition<KelvinTemperatureUnit>("K", 1m);

    }
}
