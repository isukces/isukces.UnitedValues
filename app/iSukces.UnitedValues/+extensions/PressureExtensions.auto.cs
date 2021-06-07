// ReSharper disable All
// generator: UnitExtensionsGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class PressureExtensions
    {
        public static Pressure Sum(this IEnumerable<Pressure> items)
        {
            if (items is null)
                return Pressure.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Pressure.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Pressure(value, unit);
        }

        public static Pressure Sum(this IEnumerable<Pressure?> items)
        {
            if (items is null)
                return Pressure.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Pressure Sum<T>(this IEnumerable<T> items, Func<T, Pressure> map)
        {
            if (items is null)
                return Pressure.Zero;
            return items.Select(map).Sum();
        }

    }
}
