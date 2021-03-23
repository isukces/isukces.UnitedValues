namespace UnitGenerator
{
    /// <summary>
    ///     After adding new item update also units in <see cref="DerivedUnitGeneratorRunner.GetAllItems">GetAllItems</see>
    /// </summary>
    public class PrimitiveValuesDefinitions
    {
        public static PrimitiveUnitsCollection All
        {
            get
            {
                if (!(_all is null)) 
                    return _all;
                var tmp = Ext.GetStaticFieldsValues<PrimitiveValuesDefinitions, PrimitiveUnit>();
                _all = new PrimitiveUnitsCollection(tmp);

                return _all;
            }
        }

        private static readonly PrimitiveUnit Force = new PrimitiveUnit("Force", "Newton", true);
        private static readonly PrimitiveUnit Weight = new PrimitiveUnit("Weight", "Kg", true);


        private static readonly PrimitiveUnit Length = new PrimitiveUnit("Length", "Meter", true);
        private static readonly PrimitiveUnit Area = new PrimitiveUnit("Area", "SquareMeter", false);
        private static readonly PrimitiveUnit Volume = new PrimitiveUnit("Volume", "CubicMeter", false);


        private static readonly PrimitiveUnit Time = new PrimitiveUnit("Time", "Second", true);

        private static readonly PrimitiveUnit
            SquareTime = new PrimitiveUnit("SquareTime", "SquareSecond", true);
        
        
        
        private static readonly PrimitiveUnit
            CelsiusTemperature = new PrimitiveUnit("CelsiusTemperature", "Degree", true);

        private static readonly PrimitiveUnit
            KelvinTemperature = new PrimitiveUnit("KelvinTemperature", "Degree", true);
             

        private static readonly PrimitiveUnit
            DeltaCelsiusTemperature = new PrimitiveUnit("DeltaCelsiusTemperature", "Degree", true);

        private static readonly PrimitiveUnit
            DeltaKelvinTemperature = new PrimitiveUnit("DeltaKelvinTemperature", "Degree", true);

        
        private static PrimitiveUnitsCollection _all;
    }
}