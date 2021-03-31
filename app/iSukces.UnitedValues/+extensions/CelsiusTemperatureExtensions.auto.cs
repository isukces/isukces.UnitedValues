// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class CelsiusTemperatureExtensions
    {
        public static CelsiusTemperature Sum(this IEnumerable<CelsiusTemperature> items)
        {
            if (items is null)
                return CelsiusTemperature.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return CelsiusTemperature.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new CelsiusTemperature(value, unit);
        }

        public static CelsiusTemperature Sum(this IEnumerable<CelsiusTemperature?> items)
        {
            if (items is null)
                return CelsiusTemperature.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static CelsiusTemperature Sum<T>(this IEnumerable<T> items, Func<T, CelsiusTemperature> map)
        {
            if (items is null)
                return CelsiusTemperature.Zero;
            return items.Select(map).Sum();
        }

    }
}
