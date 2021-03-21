// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class LengthExtensions
    {
        public static Length Sum(this IEnumerable<Length> items)
        {
            if (items is null)
                return Length.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Length.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Length(value, unit);
        }

        public static Length Sum(this IEnumerable<Length?> items)
        {
            if (items is null)
                return Length.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Length Sum<T>(this IEnumerable<T> items, Func<T, Length> map)
        {
            if (items is null)
                return Length.Zero;
            return items.Select(map).Sum();
        }

    }
}
