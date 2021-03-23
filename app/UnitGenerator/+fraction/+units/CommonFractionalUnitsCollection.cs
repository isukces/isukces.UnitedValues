using System.Linq;

namespace UnitGenerator
{
    public class CommonFractionalUnitsCollection
    {
        public CommonFractionalUnits[] Items { get; }

        public CommonFractionalUnitsCollection(CommonFractionalUnits[] items)
        {
            Items = items;
        }

        public CommonFractionalUnits[] GetBy(string namesUnit)
        {
            return Items.Where(a => a.Type.Unit == namesUnit).ToArray();
        }
    }
}