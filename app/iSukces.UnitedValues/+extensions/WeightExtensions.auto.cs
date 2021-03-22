// ReSharper disable All
// generator: UnitExtensionsGenerator
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace iSukces.UnitedValues
{
    public static partial class WeightExtensions
    {
        public static Weight Sum(this IEnumerable<Weight> items)
        {
            if (items is null)
                return Weight.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Weight.Zero;
            if (c.Length == 1)
                return c[0];
            var unit  = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Weight(value, unit);
        }

        public static Weight Sum(this IEnumerable<Weight?> items)
        {
            if (items is null)
                return Weight.Zero;
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        public static Weight Sum<T>(this IEnumerable<T> items, Func<T, Weight> map)
        {
            if (items is null)
                return Weight.Zero;
            return items.Select(map).Sum();
        }

    }
}
