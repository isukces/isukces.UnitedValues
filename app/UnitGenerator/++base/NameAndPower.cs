using System.ComponentModel;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class NameAndPower
    {
        public NameAndPower(string propertyname, int power)
        {
            Propertyname = propertyname;
            Power        = power;
        }

        public override string ToString()
        {
            return $"Propertyname={Propertyname}, Power={Power}";
        }

        public string Propertyname { get; }

        public int Power { get; }
    }
}