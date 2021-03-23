using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class FractionUnitDefs
    {
        public static FractionUnitInfo IsFraction(TypesGoup right)
        {
            foreach (var i in AllFractionUnits.Items)
                if (i.Names.Value == right.Value)
                    return i;
            return null;
        }

        private static FractionUnitInfoCollection LazyGetAllFractionUnits()
        {
            var q = Ext.GetStaticFieldsValues<FractionUnitDefs, FractionUnitInfo>();
            return new FractionUnitInfoCollection(q);
        }

        public static FractionUnitInfoCollection AllFractionUnits => LazyAllFractionUnits.Value;

        private static readonly Lazy<FractionUnitInfoCollection> LazyAllFractionUnits
            = new Lazy<FractionUnitInfoCollection>(LazyGetAllFractionUnits);

        public static readonly FractionUnitInfo LinearDensity = FractionUnitInfo.Make<LinearDensity, Weight, Length>();
        public static readonly FractionUnitInfo Density = FractionUnitInfo.Make<Density, Weight, Volume>();
        public static readonly FractionUnitInfo PlanarDensity = FractionUnitInfo.Make<PlanarDensity, Weight, Area>();
        public static readonly FractionUnitInfo Pressure = FractionUnitInfo.Make<Pressure, Force, Area>();

        public static readonly FractionUnitInfo
            Acceleration = FractionUnitInfo.Make<Acceleration, Length, SquareTime>();
    }
}