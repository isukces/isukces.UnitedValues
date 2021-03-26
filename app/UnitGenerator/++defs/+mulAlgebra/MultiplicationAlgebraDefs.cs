using iSukces.UnitedValues;

namespace UnitGenerator
{
    public partial class MultiplicationAlgebraDefs
    {
        public static MultiplicationAlgebra Definition
        {
            get
            {
                var c = new MultiplicationAlgebra()
                    .WithMul<Length, Length, Area>(true)
                    .WithMul<Length, Area, Volume>(true)
                    .WithDiv<Mass, Length, LinearDensity>()
                    .WithDiv<Mass, Area, PlanarDensity>()
                    .WithDiv<Mass, Volume, Density>();

                Add_Length_PlanarDensity_LinearDensity(c);
                Add_PlanarDensity_Length_Density(c);
                Add_LinearDensity_Area_Density(c);

                c.WithDiv<Force, Area, Pressure>();
                c.WithDiv<Force, Length, LinearForce>();
                return c;
            }
        }
    }
}