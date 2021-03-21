using System.Collections.Generic;
using iSukces.UnitedValues;
namespace iSukces.UnitedValues
{

	public static partial class LengthUnits
    {
        public static readonly UnitDefinition<LengthUnit> Meter = new UnitDefinition<LengthUnit>("m", 1m);
        public static readonly UnitDefinition<LengthUnit> Km = new UnitDefinition<LengthUnit>("km", 1000m);
        public static readonly UnitDefinition<LengthUnit> Dm = new UnitDefinition<LengthUnit>("dm", 0.1m);
        public static readonly UnitDefinition<LengthUnit> Cm = new UnitDefinition<LengthUnit>("cm", 0.01m);
        public static readonly UnitDefinition<LengthUnit> Mm = new UnitDefinition<LengthUnit>("mm", 0.001m);
        public static readonly UnitDefinition<LengthUnit> Inch = new UnitDefinition<LengthUnit>("inch", 0.0254m);
        public static readonly UnitDefinition<LengthUnit> Foot = new UnitDefinition<LengthUnit>("ft", 0.3048m);
        public static readonly UnitDefinition<LengthUnit> Yard = new UnitDefinition<LengthUnit>("yd", 0.9144m);
        public static readonly UnitDefinition<LengthUnit> Furlong = new UnitDefinition<LengthUnit>("fg", 201.1680m);
        public static readonly UnitDefinition<LengthUnit> Fathom = new UnitDefinition<LengthUnit>("fh", 1.8288m);
        public static readonly UnitDefinition<LengthUnit> Mile = new UnitDefinition<LengthUnit>("mil", 1609.344m);
        public static readonly UnitDefinition<LengthUnit> NauticalMile = new UnitDefinition<LengthUnit>("nm", 1852m);
		public static IEnumerable<UnitDefinition<LengthUnit>> All {
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

    public static partial class AreaUnits
    {
        public static readonly UnitDefinition<AreaUnit> SquareMeter = new UnitDefinition<AreaUnit>("m²", 1m * 1m, "m2");
        public static readonly UnitDefinition<AreaUnit> SquareKm = new UnitDefinition<AreaUnit>("km²", 1000m * 1000m, "km2");
        public static readonly UnitDefinition<AreaUnit> SquareDm = new UnitDefinition<AreaUnit>("dm²", 0.1m * 0.1m, "dm2");
        public static readonly UnitDefinition<AreaUnit> SquareCm = new UnitDefinition<AreaUnit>("cm²", 0.01m * 0.01m, "cm2");
        public static readonly UnitDefinition<AreaUnit> SquareMm = new UnitDefinition<AreaUnit>("mm²", 0.001m * 0.001m, "mm2");
        public static readonly UnitDefinition<AreaUnit> SquareInch = new UnitDefinition<AreaUnit>("inch²", 0.0254m * 0.0254m, "inch2");
        public static readonly UnitDefinition<AreaUnit> SquareFoot = new UnitDefinition<AreaUnit>("ft²", 0.3048m * 0.3048m, "ft2");
        public static readonly UnitDefinition<AreaUnit> SquareYard = new UnitDefinition<AreaUnit>("yd²", 0.9144m * 0.9144m, "yd2");
        public static readonly UnitDefinition<AreaUnit> SquareFurlong = new UnitDefinition<AreaUnit>("fg²", 201.1680m * 201.1680m, "fg2");
        public static readonly UnitDefinition<AreaUnit> SquareFathom = new UnitDefinition<AreaUnit>("fh²", 1.8288m * 1.8288m, "fh2");
        public static readonly UnitDefinition<AreaUnit> SquareMile = new UnitDefinition<AreaUnit>("mil²", 1609.344m * 1609.344m, "mil2");
        public static readonly UnitDefinition<AreaUnit> SquareNauticalMile = new UnitDefinition<AreaUnit>("nm²", 1852m * 1852m, "nm2");
		public static IEnumerable<UnitDefinition<AreaUnit>> All {
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
			dict.AddRelated<AreaUnit,LengthUnit>(SquareMeter, LengthUnits.Meter);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Meter, SquareMeter);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareKm, LengthUnits.Km);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Km, SquareKm);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareDm, LengthUnits.Dm);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Dm, SquareDm);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareCm, LengthUnits.Cm);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Cm, SquareCm);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareMm, LengthUnits.Mm);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Mm, SquareMm);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareInch, LengthUnits.Inch);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Inch, SquareInch);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareFoot, LengthUnits.Foot);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Foot, SquareFoot);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareYard, LengthUnits.Yard);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Yard, SquareYard);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareFurlong, LengthUnits.Furlong);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Furlong, SquareFurlong);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareFathom, LengthUnits.Fathom);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Fathom, SquareFathom);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareMile, LengthUnits.Mile);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Mile, SquareMile);
			dict.AddRelated<AreaUnit,LengthUnit>(SquareNauticalMile, LengthUnits.NauticalMile);
			dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.NauticalMile, SquareNauticalMile);
		
		}

    }


    public static partial class VolumeUnits
    {
        public static readonly UnitDefinition<VolumeUnit> QubicMeter = new UnitDefinition<VolumeUnit>("m³", 1m * 1m * 1m, "m3");
        public static readonly UnitDefinition<VolumeUnit> QubicKm = new UnitDefinition<VolumeUnit>("km³", 1000m * 1000m * 1000m, "km3");
        public static readonly UnitDefinition<VolumeUnit> QubicDm = new UnitDefinition<VolumeUnit>("dm³", 0.1m * 0.1m * 0.1m, "dm3");
        public static readonly UnitDefinition<VolumeUnit> QubicCm = new UnitDefinition<VolumeUnit>("cm³", 0.01m * 0.01m * 0.01m, "cm3");
        public static readonly UnitDefinition<VolumeUnit> QubicMm = new UnitDefinition<VolumeUnit>("mm³", 0.001m * 0.001m * 0.001m, "mm3");
        public static readonly UnitDefinition<VolumeUnit> QubicInch = new UnitDefinition<VolumeUnit>("inch³", 0.0254m * 0.0254m * 0.0254m, "inch3");
        public static readonly UnitDefinition<VolumeUnit> QubicFoot = new UnitDefinition<VolumeUnit>("ft³", 0.3048m * 0.3048m * 0.3048m, "ft3");
        public static readonly UnitDefinition<VolumeUnit> QubicYard = new UnitDefinition<VolumeUnit>("yd³", 0.9144m * 0.9144m * 0.9144m, "yd3");
        public static readonly UnitDefinition<VolumeUnit> QubicFurlong = new UnitDefinition<VolumeUnit>("fg³", 201.1680m * 201.1680m * 201.1680m, "fg3");
        public static readonly UnitDefinition<VolumeUnit> QubicFathom = new UnitDefinition<VolumeUnit>("fh³", 1.8288m * 1.8288m * 1.8288m, "fh3");
        public static readonly UnitDefinition<VolumeUnit> QubicMile = new UnitDefinition<VolumeUnit>("mil³", 1609.344m * 1609.344m * 1609.344m, "mil3");
        public static readonly UnitDefinition<VolumeUnit> QubicNauticalMile = new UnitDefinition<VolumeUnit>("nm³", 1852m * 1852m * 1852m, "nm3");
		public static IEnumerable<UnitDefinition<VolumeUnit>> All {
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
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicMeter, LengthUnits.Meter);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Meter, QubicMeter);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicMeter, AreaUnits.SquareMeter);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareMeter, QubicMeter);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicKm, LengthUnits.Km);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Km, QubicKm);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicKm, AreaUnits.SquareKm);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareKm, QubicKm);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicDm, LengthUnits.Dm);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Dm, QubicDm);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicDm, AreaUnits.SquareDm);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareDm, QubicDm);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicCm, LengthUnits.Cm);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Cm, QubicCm);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicCm, AreaUnits.SquareCm);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareCm, QubicCm);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicMm, LengthUnits.Mm);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Mm, QubicMm);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicMm, AreaUnits.SquareMm);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareMm, QubicMm);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicInch, LengthUnits.Inch);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Inch, QubicInch);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicInch, AreaUnits.SquareInch);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareInch, QubicInch);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicFoot, LengthUnits.Foot);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Foot, QubicFoot);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicFoot, AreaUnits.SquareFoot);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareFoot, QubicFoot);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicYard, LengthUnits.Yard);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Yard, QubicYard);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicYard, AreaUnits.SquareYard);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareYard, QubicYard);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicFurlong, LengthUnits.Furlong);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Furlong, QubicFurlong);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicFurlong, AreaUnits.SquareFurlong);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareFurlong, QubicFurlong);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicFathom, LengthUnits.Fathom);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Fathom, QubicFathom);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicFathom, AreaUnits.SquareFathom);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareFathom, QubicFathom);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicMile, LengthUnits.Mile);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.Mile, QubicMile);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicMile, AreaUnits.SquareMile);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareMile, QubicMile);
				dict.AddRelated<VolumeUnit,LengthUnit>(QubicNauticalMile, LengthUnits.NauticalMile);
				dict.AddRelated<LengthUnit,VolumeUnit>(LengthUnits.NauticalMile, QubicNauticalMile);
				dict.AddRelated<VolumeUnit,AreaUnit>(QubicNauticalMile, AreaUnits.SquareNauticalMile);
				dict.AddRelated<AreaUnit,VolumeUnit>(AreaUnits.SquareNauticalMile, QubicNauticalMile);
		
		}
    }
}



