// ReSharper disable All
// generator: DerivedUnitGenerator
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

        public static readonly UnitDefinition<TimeUnit> Second = new UnitDefinition<TimeUnit>("s", 1m);

        public static readonly UnitDefinition<TimeUnit> Minute = new UnitDefinition<TimeUnit>("min", 60m);

        public static readonly UnitDefinition<TimeUnit> Hour = new UnitDefinition<TimeUnit>("h", 3600m);

    }
}
