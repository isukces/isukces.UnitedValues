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

        public static readonly FractionUnit LinearDensity
            = FractionUnit.Make<LinearDensity, Mass, Length>();

 
        public static readonly FractionUnit Velocity
            = FractionUnit.Make<Velocity, Length, Time>();

        public static readonly FractionUnit Density
            = FractionUnit.Make<Density, Mass, Volume>();

        public static readonly FractionUnit PlanarDensity
            = FractionUnit.Make<PlanarDensity, Mass, Area>();

        /*public static readonly FractionUnit Pressure
            = FractionUnit.Make<Pressure, Force, Area>();*/

        public static readonly FractionUnit Acceleration
            = FractionUnit.Make<Acceleration, Length, SquareTime>();


        public static readonly FractionUnit LinearForce
            = FractionUnit.Make<LinearForce, Force, Length>();

        public static readonly FractionUnit MassStream
            = FractionUnit.Make<MassStream, Mass, Time>();

  
        public static readonly FractionUnit VolumeStream
            = FractionUnit.Make<VolumeStream, Volume, Time>();
        

        public static readonly FractionUnit EnergyMassDensity
            = FractionUnit.Make<Energy, Mass>(nameof(EnergyMassDensity));

        private static FractionUnitsCollection _allFractionUnitses;


        /*
        public static readonly FractionUnit SpecificHeatCapacity
            = FractionUnit.Make<SpecificHeatCapacity, Energy, MassDetlaKelvin>();
    */
        public static readonly FractionUnit SpecificHeatCapacity
            = FractionUnit.Make<SpecificHeatCapacity, EnergyMassDensity, KelvinTemperature>();
    }
}