// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class TimeExtensions
    {
        public static Time Sum(this IEnumerable<Time> items)
        {
            if (items is null)
                return Time.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Time.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Time(value, unit);
        }

        public static Time Sum(this IEnumerable<Time?> items)
        {
            if (items is null)
                return Time.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Time Sum<T>(this IEnumerable<T> items, Func<T, Time> map)
        {
            if (items is null)
                return Time.Zero;
            return items.Select(map).Sum();
        }

    }
}
