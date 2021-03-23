using System.Linq;

namespace UnitGenerator
{
    public class CommonFractionalUnitsCollection
    {
        public CommonFractionalUnitsCollection(CommonFractionalUnit[] items)
        {
            Items = items;
        }

        public CommonFractionalUnit[] GetBy(string namesUnit)
        {
            return Items.Where(a => a.Type.Unit == namesUnit).ToArray();
        }

        public CommonFractionalUnit[] Items { get; }
    }
}