// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public static partial class SquareTimeUnits
    {
        internal static void Register(UnitRelationsDictionary dict)
        {
            dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareSecond, TimeUnits.Second);
            dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Second, SquareSecond);
            dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareMinute, TimeUnits.Minute);
            dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Minute, SquareMinute);
            dict.AddRelated<SquareTimeUnit, TimeUnit>(SquareHour, TimeUnits.Hour);
            dict.AddRelated<TimeUnit, SquareTimeUnit>(TimeUnits.Hour, SquareHour);
        }

        /// <summary>
        /// All known squareTime units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<SquareTimeUnit>> All
        {
            get
            {
                return new []
                {
                    SquareSecond,
                    SquareMinute,
                    SquareHour
                };
            }
        }

        public static readonly UnitDefinition<SquareTimeUnit> SquareSecond = new UnitDefinition<SquareTimeUnit>("s²", 1m);

        public static readonly UnitDefinition<SquareTimeUnit> SquareMinute = new UnitDefinition<SquareTimeUnit>("min²", 60m * 60m);

        public static readonly UnitDefinition<SquareTimeUnit> SquareHour = new UnitDefinition<SquareTimeUnit>("h²", 3600m * 3600m);

    }
}
