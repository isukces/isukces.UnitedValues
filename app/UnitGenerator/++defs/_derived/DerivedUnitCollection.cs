using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public class DerivedUnitCollection
    {
        public DerivedUnitCollection(IReadOnlyList<DerivedUnit> items)
        {
            Items       = items;
            _dictionary = items.ToDictionary(a => a.Name, a => a);
        }


        public DerivedUnit ByName(string name)
        {
            if (_dictionary.TryGetValue(name, out var x))
                return x;
            return null;
        }

        public Result GetPowers(string unitName)
        {
            var myInfo = FindByUnitName(unitName);
            var other  = new Dictionary<int, DerivedUnit>();

            var powerOneUnit = myInfo.Power == 1
                ? new TypesGroup(myInfo.Name)
                : myInfo.PowerOne;
            if (powerOneUnit is null)
                throw new NotImplementedException();

            var powerOneUnitUnitName = powerOneUnit.Unit;
            foreach (var i in Items)
            {
                if (i.Name == myInfo.Name)
                    continue;
                if (i.Power == 1)
                {
                    var coo = new TypesGroup(i.Name).Unit;
                    if (coo != powerOneUnitUnitName)
                        continue;
                }
                else
                {
                    if (powerOneUnitUnitName != i.PowerOne?.Unit)
                        continue;
                }

                other[i.Power] = i;
            }

            return new Result(myInfo, other);
        }

        private DerivedUnit FindByUnitName(string unitName)
        {
            DerivedUnit myInfo = null;

            foreach (var i in Items)
            {
                var t = new TypesGroup(i.Name);
                if (t.Unit != unitName) continue;
                myInfo = i;
                break;
            }

            if (myInfo is null)
                throw new NotImplementedException();
            return myInfo;
        }

        public IReadOnlyList<DerivedUnit> Items { get; }
        private readonly Dictionary<string, DerivedUnit> _dictionary;


        public class Result
        {
            public Result(DerivedUnit myInfo, Dictionary<int, DerivedUnit> other)
            {
                MyInfo = myInfo;
                Other  = other;
            }

            public DerivedUnit                  MyInfo { get; }
            public Dictionary<int, DerivedUnit> Other  { get; }
        }
    }
}