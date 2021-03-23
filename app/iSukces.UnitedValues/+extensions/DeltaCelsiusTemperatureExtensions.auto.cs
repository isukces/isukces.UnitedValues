// ReSharper disable All
// generator: UnitExtensionsGenerator
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class DeltaCelsiusTemperatureExtensions
    {
        public static DeltaCelsiusTemperature Sum(this IEnumerable<DeltaCelsiusTemperature> items)
        {
            if (items is null)
                return DeltaCelsiusTemperature.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return DeltaCelsiusTemperature.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new DeltaCelsiusTemperature(value, unit);
        }

        public static DeltaCelsiusTemperature Sum(this IEnumerable<DeltaCelsiusTemperature?> items)
        {
            if (items is null)
                return DeltaCelsiusTemperature.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static DeltaCelsiusTemperature Sum<T>(this IEnumerable<T> items, Func<T, DeltaCelsiusTemperature> map)
        {
            if (items is null)
                return DeltaCelsiusTemperature.Zero;
            return items.Select(map).Sum();
        }

    }
}
