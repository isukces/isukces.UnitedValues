using iSukces.UnitedValues;

namespace UnitGenerator
{
    public partial class MultiplicationAlgebraDefs
    {
        public static MultiplicationAlgebra Definition
        {
            get
            {
                var hints = AlgebraDefUtils.GetBasicOperatorHints();

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

                Def_Energy_Time_Power.Setup(c);
                Def_Power_EnergyMassDensity_MassStream.Setup(c);

                {
                    c.WithDiv<MassStream, Density, VolumeStream>(hints);
                    c.WithDiv<Length, Time, Velocity>(hints);
                }
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