// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
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

        public static EnergyUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new EnergyUnit(unitName);
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

        internal static readonly EnergyUnit JouleEnergyUnit = new EnergyUnit("J");

        public static readonly UnitDefinition<EnergyUnit> Joule = new UnitDefinition<EnergyUnit>(JouleEnergyUnit, 1m);

        internal static readonly EnergyUnit KiloJouleEnergyUnit = new EnergyUnit("kJ");

        public static readonly UnitDefinition<EnergyUnit> KiloJoule = new UnitDefinition<EnergyUnit>(KiloJouleEnergyUnit, 1000m);

        internal static readonly EnergyUnit MegaJouleEnergyUnit = new EnergyUnit("MJ");

        public static readonly UnitDefinition<EnergyUnit> MegaJoule = new UnitDefinition<EnergyUnit>(MegaJouleEnergyUnit, 1000000m);

        internal static readonly EnergyUnit GigaJouleEnergyUnit = new EnergyUnit("GJ");

        public static readonly UnitDefinition<EnergyUnit> GigaJoule = new UnitDefinition<EnergyUnit>(GigaJouleEnergyUnit, 1000000000m);

        internal static readonly EnergyUnit WattHourEnergyUnit = new EnergyUnit("Wh");

        public static readonly UnitDefinition<EnergyUnit> WattHour = new UnitDefinition<EnergyUnit>(WattHourEnergyUnit, 3600m);

        internal static readonly EnergyUnit KiloWattHourEnergyUnit = new EnergyUnit("kWh");

        public static readonly UnitDefinition<EnergyUnit> KiloWattHour = new UnitDefinition<EnergyUnit>(KiloWattHourEnergyUnit, 3600000m);

        internal static readonly EnergyUnit MegaWattHourEnergyUnit = new EnergyUnit("MWh");

        public static readonly UnitDefinition<EnergyUnit> MegaWattHour = new UnitDefinition<EnergyUnit>(MegaWattHourEnergyUnit, 3600000000m);

        internal static readonly EnergyUnit GigaWattHourEnergyUnit = new EnergyUnit("GWh");

        public static readonly UnitDefinition<EnergyUnit> GigaWattHour = new UnitDefinition<EnergyUnit>(GigaWattHourEnergyUnit, 3600000000000m);

        internal static readonly EnergyUnit CalorieEnergyUnit = new EnergyUnit("cal");

        public static readonly UnitDefinition<EnergyUnit> Calorie = new UnitDefinition<EnergyUnit>(CalorieEnergyUnit, 4.1855m);

        internal static readonly EnergyUnit KiloCalorieEnergyUnit = new EnergyUnit("kcal");

        public static readonly UnitDefinition<EnergyUnit> KiloCalorie = new UnitDefinition<EnergyUnit>(KiloCalorieEnergyUnit, 4185.5m);

    }
}
