using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues;

public class UnitRelationsDictionary
{
    public static T2 GetT<T1, T2>(T1 a)
        where T1 : IUnit
        where T2 : IUnit
    {
            var resultUnit = GlobalUnitRegistry.Relations.Get<T1, T2>(a);
            if (resultUnit == null)
                throw new Exception($"Unable to convert {a} into {typeof(T2)}");
            return resultUnit.Item1;
        }

    public void AddRelated<T1, T2>(T1 a, T2 b)
        where T1 : IUnit
        where T2 : IUnit
    {
            var t1  = typeof(T1);
            var t2  = typeof(T2);
            var key = new Key(t1, t2, a.UnitName);
            _rd[key] = b;
        }


    public Tuple<T2> Get<T1, T2>(T1 a)
        where T1 : IUnit
        where T2 : IUnit
    {
            var t1 = typeof(T1);
            var t2 = typeof(T2);
            if (t1 == t2)
                return Tuple.Create((T2)(object)a);
            var key = new Key(t1, t2, a.UnitName);
            return _rd.TryGetValue(key, out var value) ? Tuple.Create((T2)value) : null;
        }
        
    public T2 GetOrThrow<T1, T2>(T1 a)
        where T1 : IUnit
        where T2 : IUnit
    {
            var t1 = typeof(T1);
            var t2 = typeof(T2);
            if (t1 == t2)
                return (T2)(object)a;
            var key = new Key(t1, t2, a.UnitName);
            if (_rd.TryGetValue(key, out var value))
                return (T2)value;
            throw new UnableToFindRelatedUnitException(typeof(T1), typeof(T2), a);
        }


    private readonly Dictionary<Key, object> _rd = new Dictionary<Key, object>();

    private struct Key : IEquatable<Key>
    {
        public Key(Type type1, Type type2, string name)
        {
                _type1    = type1 ?? throw new ArgumentNullException(nameof(type1));
                _type2    = type2 ?? throw new ArgumentNullException(nameof(type2));
                _name     = name ?? throw new ArgumentNullException(nameof(name));
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
                return obj is Key key && Equals(key);
            }


        public override int GetHashCode()
        {
                return _hashCode;
            }

        private readonly Type   _type1;
        private readonly Type   _type2;
        private readonly int    _hashCode;
        private readonly string _name;
    }
}