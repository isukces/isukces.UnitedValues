// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public static partial class CelsiusTemperatureUnits
    {
        /// <summary>
        /// All known celsiusTemperature units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<CelsiusTemperatureUnit>> All
        {
            get
            {
                return new []
                {
                    Degree
                };
            }
        }

        public static readonly UnitDefinition<CelsiusTemperatureUnit> Degree = new UnitDefinition<CelsiusTemperatureUnit>("°C", 1m);

    }
}
