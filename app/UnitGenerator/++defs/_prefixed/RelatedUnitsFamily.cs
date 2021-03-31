using System.Collections.Generic;

namespace UnitGenerator
{
    public class RelatedUnitsFamily
    {
        public RelatedUnitsFamily(RelatedUnit myInfo, Dictionary<int, RelatedUnit> other)
        {
            MyInfo = myInfo;
            Other  = other;
        }

        public RelatedUnit                  MyInfo { get; }
        public Dictionary<int, RelatedUnit> Other  { get; }
            
        public bool IsPower2OrHigher => !(MyInfo is null || MyInfo.Power < 2);
        
        
    }
}