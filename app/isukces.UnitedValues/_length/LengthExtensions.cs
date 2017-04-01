using System;
using System.Collections.Generic;
using System.Linq;

namespace isukces.UnitedValues
{
    public static class LengthExtensions
    {
        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Length Sum(this IEnumerable<Length> items)
        {
            if (items == null)
                return Length.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Length.Zero;
            var unit = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Length(value, unit);
        }

        /// <summary>
        ///     Sumuje wagi, nulle traktuje jako 0
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Length Sum(this IEnumerable<Length?> items)
        {
            if (items==null)
                return Length.Zero;            
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Length Sum<T>(this IEnumerable<T> items, Func<T, Length> map)
        {
            return items.Select(map).Sum();
        }
    }
}