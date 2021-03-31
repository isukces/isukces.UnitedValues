// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class CelsiusTemperatureUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static CelsiusTemperatureUnit TryRecoverUnitFromName([NotNull] string unitName)
        {
            // generator : DerivedUnitGenerator.Add_TryRecoverUnitFromName
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            foreach (var i in All)
            {
                if (unitName == i.UnitName)
                    return i.Unit;
            }
            return new CelsiusTemperatureUnit(unitName);
        }

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

        private static readonly CelsiusTemperatureUnit DegreeCelsiusTemperatureUnit = new CelsiusTemperatureUnit("°C");

        public static readonly UnitDefinition<CelsiusTemperatureUnit> Degree = new UnitDefinition<CelsiusTemperatureUnit>(DegreeCelsiusTemperatureUnit, 1m);

    }
}
