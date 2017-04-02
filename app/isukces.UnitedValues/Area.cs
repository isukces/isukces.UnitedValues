using System;
using System.Collections.Generic;
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
            AddDefinition(AreaUnitDefinition.SquareKm);
            AddDefinition(AreaUnitDefinition.SquareMeter);
            AddDefinition(AreaUnitDefinition.SquareMm);

            AddDefinition(AreaUnitDefinition.SquareCm);
            AddDefinition(AreaUnitDefinition.SquareFeet);
            AddDefinition(AreaUnitDefinition.SquareInch);
        }
    }

    public partial struct AreaUnitDefinition
    {
        public const string Square = "²";
        public static readonly AreaUnitDefinition SquareMeter = new AreaUnitDefinition("m" + Square, 1, "m2");
        public static readonly AreaUnitDefinition SquareKm = new AreaUnitDefinition("km" + Square, 1000 * 1000, "km2");
        public static readonly AreaUnitDefinition SquareMm = new AreaUnitDefinition("mm" + Square, 0.001m * 0.001m, "mm2");
        public static readonly AreaUnitDefinition SquareCm = new AreaUnitDefinition("cm" + Square, 0.01m * 0.001m, "cm2");
        public static readonly AreaUnitDefinition SquareInch = new AreaUnitDefinition("inch" + Square, 0.0254m * 0.0254m, "inch2");
        public static readonly AreaUnitDefinition SquareFeet = new AreaUnitDefinition("ft" + Square, 0.0254m * 12 * 0.0254m * 12, "ft2");
    }
}
