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
                    MiliSecond,
                    Second,
                    Minute,
                    Hour
                };
            }
        }

        internal static readonly TimeUnit MiliSecondTimeUnit = new TimeUnit("ms");

        public static readonly UnitDefinition<TimeUnit> MiliSecond = new UnitDefinition<TimeUnit>(MiliSecondTimeUnit, 0.001m);

        internal static readonly TimeUnit SecondTimeUnit = new TimeUnit("s");

        public static readonly UnitDefinition<TimeUnit> Second = new UnitDefinition<TimeUnit>(SecondTimeUnit, 1m);

        internal static readonly TimeUnit MinuteTimeUnit = new TimeUnit("min");

        public static readonly UnitDefinition<TimeUnit> Minute = new UnitDefinition<TimeUnit>(MinuteTimeUnit, 60m);

        internal static readonly TimeUnit HourTimeUnit = new TimeUnit("h");

        public static readonly UnitDefinition<TimeUnit> Hour = new UnitDefinition<TimeUnit>(HourTimeUnit, 3600m);

    }
}
