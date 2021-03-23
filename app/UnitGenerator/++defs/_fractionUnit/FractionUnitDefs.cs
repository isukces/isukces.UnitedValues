using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class FractionUnitDefs
    {
        public static FractionUnit IsFraction(TypesGroup right)
        {
            foreach (var i in All.Items)
                if (i.UnitTypes.Value == right.Value)
                    return i;
            return null;
        }


        public static FractionUnitsCollection All
        {
            get
            {
                if (!(_allFractionUnitses is null)) return _allFractionUnitses;
                var q = Ext.GetStaticFieldsValues<FractionUnitDefs, FractionUnit>();
                _allFractionUnitses = new FractionUnitsCollection(q);

                return _allFractionUnitses;
            }
        }

        public static readonly FractionUnit LinearDensity = FractionUnit.Make<LinearDensity, Weight, Length>();
        public static readonly FractionUnit Density = FractionUnit.Make<Density, Weight, Volume>();
        public static readonly FractionUnit PlanarDensity = FractionUnit.Make<PlanarDensity, Weight, Area>();
        public static readonly FractionUnit Pressure = FractionUnit.Make<Pressure, Force, Area>();

        public static readonly FractionUnit Acceleration 
            = FractionUnit.Make<Acceleration, Length, SquareTime>();

        public static readonly FractionUnit LinearForce
            = FractionUnit.Make<Length, SquareTime>("LinearForce");
        

        private static FractionUnitsCollection _allFractionUnitses;
    }
}