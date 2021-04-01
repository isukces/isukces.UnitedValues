// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class SquareTimeUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static SquareTimeUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new SquareTimeUnit(unitName);
        }

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

        internal static readonly SquareTimeUnit SquareSecondSquareTimeUnit = new SquareTimeUnit(TimeUnits.Second);

        public static readonly UnitDefinition<SquareTimeUnit> SquareSecond = new UnitDefinition<SquareTimeUnit>(SquareSecondSquareTimeUnit, 1m);

        internal static readonly SquareTimeUnit SquareMinuteSquareTimeUnit = new SquareTimeUnit(TimeUnits.Minute);

        public static readonly UnitDefinition<SquareTimeUnit> SquareMinute = new UnitDefinition<SquareTimeUnit>(SquareMinuteSquareTimeUnit, 60m * 60m);

        internal static readonly SquareTimeUnit SquareHourSquareTimeUnit = new SquareTimeUnit(TimeUnits.Hour);

        public static readonly UnitDefinition<SquareTimeUnit> SquareHour = new UnitDefinition<SquareTimeUnit>(SquareHourSquareTimeUnit, 3600m * 3600m);

    }
}
