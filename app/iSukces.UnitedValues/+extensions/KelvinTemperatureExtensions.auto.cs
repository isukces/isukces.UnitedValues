// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class KelvinTemperatureExtensions
    {
        public static KelvinTemperature Sum(this IEnumerable<KelvinTemperature> items)
        {
            if (items is null)
                return KelvinTemperature.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return KelvinTemperature.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new KelvinTemperature(value, unit);
        }

        public static KelvinTemperature Sum(this IEnumerable<KelvinTemperature?> items)
        {
            if (items is null)
                return KelvinTemperature.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static KelvinTemperature Sum<T>(this IEnumerable<T> items, Func<T, KelvinTemperature> map)
        {
            if (items is null)
                return KelvinTemperature.Zero;
            return items.Select(map).Sum();
        }

    }
}
