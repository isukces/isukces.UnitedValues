// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class AreaExtensions
    {
        public static Area Sum(this IEnumerable<Area> items)
        {
            if (items is null)
                return Area.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Area.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Area(value, unit);
        }

        public static Area Sum(this IEnumerable<Area?> items)
        {
            if (items is null)
                return Area.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Area Sum<T>(this IEnumerable<T> items, Func<T, Area> map)
        {
            if (items is null)
                return Area.Zero;
            return items.Select(map).Sum();
        }

    }
}
