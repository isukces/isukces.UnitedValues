using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;

namespace iSukces.UnitedValues
{
    public sealed class UnitDecomposer
    {
        private void Add(DecomposableUnitItem item, int power)
        {
            Add(item.Unit, item.Power * power);
        }

        public void Add(IUnit unit, int power)
        {
            if (unit is IDerivedDecomposableUnit d)
            {
                var gg = d.GetBasicUnit();
                Add(gg, power);
                return;
            }

            if (unit is IDecomposableUnit x)
            {
                var dec = x.Decompose();
                for (var index = 0; index < dec.Count; index++) 
                    Add(dec[index], power);
                return;
            }

            var key = new Key(unit.GetType(), unit.UnitName);
            for (var index = 0; index < _sink.Count; index++)
            {
                var item = _sink[index];
                if (item.Key != key) continue;
                item.Power += power;
                return;
            }

            _sink.Add(new SinkElement(key, power, unit));
        }


        public IReadOnlyList<DecomposableUnitItem> Items
        {
            get
            {
                var list = new List<DecomposableUnitItem>();
                for (var index = 0; index < _sink.Count; index++)
                {
                    var aaa = _sink[index];
                    if (aaa.Power == 0)
                        continue;
                    list.Add(new DecomposableUnitItem(aaa.Unit, aaa.Power));
                }

                return list;
            }
        }

        private readonly List<SinkElement> _sink = new List<SinkElement>();

        private class SinkElement
        {
            public SinkElement(Key key, int power, IUnit unit)
            {
                Key   = key;
                Power = power;
                Unit  = unit;
            }

            public Key   Key   { get; }
            public int   Power { get; set; }
            public IUnit Unit  { get; }
        }

        [ImmutableObject(true)]
        public class Key : IEquatable<Key>
        {
            public Key([NotNull] Type unitHoldeType, [NotNull] string unitName)
            {
                UnitHoldeType = unitHoldeType ?? throw new ArgumentNullException(nameof(unitHoldeType));
                UnitName      = unitName ?? throw new ArgumentNullException(nameof(unitName));
            }

            public static bool operator ==(Key left, Key right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Key left, Key right)
            {
                return !Equals(left, right);
            }

            public bool Equals(Key other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return UnitHoldeType == other.UnitHoldeType && UnitName == other.UnitName;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Key)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (UnitHoldeType.GetHashCode() * 397) ^ UnitName.GetHashCode();
                }
            }

            public override string ToString()
            {
                return $"UnitHoldeType={UnitHoldeType}, UnitName={UnitName}";
            }

            [NotNull]
            public Type UnitHoldeType { get; }

            [NotNull]
            public string UnitName { get; }
        }
    }
}