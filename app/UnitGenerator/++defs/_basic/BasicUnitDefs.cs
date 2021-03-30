using iSukces.UnitedValues;

namespace UnitGenerator
{
    /// <summary>
    ///     After adding new item update also units in <see cref="RelatedUnitGeneratorDefs.GetAllItems">GetAllItems</see>
    /// </summary>
    public class BasicUnitDefs
    {
        public static BasicUnitsCollection All
        {
            get
            {
                if (!(_all is null))
                    return _all;
                var tmp = Ext.GetStaticFieldsValues<BasicUnitDefs, BasicUnit>();
                _all = new BasicUnitsCollection(tmp);

                return _all;
            }
        }

        private static readonly BasicUnit Force = new BasicUnit(nameof(Force), "Newton", true);
        private static readonly BasicUnit Mass = new BasicUnit(nameof(Mass), "Kg", true);


        private static readonly BasicUnit Length = new BasicUnit(nameof(Length), "Meter", true);
        private static readonly BasicUnit Area = new BasicUnit(nameof(Area), "SquareMeter", false);
        private static readonly BasicUnit Volume = new BasicUnit(nameof(Volume), "CubicMeter", false);
        
        private static readonly BasicUnit Time = new BasicUnit(nameof(Time), "Second", true);

        private static readonly BasicUnit
            SquareTime = new BasicUnit(nameof(SquareTime), "SquareSecond", true);


        private static readonly BasicUnit
            CelsiusTemperature = new BasicUnit(nameof(CelsiusTemperature), "Degree", true);

        private static readonly BasicUnit
            KelvinTemperature = new BasicUnit(nameof(KelvinTemperature), "Degree", true);


        private static readonly BasicUnit
            DeltaCelsiusTemperature = new BasicUnit(nameof(DeltaCelsiusTemperature), "Degree", true);

        private static readonly BasicUnit
            DeltaKelvinTemperature = new BasicUnit(nameof(DeltaKelvinTemperature), "Degree", true);

        
        private static readonly BasicUnit
            Energy = new BasicUnit(nameof(Energy), "Joule", true);


        private static BasicUnitsCollection _all;
    }
}