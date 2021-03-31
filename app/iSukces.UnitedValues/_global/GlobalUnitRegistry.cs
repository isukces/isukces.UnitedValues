using System.Reflection;

namespace iSukces.UnitedValues
{
    public static class GlobalUnitRegistry
    {
        static GlobalUnitRegistry()
        {
            Relations = new UnitRelationsDictionary();
            Factors   = new UnitExchangeFactors();

            AreaUnits.Register(Relations);
            VolumeUnits.Register(Relations);
            SquareTimeUnits.Register(Relations);

            foreach (var i in typeof(GlobalUnitRegistry).Assembly.GetTypes())
            {
                var at = i.GetCustomAttribute<UnitsContainerAttribute>();
                if (at is null)
                    continue;
                // Console.WriteLine(i);
                //  public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
                var m = i.GetMethod("RegisterUnitExchangeFactors");
                m?.Invoke(null, new object[] {Factors});
            }

            // Factors.RegisterMany(LengthUnits.All);
            /*
            Factors.RegisterMany(AreaUnits.All);
            Factors.RegisterMany(VolumeUnits.All);
            Factors.RegisterMany(WeightUnits.All);
            Factors.RegisterMany(ForceUnits.All);*/
        }

        public static readonly UnitRelationsDictionary Relations;
        public static readonly UnitExchangeFactors Factors;
    }
}