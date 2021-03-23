// ReSharper disable All
// generator: UnitExtensionsGenerator
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class SquareTimeExtensions
    {
        public static SquareTime Sum(this IEnumerable<SquareTime> items)
        {
            if (items is null)
                return SquareTime.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return SquareTime.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new SquareTime(value, unit);
        }

        public static SquareTime Sum(this IEnumerable<SquareTime?> items)
        {
            if (items is null)
                return SquareTime.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static SquareTime Sum<T>(this IEnumerable<T> items, Func<T, SquareTime> map)
        {
            if (items is null)
                return SquareTime.Zero;
            return items.Select(map).Sum();
        }

    }
}
