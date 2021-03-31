// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
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

        public static KelvinTemperatureUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new KelvinTemperatureUnit(unitName);
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

        private static readonly KelvinTemperatureUnit DegreeKelvinTemperatureUnit = new KelvinTemperatureUnit("K");

        public static readonly UnitDefinition<KelvinTemperatureUnit> Degree = new UnitDefinition<KelvinTemperatureUnit>(DegreeKelvinTemperatureUnit, 1m);

    }
}
