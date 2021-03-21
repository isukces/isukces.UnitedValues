using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues._quotient
{
    public struct Quotient<TCounter, TDenominator> : IUnitedValue<QuotientUnit<TCounter, TDenominator>>
        where TCounter : IUnit
        where TDenominator : IUnit
    {
        public bool Equals(IUnitedValue<QuotientUnit<TCounter, TDenominator>> other)
        {
            if (other == null) return false;
            return Value.Equals(other.Value) && Unit.Equals(other.Unit);
        }

        public decimal GetBaseUnitValue()
        {
            throw new NotImplementedException();
        }

        public decimal Value { get; }

        public QuotientUnit<TCounter, TDenominator> Unit { get; }
    }

    public struct QuotientUnit<TCounter, TDenominator> : IUnit, IEquatable<QuotientUnit<TCounter, TDenominator>>
        where TCounter : IUnit
        where TDenominator : IUnit
    {
        public QuotientUnit(TCounter counter, TDenominator denominator) : this()
        {
            Counter = counter;
            Denominator = denominator;
        }

        public static bool operator ==(
            QuotientUnit<TCounter, TDenominator> left, QuotientUnit<TCounter, TDenominator> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            QuotientUnit<TCounter, TDenominator> left, QuotientUnit<TCounter, TDenominator> right)
        {
            return !left.Equals(right);
        }

        public bool Equals(QuotientUnit<TCounter, TDenominator> other)
        {
            return EqualityComparer<TCounter>.Default.Equals(Counter, other.Counter) &&
                   EqualityComparer<TDenominator>.Default.Equals(Denominator, other.Denominator);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is QuotientUnit<TCounter, TDenominator> && Equals((QuotientUnit<TCounter, TDenominator>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<TCounter>.Default.GetHashCode(Counter) * 397) ^
                       EqualityComparer<TDenominator>.Default.GetHashCode(Denominator);
            }
        }

        public string UnitName => $"{Counter.UnitName}/{Denominator.UnitName}";
        public TCounter Counter { get; }
        public TDenominator Denominator { get; }
    }
}