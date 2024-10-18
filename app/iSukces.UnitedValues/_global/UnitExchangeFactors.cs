using System;
using System.Collections.Generic;
using System.Linq;

namespace iSukces.UnitedValues
{
    public class UnitExchangeFactors
    {
        public decimal? Get<TUnit>(string unitName)
            where TUnit : IUnit
        {
            var key = new Key(typeof(TUnit), unitName);
            return _dict.TryGetValue(key, out var value) ? value : (decimal?)null;
        }

        public decimal? Get<TUnit>(TUnit unit)
            where TUnit : IUnit
        {
            var key = new Key(typeof(TUnit), unit.UnitName);
            return _dict.TryGetValue(key, out var value) ? value : (decimal?)null;
        }
        
        public decimal GetThrow<TUnit>(TUnit unit)
            where TUnit : IUnit
        {
            var key = new Key(typeof(TUnit), unit.UnitName);
            if (_dict.TryGetValue(key, out var value))
                return value;
            throw new UnknownDerivedUnitFactorException(typeof(TUnit), unit);
        }

        public void Register<TUnit>(UnitDefinition<TUnit> item)
            where TUnit : IUnit
        {
            var key = new Key(typeof(TUnit), item.UnitName);
            _dict[key] = item.Multiplication;
            if (item.Aliases == null || !item.Aliases.Any()) return;
            foreach (var alias in item.Aliases)
            {
                key        = new Key(typeof(TUnit), alias);
                _dict[key] = item.Multiplication;
            }
        }

        public void Register<TUnit>(string unitName, decimal multiplication)
            where TUnit : IUnit
        {
            var key = new Key(typeof(TUnit), unitName);
            _dict[key] = multiplication;
        }

        public void RegisterMany<TUnit>(IEnumerable<UnitDefinition<TUnit>> unitDefinitions) where TUnit : IUnit
        {
            foreach (var ud in unitDefinitions)
                Register(ud);
        }


        private readonly Dictionary<Key, decimal> _dict = new Dictionary<Key, decimal>();

        private struct Key : IEquatable<Key>
        {
            public Key(Type type, string name)
            {
                _type = type;
                _name = name;
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
                return _type == other._type && string.Equals(_name, other._name);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is Key && Equals((Key)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((_type != null ? _type.GetHashCode() : 0) * 397) ^ (_name?.GetHashCode() ?? 0);
                }
            }

            public override string ToString()
            {
                return $"'{_name}' {_type}";
            }

            private readonly Type _type;
            private readonly string _name;
        }
    }
}