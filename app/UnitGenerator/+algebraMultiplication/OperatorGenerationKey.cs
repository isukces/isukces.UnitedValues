using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class OperatorGenerationKey : IEquatable<OperatorGenerationKey>
    {
        public OperatorGenerationKey(string left, string right, string oper)
        {
            left  = left.TrimToNull();
            right = right.TrimToNull();
            oper  = oper.TrimToNull();

            Left  = left;
            Right = right;
            Oper  = oper;
        }

        public static bool operator ==(OperatorGenerationKey left, OperatorGenerationKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OperatorGenerationKey left, OperatorGenerationKey right)
        {
            return !Equals(left, right);
        }

        public bool Equals(OperatorGenerationKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Left == other.Left && Right == other.Right && Oper == other.Oper;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OperatorGenerationKey)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Left != null ? Left.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Right != null ? Right.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Oper != null ? Oper.GetHashCode() : 0);
                return hashCode;
            }
        }

        public string GetOperatorTargetType()
        {
            int G()
            {
                var c = Left.Length.CompareTo(Right.Length);
                if (c != 0)
                    return c;
                return StringComparer.Ordinal.Compare(Left, Right);
            }

            if (Oper == "/")
                return Left;

            return G() > 0 ? Right : Left;
        }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Left, Oper, Right);
        }

        public string Left  { get; }
        public string Right { get; }
        public string Oper  { get; }
    }
}