// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class ForceExtensions
    {
        public static Force Sum(this IEnumerable<Force> items)
        {
            if (items is null)
                return Force.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Force.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Force(value, unit);
        }

        public static Force Sum(this IEnumerable<Force?> items)
        {
            if (items is null)
                return Force.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Force Sum<T>(this IEnumerable<T> items, Func<T, Force> map)
        {
            if (items is null)
                return Force.Zero;
            return items.Select(map).Sum();
        }

    }
}
