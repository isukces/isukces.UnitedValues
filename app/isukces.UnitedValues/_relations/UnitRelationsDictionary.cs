using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public class UnitRelationsDictionary
    {
        public void AddRelated<T1, T2>(T1 a, T2 b)
            where T1 : IUnit 
            where T2 : IUnitDefinition 
        {
            var t1 = typeof(T1);
            var t2 = typeof(T2);
            rd[new Key(t1, t2, a.UnitName)] = b;
        }


        public Tuple<T2> Get<T1, T2>(T1 a)
            where T1 : IUnit 
            where T2 : IUnitDefinition
        {
            var t1 = typeof(T1);
            var t2 = typeof(T2);
            var key = new Key(t1, t2, a.UnitName);
            object value;
            return rd.TryGetValue(key, out value) ? Tuple.Create((T2)value) : null;
        }

        private readonly Dictionary<Key, object> rd = new Dictionary<Key, object>();

        private struct Key : IEquatable<Key>
        {
            public Key(Type type1, Type type2, string name)
            {
                if (type1 == null) throw new ArgumentNullException(nameof(type1));
                if (type2 == null) throw new ArgumentNullException(nameof(type2));
                if (name == null) throw new ArgumentNullException(nameof(name));
                _type1 = type1;
                _type2 = type2;
                _name = name;
                _hashCode = (type1.GetHashCode() * 397) ^ type2.GetHashCode();
                _hashCode = (_hashCode * 397) ^ _name.GetHashCode();
            }

            public static bool operator ==(Key left, Key right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Key left, Key right)
            {
                return !left.Equals(right);
            }

            public bool Equals(Key other)
            {
                return _type1 == other._type1 && _type2 == other._type2 &&
                       string.Equals(_name, other._name, StringComparison.Ordinal);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is Key && Equals((Key)obj);
            }


            public override int GetHashCode() => _hashCode;

            private readonly Type _type1;
            private readonly Type _type2;
            private readonly int _hashCode;
            private readonly string _name;
        }
    }
}