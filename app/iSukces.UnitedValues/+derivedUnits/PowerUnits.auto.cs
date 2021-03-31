// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class PowerUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static PowerUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new PowerUnit(unitName);
        }

        /// <summary>
        /// All known power units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<PowerUnit>> All
        {
            get
            {
                return new []
                {
                    Watt,
                    KiloWatt,
                    MegaWatt,
                    GigaWatt,
                    MiliWatt
                };
            }
        }

        private static readonly PowerUnit WattPowerUnit = new PowerUnit("W");

        public static readonly UnitDefinition<PowerUnit> Watt = new UnitDefinition<PowerUnit>(WattPowerUnit, 1m);

        private static readonly PowerUnit KiloWattPowerUnit = new PowerUnit("kW");

        public static readonly UnitDefinition<PowerUnit> KiloWatt = new UnitDefinition<PowerUnit>(KiloWattPowerUnit, 1000m);

        private static readonly PowerUnit MegaWattPowerUnit = new PowerUnit("MW");

        public static readonly UnitDefinition<PowerUnit> MegaWatt = new UnitDefinition<PowerUnit>(MegaWattPowerUnit, 1000000m);

        private static readonly PowerUnit GigaWattPowerUnit = new PowerUnit("GW");

        public static readonly UnitDefinition<PowerUnit> GigaWatt = new UnitDefinition<PowerUnit>(GigaWattPowerUnit, 1000000000m);

        private static readonly PowerUnit MiliWattPowerUnit = new PowerUnit("mW");

        public static readonly UnitDefinition<PowerUnit> MiliWatt = new UnitDefinition<PowerUnit>(MiliWattPowerUnit, 0.001m);

    }
}
