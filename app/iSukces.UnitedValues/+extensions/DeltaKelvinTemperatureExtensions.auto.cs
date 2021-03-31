// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class DeltaKelvinTemperatureExtensions
    {
        public static DeltaKelvinTemperature Sum(this IEnumerable<DeltaKelvinTemperature> items)
        {
            if (items is null)
                return DeltaKelvinTemperature.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return DeltaKelvinTemperature.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new DeltaKelvinTemperature(value, unit);
        }

        public static DeltaKelvinTemperature Sum(this IEnumerable<DeltaKelvinTemperature?> items)
        {
            if (items is null)
                return DeltaKelvinTemperature.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static DeltaKelvinTemperature Sum<T>(this IEnumerable<T> items, Func<T, DeltaKelvinTemperature> map)
        {
            if (items is null)
                return DeltaKelvinTemperature.Zero;
            return items.Select(map).Sum();
        }

    }
}
