// ReSharper disable All
// generator: InversedUnitContainerGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public static partial class InversedKelvinTemperatureUnits
    {
        static InversedKelvinTemperatureUnits()
        {
            // generator : InversedUnitContainerGenerator.Add_StaticConstructor
            All = new []
            {
                Degree
            };
        }

        public static InversedKelvinTemperatureUnit GetInversedKelvinTemperatureUnit(KelvinTemperatureUnit unit)
        {
            // generator : InversedUnitContainerGenerator.Add_GetInversedUnit
            for (var index = All.Count - 1; index >= 0; index--)
            {
                var tmp = All[index].Unit;
                if (unit.Equals(tmp.BaseUnit))
                    return tmp;
            }
            throw new NotImplementedException("Not implemented yet");
        }

        /// <summary>
        /// unit 1/K
        /// </summary>
        internal static readonly InversedKelvinTemperatureUnit DegreeInversedKelvinTemperatureUnit = new InversedKelvinTemperatureUnit(KelvinTemperatureUnits.DegreeKelvinTemperatureUnit);

        /// <summary>
        /// unit 1/K with factor
        /// </summary>
        public static readonly UnitDefinition<InversedKelvinTemperatureUnit> Degree = new UnitDefinition<InversedKelvinTemperatureUnit>(DegreeInversedKelvinTemperatureUnit, 1m);

        /// <summary>
        /// All known inversedKelvinTemperatureUnit units
        /// </summary>
        public static readonly IReadOnlyList<UnitDefinition<InversedKelvinTemperatureUnit>> All;

    }
}
