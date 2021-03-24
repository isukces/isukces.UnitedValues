using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class MultiplicationAlgebraDefs
    {
        public static MultiplicationAlgebra Definition
        {
            get
            {
                var c = new MultiplicationAlgebra()

                        // m*m => m²
                        .WithMul<Length, Length, Area>(true)
                        .WithMul<Length, Area, Volume>(true)

                        // N / m² => N/m²
                        .WithDiv<Force, Area, Pressure>(false)

                        // N / m => N/m
                        .WithDiv<Force, Length, LinearForce>(false)
                    
                    /*
                 *          
        
            AddDiv(linForce, distance, pressure); // N/m  / m  => N/m²
            AddDiv(force, area, pressure); 
            AddMul(mass, acceleration, force); // kg * m/s² => N
            AddMul(areaDensity, acceleration, pressure); // kg/m² * m/s² => N/m²

            AddMul(density, distance, areaDensity); // kg/m³ * m => kh/m²
            // AddMul(areaDensity, area,         pressure);

            AddMul(force, distance, momentum); // N * m = Nm
            AddMul(linForce, area, momentum); // N/m * m² = Nm

            AddMul(temperature, linearExpansion, UnitDefinition.Scalar);
                 * 
                 */
                    ;
                return c;
            }
        }
    }
}