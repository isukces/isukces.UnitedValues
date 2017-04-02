using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isukces.UnitedValues
{
    public static class UnitedValuesUtils
    {
        public static int Compare<T, TUnit>(T a, T b)
            where T : struct, IUnitedValue<TUnit>
            where TUnit : IEquatable<TUnit>, IUnit
        {
            if (a.Equals(b)) return 0;
            if (a.Unit.Equals(b.Unit))
                return a.Value.CompareTo(a.Value);

            var val1 = a.GetBaseUnitValue();
            var val2 = b.GetBaseUnitValue();
            return val1.CompareTo(val2);
        }
    }
}
