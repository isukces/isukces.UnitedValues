using System.Diagnostics;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public partial class MultiplicationAlgebraDefs
    {
        private static OperatorHints GetBasicOperatorHints()
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                args.Result.Comment = args.Input.DebugIs;
                Debug.WriteLine("Processing " + args.Input.DebugIs);
                CreateHeuristicCode(args);
                args.Handled = true;
            };
            return hints;
        }

        public static MultiplicationAlgebra Definition
        {
            get
            {
                var hints = GetBasicOperatorHints();

                var c = new MultiplicationAlgebra()
                    .WithMul<Length, Length, Area>(true)
                    .WithMul<Length, Area, Volume>(true)
                    .WithDiv<Mass, Length, LinearDensity>(hints)
                    .WithDiv<Mass, Area, PlanarDensity>(hints)
                    .WithDiv<Mass, Volume, Density>(hints);

                c.WithDiv<LinearDensity, Length, PlanarDensity>(hints);
                c.WithDiv<LinearDensity, Area, Density>(hints);
                c.WithDiv<PlanarDensity, Length, Density>(hints);

                Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity(c);

                c.WithDiv<Force, Area, Pressure>();
                c.WithDiv<Force, Length, LinearForce>();

                {
                    var hints2 = new OperatorHints();
                    hints2.CreateOperatorCode += (sender, args) =>
                    {
                        args.Handled = true;
                        var q = args.Input.DebugIs;
                        if (args.Input.Is<Energy, Time, Power>("/"))
                        {
                            Debug.Write("");
                            CreateHeuristicCode(args);
                            return;
                        }

                        /*args.Result.Comment = args.Input.DebugIs;
                        HeuristicOperatorGenerator
                            .TryCreate(args, new ClrTypesResolver(typeof(Length).Assembly));
                        */
                       
                        args.Result.SetThrow();
                    };
                    c.WithDiv<Energy, Time, Power>(hints2);
                }

                /*{
                    var hints2 = new OperatorHints();
                    hints2.CreateOperatorCode += (sender, args) =>
                    {
                        /*args.Result.Comment = args.Input.DebugIs;
                        HeuristicOperatorGenerator
                            .TryCreate(args, new ClrTypesResolver(typeof(Length).Assembly));
                        args.Handled = true;#1#
                    };
                    c.WithDiv<Power, EnergyMassDensity, MassStream>(hints2);
                }*/
                return c;
            }
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