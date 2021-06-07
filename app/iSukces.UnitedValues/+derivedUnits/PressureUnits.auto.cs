// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class PressureUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static PressureUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new PressureUnit(unitName);
        }

        /// <summary>
        /// All known pressure units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<PressureUnit>> All
        {
            get
            {
                return new []
                {
                    Pascal,
                    HectoPascal,
                    KiloPascal,
                    MegaPascal
                };
            }
        }

        internal static readonly PressureUnit PascalPressureUnit = new PressureUnit("Pa");

        public static readonly UnitDefinition<PressureUnit> Pascal = new UnitDefinition<PressureUnit>(PascalPressureUnit, 1m);

        internal static readonly PressureUnit HectoPascalPressureUnit = new PressureUnit("hPa");

        public static readonly UnitDefinition<PressureUnit> HectoPascal = new UnitDefinition<PressureUnit>(HectoPascalPressureUnit, 100m);

        internal static readonly PressureUnit KiloPascalPressureUnit = new PressureUnit("kPa");

        public static readonly UnitDefinition<PressureUnit> KiloPascal = new UnitDefinition<PressureUnit>(KiloPascalPressureUnit, 1000m);

        internal static readonly PressureUnit MegaPascalPressureUnit = new PressureUnit("MPa");

        public static readonly UnitDefinition<PressureUnit> MegaPascal = new UnitDefinition<PressureUnit>(MegaPascalPressureUnit, 1000000m);

    }
}
