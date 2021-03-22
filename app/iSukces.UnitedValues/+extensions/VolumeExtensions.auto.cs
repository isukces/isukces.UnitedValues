// ReSharper disable All
// generator: UnitExtensionsGenerator
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class VolumeExtensions
    {
        public static Volume Sum(this IEnumerable<Volume> items)
        {
            if (items is null)
                return Volume.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Volume.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Volume(value, unit);
        }

        public static Volume Sum(this IEnumerable<Volume?> items)
        {
            if (items is null)
                return Volume.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Volume Sum<T>(this IEnumerable<T> items, Func<T, Volume> map)
        {
            if (items is null)
                return Volume.Zero;
            return items.Select(map).Sum();
        }

    }
}
