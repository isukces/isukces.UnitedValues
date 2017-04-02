using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isukces.UnitedValues
{
    public partial struct Area
    {
        public static Area FromKm(decimal m) => new Area(m, AreaUnitDefinition.SquareKm);
        public static Area FromKm(long m) => new Area(m, AreaUnitDefinition.SquareKm);
        public static Area FromKm(double m) => new Area((decimal)m, AreaUnitDefinition.SquareKm);


        public static Area FromMeter(decimal m) => new Area(m, AreaUnitDefinition.SquareMeter);
        public static Area FromMeter(long m) => new Area(m, AreaUnitDefinition.SquareMeter);
        public static Area FromMeter(double m) => new Area((decimal)m, AreaUnitDefinition.SquareMeter);


       

        public Area ConvertToMeter()
        {
            return ConvertTo(AreaUnitDefinition.SquareMeter);
        }


        public Area RoundKg(Area w, int decimalPlaces)
        {
            return FromMeter(Math.Round(w.Value, decimalPlaces));
        }
    }

    public partial struct AreaUnit
    {
        static AreaUnit()
        {
            KnownUnits = new Dictionary<AreaUnit, decimal>();

            foreach (var i in AreaUnitDefinition.All)
                AddDefinition(i);
        }
    }

    public partial struct AreaUnitDefinition
    {
        public const string Square = "²";
    }

 
}
