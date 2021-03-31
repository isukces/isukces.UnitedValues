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

        public static ForceUnit TryRecoverUnitFromName([JetBrains.Annotations.NotNull] string unitName)
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
            return new ForceUnit(unitName);
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

        private static readonly ForceUnit NewtonForceUnit = new ForceUnit("N");

        public static readonly UnitDefinition<ForceUnit> Newton = new UnitDefinition<ForceUnit>(NewtonForceUnit, 1m);

        private static readonly ForceUnit KiloNewtonForceUnit = new ForceUnit("kN");

        public static readonly UnitDefinition<ForceUnit> KiloNewton = new UnitDefinition<ForceUnit>(KiloNewtonForceUnit, 1000m);

        private static readonly ForceUnit MegaNewtonForceUnit = new ForceUnit("MN");

        public static readonly UnitDefinition<ForceUnit> MegaNewton = new UnitDefinition<ForceUnit>(MegaNewtonForceUnit, 1000000m);

        private static readonly ForceUnit MiliNewtonForceUnit = new ForceUnit("mN");

        public static readonly UnitDefinition<ForceUnit> MiliNewton = new UnitDefinition<ForceUnit>(MiliNewtonForceUnit, 0.001m);

    }
}
