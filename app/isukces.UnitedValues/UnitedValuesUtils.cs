using System;

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

        public static TResult Divide<
            TLeft, TLeftUnit,
            TRight, TRightUnit,
            TResult, TResultUnit>(TLeft a, TRight b, Func<TRight, TRightUnit, TRight> leftConvert, Func<decimal, TResultUnit, TResult> result)
            where TLeft : IUnitedValue<TLeftUnit>
            where TRight : IUnitedValue<TRightUnit>
            where TResult : IUnitedValue<TResultUnit>
            where TLeftUnit : IUnit, IEquatable<TLeftUnit>
            where TRightUnit : IUnit, IEquatable<TRightUnit>
            where TResultUnit : IUnit, IEquatable<TResultUnit>
        {
            var rightUnit = GlobalUnitRegistry.Relations.Get<TLeftUnit, TRightUnit>(a.Unit);
            if (rightUnit == null)
                throw new Exception($"Unable to convert {a.Unit} into {typeof(TRightUnit)}");

            var resultUnit = GlobalUnitRegistry.Relations.Get<TLeftUnit, TResultUnit>(a.Unit);
            if (resultUnit == null)
                throw new Exception($"Unable to convert {a.Unit} into {typeof(TResultUnit)}");

            b = leftConvert(b, rightUnit.Item1);

            var value = b.Value / a.Value;
            return result(value, resultUnit.Item1);
        }

        public static TResult Multiply<
            TLeft, TLeftUnit,
            TRight, TRightUnit,
            TResult, TResultUnit>(
            TLeft a, 
            TRight b, 
            Func<TRight, TRightUnit, TRight> leftConvert, 
            Func<decimal, TResultUnit, TResult> result)
            where TLeft : IUnitedValue<TLeftUnit>
            where TRight : IUnitedValue<TRightUnit>
            where TResult : IUnitedValue<TResultUnit>
            where TLeftUnit : IUnit, IEquatable<TLeftUnit>
            where TRightUnit : IUnit, IEquatable<TRightUnit>
            where TResultUnit : IUnit, IEquatable<TResultUnit>
        {
            var rightUnit = GlobalUnitRegistry.Relations.Get<TLeftUnit, TRightUnit>(a.Unit);
            if (rightUnit == null)
                throw new Exception($"Unable to convert {a.Unit} into {typeof(TRightUnit)}");

            var resultUnit = GlobalUnitRegistry.Relations.Get<TLeftUnit, TResultUnit>(a.Unit);
            if (resultUnit == null)
                throw new Exception($"Unable to convert {a.Unit} into {typeof(TResultUnit)}");

            b = leftConvert(b, rightUnit.Item1);

            var value = b.Value * a.Value;
            return result(value, resultUnit.Item1);
        }
    }
}