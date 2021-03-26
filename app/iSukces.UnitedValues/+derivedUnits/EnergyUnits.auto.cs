// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class EnergyUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        /// <summary>
        /// All known energy units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<EnergyUnit>> All
        {
            get
            {
                return new []
                {
                    Joule,
                    KiloJoule,
                    MegaJoule,
                    GigaJoule,
                    WattHour,
                    KiloWattHour,
                    MegaWattHour,
                    GigaWattHour,
                    Calorie,
                    KiloCalorie
                };
            }
        }

        public static readonly UnitDefinition<EnergyUnit> Joule = new UnitDefinition<EnergyUnit>("J", 1m);

        public static readonly UnitDefinition<EnergyUnit> KiloJoule = new UnitDefinition<EnergyUnit>("kJ", 1000m);

        public static readonly UnitDefinition<EnergyUnit> MegaJoule = new UnitDefinition<EnergyUnit>("MJ", 1000000m);

        public static readonly UnitDefinition<EnergyUnit> GigaJoule = new UnitDefinition<EnergyUnit>("GJ", 1000000000m);

        public static readonly UnitDefinition<EnergyUnit> WattHour = new UnitDefinition<EnergyUnit>("Wh", 3600m);

        public static readonly UnitDefinition<EnergyUnit> KiloWattHour = new UnitDefinition<EnergyUnit>("kWh", 3600000m);

        public static readonly UnitDefinition<EnergyUnit> MegaWattHour = new UnitDefinition<EnergyUnit>("MWh", 3600000000m);

        public static readonly UnitDefinition<EnergyUnit> GigaWattHour = new UnitDefinition<EnergyUnit>("GWh", 3600000000000m);

        public static readonly UnitDefinition<EnergyUnit> Calorie = new UnitDefinition<EnergyUnit>("cal", 4.1855m);

        public static readonly UnitDefinition<EnergyUnit> KiloCalorie = new UnitDefinition<EnergyUnit>("kcal", 4185.5m);

    }
}
