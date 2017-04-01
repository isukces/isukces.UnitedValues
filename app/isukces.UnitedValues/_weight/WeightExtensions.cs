using System;
using System.Collections.Generic;
using System.Linq;

namespace isukces.UnitedValues
{
    public static class WeightExtensions
    {
        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Weight Sum(this IEnumerable<Weight> items)
        {
            if (items == null)
                return Weight.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Weight.Zero;
            var unit = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Weight(value, unit);
        }

        /// <summary>
        ///     Sumuje wagi, nulle traktuje jako 0
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Weight Sum(this IEnumerable<Weight?> items)
        {
            if (items==null)
                return Weight.Zero;            
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Weight Sum<T>(this IEnumerable<T> items, Func<T, Weight> map)
        {
            return items.Select(map).Sum();
        }
    }
}