// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class MassExtensions
    {
        public static Mass Sum(this IEnumerable<Mass> items)
        {
            if (items is null)
                return Mass.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Mass.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Mass(value, unit);
        }

        public static Mass Sum(this IEnumerable<Mass?> items)
        {
            if (items is null)
                return Mass.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Mass Sum<T>(this IEnumerable<T> items, Func<T, Mass> map)
        {
            if (items is null)
                return Mass.Zero;
            return items.Select(map).Sum();
        }

    }
}
