// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class MassUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static MassUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new MassUnit(unitName);
        }

        /// <summary>
        /// All known mass units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<MassUnit>> All
        {
            get
            {
                return new []
                {
                    Kg,
                    Tone,
                    Gram
                };
            }
        }

        internal static readonly MassUnit KgMassUnit = new MassUnit("kg");

        public static readonly UnitDefinition<MassUnit> Kg = new UnitDefinition<MassUnit>(KgMassUnit, 1m);

        internal static readonly MassUnit ToneMassUnit = new MassUnit("t");

        public static readonly UnitDefinition<MassUnit> Tone = new UnitDefinition<MassUnit>(ToneMassUnit, 1000m, "tone", "tons");

        internal static readonly MassUnit GramMassUnit = new MassUnit("g");

        public static readonly UnitDefinition<MassUnit> Gram = new UnitDefinition<MassUnit>(GramMassUnit, 0.001m, "gram", "grams");

    }
}
