// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class PowerExtensions
    {
        public static Power Sum(this IEnumerable<Power> items)
        {
            if (items is null)
                return Power.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Power.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Power(value, unit);
        }

        public static Power Sum(this IEnumerable<Power?> items)
        {
            if (items is null)
                return Power.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Power Sum<T>(this IEnumerable<T> items, Func<T, Power> map)
        {
            if (items is null)
                return Power.Zero;
            return items.Select(map).Sum();
        }

    }
}
