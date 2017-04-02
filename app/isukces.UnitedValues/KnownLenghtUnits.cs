using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public partial struct LengthUnitDefinition
    {
        public static readonly LengthUnitDefinition Meter = new LengthUnitDefinition("m", 1m);
        public static readonly LengthUnitDefinition Km = new LengthUnitDefinition("km", 1000m);
        public static readonly LengthUnitDefinition Dm = new LengthUnitDefinition("dm", 0.1m);
        public static readonly LengthUnitDefinition Cm = new LengthUnitDefinition("cm", 0.01m);
        public static readonly LengthUnitDefinition Mm = new LengthUnitDefinition("mm", 0.001m);
        public static readonly LengthUnitDefinition Inch = new LengthUnitDefinition("inch", 0.0254m);
        public static readonly LengthUnitDefinition Foot = new LengthUnitDefinition("ft", 0.3048m);
        public static readonly LengthUnitDefinition Yard = new LengthUnitDefinition("yd", 0.9144m);
        public static readonly LengthUnitDefinition Furlong = new LengthUnitDefinition("fg", 201.1680m);
        public static readonly LengthUnitDefinition Fathom = new LengthUnitDefinition("fh", 1.8288m);
        public static readonly LengthUnitDefinition Mile = new LengthUnitDefinition("mil", 1609.344m);
        public static readonly LengthUnitDefinition NauticalMile = new LengthUnitDefinition("nm", 1852m);
		public static IEnumerable<LengthUnitDefinition> All {
			get {
				yield return Meter;
				yield return Km;
				yield return Dm;
				yield return Cm;
				yield return Mm;
				yield return Inch;
				yield return Foot;
				yield return Yard;
				yield return Furlong;
				yield return Fathom;
				yield return Mile;
				yield return NauticalMile;
			}
		}
    }
    public partial struct AreaUnitDefinition
    {
        public static readonly AreaUnitDefinition SquareMeter = new AreaUnitDefinition("m²", 1m * 1m, "m2");
        public static readonly AreaUnitDefinition SquareKm = new AreaUnitDefinition("km²", 1000m * 1000m, "km2");
        public static readonly AreaUnitDefinition SquareDm = new AreaUnitDefinition("dm²", 0.1m * 0.1m, "dm2");
        public static readonly AreaUnitDefinition SquareCm = new AreaUnitDefinition("cm²", 0.01m * 0.01m, "cm2");
        public static readonly AreaUnitDefinition SquareMm = new AreaUnitDefinition("mm²", 0.001m * 0.001m, "mm2");
        public static readonly AreaUnitDefinition SquareInch = new AreaUnitDefinition("inch²", 0.0254m * 0.0254m, "inch2");
        public static readonly AreaUnitDefinition SquareFoot = new AreaUnitDefinition("ft²", 0.3048m * 0.3048m, "ft2");
        public static readonly AreaUnitDefinition SquareYard = new AreaUnitDefinition("yd²", 0.9144m * 0.9144m, "yd2");
        public static readonly AreaUnitDefinition SquareFurlong = new AreaUnitDefinition("fg²", 201.1680m * 201.1680m, "fg2");
        public static readonly AreaUnitDefinition SquareFathom = new AreaUnitDefinition("fh²", 1.8288m * 1.8288m, "fh2");
        public static readonly AreaUnitDefinition SquareMile = new AreaUnitDefinition("mil²", 1609.344m * 1609.344m, "mil2");
        public static readonly AreaUnitDefinition SquareNauticalMile = new AreaUnitDefinition("nm²", 1852m * 1852m, "nm2");
		public static IEnumerable<AreaUnitDefinition> All {
			get {
				yield return SquareMeter;
				yield return SquareKm;
				yield return SquareDm;
				yield return SquareCm;
				yield return SquareMm;
				yield return SquareInch;
				yield return SquareFoot;
				yield return SquareYard;
				yield return SquareFurlong;
				yield return SquareFathom;
				yield return SquareMile;
				yield return SquareNauticalMile;
			}
		}

		internal static void Register(UnitRelationsDictionary dict) {
				dict.AddRelated((AreaUnit)SquareMeter, LengthUnitDefinition.Meter);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Meter, SquareMeter);
				dict.AddRelated((AreaUnit)SquareKm, LengthUnitDefinition.Km);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Km, SquareKm);
				dict.AddRelated((AreaUnit)SquareDm, LengthUnitDefinition.Dm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Dm, SquareDm);
				dict.AddRelated((AreaUnit)SquareCm, LengthUnitDefinition.Cm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Cm, SquareCm);
				dict.AddRelated((AreaUnit)SquareMm, LengthUnitDefinition.Mm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mm, SquareMm);
				dict.AddRelated((AreaUnit)SquareInch, LengthUnitDefinition.Inch);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Inch, SquareInch);
				dict.AddRelated((AreaUnit)SquareFoot, LengthUnitDefinition.Foot);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Foot, SquareFoot);
				dict.AddRelated((AreaUnit)SquareYard, LengthUnitDefinition.Yard);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Yard, SquareYard);
				dict.AddRelated((AreaUnit)SquareFurlong, LengthUnitDefinition.Furlong);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Furlong, SquareFurlong);
				dict.AddRelated((AreaUnit)SquareFathom, LengthUnitDefinition.Fathom);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Fathom, SquareFathom);
				dict.AddRelated((AreaUnit)SquareMile, LengthUnitDefinition.Mile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mile, SquareMile);
				dict.AddRelated((AreaUnit)SquareNauticalMile, LengthUnitDefinition.NauticalMile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.NauticalMile, SquareNauticalMile);
		
		}

    }


    public partial struct VolumeUnitDefinition
    {
        public static readonly VolumeUnitDefinition QubicMeter = new VolumeUnitDefinition("m³", 1m * 1m * 1m, "m3");
        public static readonly VolumeUnitDefinition QubicKm = new VolumeUnitDefinition("km³", 1000m * 1000m * 1000m, "km3");
        public static readonly VolumeUnitDefinition QubicDm = new VolumeUnitDefinition("dm³", 0.1m * 0.1m * 0.1m, "dm3");
        public static readonly VolumeUnitDefinition QubicCm = new VolumeUnitDefinition("cm³", 0.01m * 0.01m * 0.01m, "cm3");
        public static readonly VolumeUnitDefinition QubicMm = new VolumeUnitDefinition("mm³", 0.001m * 0.001m * 0.001m, "mm3");
        public static readonly VolumeUnitDefinition QubicInch = new VolumeUnitDefinition("inch³", 0.0254m * 0.0254m * 0.0254m, "inch3");
        public static readonly VolumeUnitDefinition QubicFoot = new VolumeUnitDefinition("ft³", 0.3048m * 0.3048m * 0.3048m, "ft3");
        public static readonly VolumeUnitDefinition QubicYard = new VolumeUnitDefinition("yd³", 0.9144m * 0.9144m * 0.9144m, "yd3");
        public static readonly VolumeUnitDefinition QubicFurlong = new VolumeUnitDefinition("fg³", 201.1680m * 201.1680m * 201.1680m, "fg3");
        public static readonly VolumeUnitDefinition QubicFathom = new VolumeUnitDefinition("fh³", 1.8288m * 1.8288m * 1.8288m, "fh3");
        public static readonly VolumeUnitDefinition QubicMile = new VolumeUnitDefinition("mil³", 1609.344m * 1609.344m * 1609.344m, "mil3");
        public static readonly VolumeUnitDefinition QubicNauticalMile = new VolumeUnitDefinition("nm³", 1852m * 1852m * 1852m, "nm3");
		public static IEnumerable<VolumeUnitDefinition> All {
			get {
				yield return QubicMeter;
				yield return QubicKm;
				yield return QubicDm;
				yield return QubicCm;
				yield return QubicMm;
				yield return QubicInch;
				yield return QubicFoot;
				yield return QubicYard;
				yield return QubicFurlong;
				yield return QubicFathom;
				yield return QubicMile;
				yield return QubicNauticalMile;
			}
		}

		internal static void Register(UnitRelationsDictionary dict) {
				dict.AddRelated((VolumeUnit)QubicMeter, LengthUnitDefinition.Meter);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Meter, QubicMeter);
				dict.AddRelated((VolumeUnit)QubicMeter, AreaUnitDefinition.SquareMeter);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareMeter, QubicMeter);
				dict.AddRelated((VolumeUnit)QubicKm, LengthUnitDefinition.Km);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Km, QubicKm);
				dict.AddRelated((VolumeUnit)QubicKm, AreaUnitDefinition.SquareKm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareKm, QubicKm);
				dict.AddRelated((VolumeUnit)QubicDm, LengthUnitDefinition.Dm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Dm, QubicDm);
				dict.AddRelated((VolumeUnit)QubicDm, AreaUnitDefinition.SquareDm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareDm, QubicDm);
				dict.AddRelated((VolumeUnit)QubicCm, LengthUnitDefinition.Cm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Cm, QubicCm);
				dict.AddRelated((VolumeUnit)QubicCm, AreaUnitDefinition.SquareCm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareCm, QubicCm);
				dict.AddRelated((VolumeUnit)QubicMm, LengthUnitDefinition.Mm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mm, QubicMm);
				dict.AddRelated((VolumeUnit)QubicMm, AreaUnitDefinition.SquareMm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareMm, QubicMm);
				dict.AddRelated((VolumeUnit)QubicInch, LengthUnitDefinition.Inch);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Inch, QubicInch);
				dict.AddRelated((VolumeUnit)QubicInch, AreaUnitDefinition.SquareInch);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareInch, QubicInch);
				dict.AddRelated((VolumeUnit)QubicFoot, LengthUnitDefinition.Foot);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Foot, QubicFoot);
				dict.AddRelated((VolumeUnit)QubicFoot, AreaUnitDefinition.SquareFoot);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareFoot, QubicFoot);
				dict.AddRelated((VolumeUnit)QubicYard, LengthUnitDefinition.Yard);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Yard, QubicYard);
				dict.AddRelated((VolumeUnit)QubicYard, AreaUnitDefinition.SquareYard);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareYard, QubicYard);
				dict.AddRelated((VolumeUnit)QubicFurlong, LengthUnitDefinition.Furlong);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Furlong, QubicFurlong);
				dict.AddRelated((VolumeUnit)QubicFurlong, AreaUnitDefinition.SquareFurlong);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareFurlong, QubicFurlong);
				dict.AddRelated((VolumeUnit)QubicFathom, LengthUnitDefinition.Fathom);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Fathom, QubicFathom);
				dict.AddRelated((VolumeUnit)QubicFathom, AreaUnitDefinition.SquareFathom);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareFathom, QubicFathom);
				dict.AddRelated((VolumeUnit)QubicMile, LengthUnitDefinition.Mile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mile, QubicMile);
				dict.AddRelated((VolumeUnit)QubicMile, AreaUnitDefinition.SquareMile);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareMile, QubicMile);
				dict.AddRelated((VolumeUnit)QubicNauticalMile, LengthUnitDefinition.NauticalMile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.NauticalMile, QubicNauticalMile);
				dict.AddRelated((VolumeUnit)QubicNauticalMile, AreaUnitDefinition.SquareNauticalMile);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareNauticalMile, QubicNauticalMile);
		
		}
    }
}



