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
				dict.AddRelated((AreaUnit)SquareMeter, (LengthUnit)LengthUnitDefinition.Meter);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Meter, (AreaUnit)SquareMeter);
				dict.AddRelated((AreaUnit)SquareKm, (LengthUnit)LengthUnitDefinition.Km);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Km, (AreaUnit)SquareKm);
				dict.AddRelated((AreaUnit)SquareDm, (LengthUnit)LengthUnitDefinition.Dm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Dm, (AreaUnit)SquareDm);
				dict.AddRelated((AreaUnit)SquareCm, (LengthUnit)LengthUnitDefinition.Cm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Cm, (AreaUnit)SquareCm);
				dict.AddRelated((AreaUnit)SquareMm, (LengthUnit)LengthUnitDefinition.Mm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mm, (AreaUnit)SquareMm);
				dict.AddRelated((AreaUnit)SquareInch, (LengthUnit)LengthUnitDefinition.Inch);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Inch, (AreaUnit)SquareInch);
				dict.AddRelated((AreaUnit)SquareFoot, (LengthUnit)LengthUnitDefinition.Foot);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Foot, (AreaUnit)SquareFoot);
				dict.AddRelated((AreaUnit)SquareYard, (LengthUnit)LengthUnitDefinition.Yard);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Yard, (AreaUnit)SquareYard);
				dict.AddRelated((AreaUnit)SquareFurlong, (LengthUnit)LengthUnitDefinition.Furlong);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Furlong, (AreaUnit)SquareFurlong);
				dict.AddRelated((AreaUnit)SquareFathom, (LengthUnit)LengthUnitDefinition.Fathom);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Fathom, (AreaUnit)SquareFathom);
				dict.AddRelated((AreaUnit)SquareMile, (LengthUnit)LengthUnitDefinition.Mile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mile, (AreaUnit)SquareMile);
				dict.AddRelated((AreaUnit)SquareNauticalMile, (LengthUnit)LengthUnitDefinition.NauticalMile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.NauticalMile, (AreaUnit)SquareNauticalMile);
		
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
				dict.AddRelated((VolumeUnit)QubicMeter, (LengthUnit)LengthUnitDefinition.Meter);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Meter, (VolumeUnit)QubicMeter);
				dict.AddRelated((VolumeUnit)QubicMeter, (AreaUnit)AreaUnitDefinition.SquareMeter);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareMeter, (VolumeUnit)QubicMeter);
				dict.AddRelated((VolumeUnit)QubicKm, (LengthUnit)LengthUnitDefinition.Km);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Km, (VolumeUnit)QubicKm);
				dict.AddRelated((VolumeUnit)QubicKm, (AreaUnit)AreaUnitDefinition.SquareKm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareKm, (VolumeUnit)QubicKm);
				dict.AddRelated((VolumeUnit)QubicDm, (LengthUnit)LengthUnitDefinition.Dm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Dm, (VolumeUnit)QubicDm);
				dict.AddRelated((VolumeUnit)QubicDm, (AreaUnit)AreaUnitDefinition.SquareDm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareDm, (VolumeUnit)QubicDm);
				dict.AddRelated((VolumeUnit)QubicCm, (LengthUnit)LengthUnitDefinition.Cm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Cm, (VolumeUnit)QubicCm);
				dict.AddRelated((VolumeUnit)QubicCm, (AreaUnit)AreaUnitDefinition.SquareCm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareCm, (VolumeUnit)QubicCm);
				dict.AddRelated((VolumeUnit)QubicMm, (LengthUnit)LengthUnitDefinition.Mm);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mm, (VolumeUnit)QubicMm);
				dict.AddRelated((VolumeUnit)QubicMm, (AreaUnit)AreaUnitDefinition.SquareMm);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareMm, (VolumeUnit)QubicMm);
				dict.AddRelated((VolumeUnit)QubicInch, (LengthUnit)LengthUnitDefinition.Inch);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Inch, (VolumeUnit)QubicInch);
				dict.AddRelated((VolumeUnit)QubicInch, (AreaUnit)AreaUnitDefinition.SquareInch);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareInch, (VolumeUnit)QubicInch);
				dict.AddRelated((VolumeUnit)QubicFoot, (LengthUnit)LengthUnitDefinition.Foot);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Foot, (VolumeUnit)QubicFoot);
				dict.AddRelated((VolumeUnit)QubicFoot, (AreaUnit)AreaUnitDefinition.SquareFoot);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareFoot, (VolumeUnit)QubicFoot);
				dict.AddRelated((VolumeUnit)QubicYard, (LengthUnit)LengthUnitDefinition.Yard);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Yard, (VolumeUnit)QubicYard);
				dict.AddRelated((VolumeUnit)QubicYard, (AreaUnit)AreaUnitDefinition.SquareYard);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareYard, (VolumeUnit)QubicYard);
				dict.AddRelated((VolumeUnit)QubicFurlong, (LengthUnit)LengthUnitDefinition.Furlong);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Furlong, (VolumeUnit)QubicFurlong);
				dict.AddRelated((VolumeUnit)QubicFurlong, (AreaUnit)AreaUnitDefinition.SquareFurlong);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareFurlong, (VolumeUnit)QubicFurlong);
				dict.AddRelated((VolumeUnit)QubicFathom, (LengthUnit)LengthUnitDefinition.Fathom);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Fathom, (VolumeUnit)QubicFathom);
				dict.AddRelated((VolumeUnit)QubicFathom, (AreaUnit)AreaUnitDefinition.SquareFathom);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareFathom, (VolumeUnit)QubicFathom);
				dict.AddRelated((VolumeUnit)QubicMile, (LengthUnit)LengthUnitDefinition.Mile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.Mile, (VolumeUnit)QubicMile);
				dict.AddRelated((VolumeUnit)QubicMile, (AreaUnit)AreaUnitDefinition.SquareMile);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareMile, (VolumeUnit)QubicMile);
				dict.AddRelated((VolumeUnit)QubicNauticalMile, (LengthUnit)LengthUnitDefinition.NauticalMile);
				dict.AddRelated((LengthUnit)LengthUnitDefinition.NauticalMile, (VolumeUnit)QubicNauticalMile);
				dict.AddRelated((VolumeUnit)QubicNauticalMile, (AreaUnit)AreaUnitDefinition.SquareNauticalMile);
				dict.AddRelated((AreaUnit)AreaUnitDefinition.SquareNauticalMile, (VolumeUnit)QubicNauticalMile);
		
		}
    }
}



