// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class TimeUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static TimeUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new TimeUnit(unitName);
        }

        /// <summary>
        /// All known time units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<TimeUnit>> All
        {
            get
            {
                return new []
                {
                    Second,
                    Minute,
                    Hour
                };
            }
        }

        private static readonly TimeUnit SecondTimeUnit = new TimeUnit("s");

        public static readonly UnitDefinition<TimeUnit> Second = new UnitDefinition<TimeUnit>(SecondTimeUnit, 1m);

        private static readonly TimeUnit MinuteTimeUnit = new TimeUnit("min");

        public static readonly UnitDefinition<TimeUnit> Minute = new UnitDefinition<TimeUnit>(MinuteTimeUnit, 60m);

        private static readonly TimeUnit HourTimeUnit = new TimeUnit("h");

        public static readonly UnitDefinition<TimeUnit> Hour = new UnitDefinition<TimeUnit>(HourTimeUnit, 3600m);

    }
}
