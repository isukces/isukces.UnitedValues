namespace UnitGenerator
{
    /// <summary>
    ///     After adding new item update also units in <see cref="DerivedUnitGeneratorRunner.GetAllItems">GetAllItems</see>
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

        private static readonly BasicUnit Force = new BasicUnit("Force", "Newton", true);
        private static readonly BasicUnit Weight = new BasicUnit("Weight", "Kg", true);


        private static readonly BasicUnit Length = new BasicUnit("Length", "Meter", true);
        private static readonly BasicUnit Area = new BasicUnit("Area", "SquareMeter", false);
        private static readonly BasicUnit Volume = new BasicUnit("Volume", "CubicMeter", false);


        private static readonly BasicUnit Time = new BasicUnit("Time", "Second", true);

        private static readonly BasicUnit
            SquareTime = new BasicUnit("SquareTime", "SquareSecond", true);


        private static readonly BasicUnit
            CelsiusTemperature = new BasicUnit("CelsiusTemperature", "Degree", true);

        private static readonly BasicUnit
            KelvinTemperature = new BasicUnit("KelvinTemperature", "Degree", true);


        private static readonly BasicUnit
            DeltaCelsiusTemperature = new BasicUnit("DeltaCelsiusTemperature", "Degree", true);

        private static readonly BasicUnit
            DeltaKelvinTemperature = new BasicUnit("DeltaKelvinTemperature", "Degree", true);


        private static BasicUnitsCollection _all;
    }
}