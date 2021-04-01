using iSukces.UnitedValues;

namespace UnitGenerator
{
    public partial class MultiplicationAlgebraDefs
    {
        public static MultiplicationAlgebra Definition
        {
            get
            {
                var hints = GetBasicOperatorHints();

                var c = new MultiplicationAlgebra()
                    .WithMul<Length, Length, Area>(true)
                    .WithMul<Length, Area, Volume>(true)
                    .WithDiv<Mass, Length, LinearDensity>(hints)
                    .WithDiv<Mass, Area, PlanarDensity>()
                    .WithDiv<Mass, Volume, Density>();

                c.WithDiv<LinearDensity, Length, PlanarDensity>(hints);
                c.WithDiv<LinearDensity, Area, Density>(hints);
                c.WithDiv<PlanarDensity, Length, Density>(hints);

                Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity(c);
                

                c.WithDiv<Force, Area, Pressure>();
                c.WithDiv<Force, Length, LinearForce>();
                return c;
            }
        }
        
        private static OperatorHints GetBasicOperatorHints()
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                args.Result.Comment = args.Input.DebugIs;
                HeuristicOperatorGenerator
                    .TryCreate(args, new ClrTypesResolver(typeof(Length).Assembly));
                args.Handled = true;
            };
            return hints;
        }

    }
}

/*
 *
                 if (args.Input.Is<Length, PlanarDensity, LinearDensity>("*"))
                    Debug.Write("");
                if (args.Input.Is<LinearDensity, PlanarDensity, Length>("/"))
                    Debug.Write("");* 
 */