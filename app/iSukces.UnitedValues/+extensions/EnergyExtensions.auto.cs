// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class EnergyExtensions
    {
        public static Energy Sum(this IEnumerable<Energy> items)
        {
            if (items is null)
                return Energy.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Energy.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Energy(value, unit);
        }

        public static Energy Sum(this IEnumerable<Energy?> items)
        {
            if (items is null)
                return Energy.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Energy Sum<T>(this IEnumerable<T> items, Func<T, Energy> map)
        {
            if (items is null)
                return Energy.Zero;
            return items.Select(map).Sum();
        }

    }
}
