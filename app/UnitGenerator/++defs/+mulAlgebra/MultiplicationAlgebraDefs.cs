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
                hints.ImplementingClass = nameof(MultiplicationAlgebraDefs);
                

                var c = new MultiplicationAlgebra()
                    .WithMul<Length, Length, Area>(null, true)
                    .WithMul<Length, Area, Volume>(null, true)
                    .WithDiv<Mass, Length, LinearDensity>(hints)
                    .WithDiv<Mass, Area, PlanarDensity>(hints)
                    .WithDiv<Mass, Volume, Density>(hints);

                c.WithDiv<LinearDensity, Length, PlanarDensity>(hints);
                c.WithDiv<LinearDensity, Area, Density>(hints);
                c.WithDiv<PlanarDensity, Length, Density>(hints);

                Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity(c);

                // c.WithDiv<Force, Area, Pressure>();

                Def_Energy_Time_Power.Setup(c);
                Def_Power_EnergyMassDensity_MassStream.Setup(c);
                Def_LinearForce_Length_Pressure.Setup(c);
                Def_Force_Length_LinearForce.Setup(c);

                c.WithDiv<MassStream, Density, VolumeStream>(hints);
                c.WithDiv<Length, Time, Velocity>(hints);

                c.WithDiv<VolumeStream, Area, Velocity>(hints);
                return c;
            }
        }
        
    }
}
