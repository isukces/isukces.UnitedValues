using System.IO;

namespace UnitGenerator
{
    public class AlgebraGeneratorRunner
    {
        public static void Run(string basePath, string nameSpace)
        {
            void AddMul(UnitDefinition a, UnitDefinition b, UnitDefinition result)
            {
                a.AddMul(a, b, result);
            }

            void AddDiv(UnitDefinition a, UnitDefinition b, UnitDefinition result)
            {
                // a/b = result 
                // b * result = a
                AddMul(b, result, a);
            }

            AddMul(distance, distance, area); // m*m => m²
            AddDiv(force, distance, linForce); // N / m => N/m
            //AddDiv(linForce, distance, pressure); // N/m  / m  => N/m²
            // AddDiv(force, area, pressure); // N / m² => N/m²
            AddMul(mass, acceleration, force); // kg * m/s² => N
            // AddMul(areaDensity, acceleration, pressure); // kg/m² * m/s² => N/m²

            AddMul(density, distance, areaDensity); // kg/m³ * m => kh/m²
            // AddMul(areaDensity, area,         pressure);

            AddMul(force, distance, momentum); // N * m = Nm
            AddMul(linForce, area, momentum); // N/m * m² = Nm

            AddMul(temperature, linearExpansion, UnitDefinition.Scalar);

            UnitDefinition[] all =
            {
                distance,
                area,
                acceleration,
                density,
                areaDensity,

                // pressure,
                linForce,
                force,
                mass,
                momentum,
                temperature,
                linearExpansion,
                angle
            };

            var gen = new Generator(Path.Combine(basePath, "+algebra"), nameSpace);

            // gen.Generate(all);
        }

        private static readonly UnitDefinition distance
            = new UnitDefinition("Meter", "m", "odległość");

        private static readonly UnitDefinition area
            = new UnitDefinition("SquareMeter", "m²", "powierzchnię");

        private static readonly UnitDefinition acceleration =
            new UnitDefinition("Acceleration", "m/s²", "przyspieszenie");

        private static readonly UnitDefinition density
            = new UnitDefinition("Density", "kg/m³", "gęstość");

        private static readonly UnitDefinition areaDensity =
            new UnitDefinition("AreaDensity", "kg/m²", "gęstość powierzchniową");

        /*
        private static readonly UnitDefinition pressure
            = new UnitDefinition("Pressure", "N/m²", "ciśnienie");
            */

        private static readonly UnitDefinition linForce =
            new UnitDefinition("LinearForce", "N/m", "siłę na jedn. długości");

        private static readonly UnitDefinition force
            = new UnitDefinition("Force", "N", "siłę");

        private static readonly UnitDefinition mass
            = new UnitDefinition("Mass", "kg", "masę");

        private static readonly UnitDefinition temperature
            = new UnitDefinition("Temperature", "°C", "temperaturę");

        private static readonly UnitDefinition linearExpansion =
            new UnitDefinition("LinearExpansion", "1/°C", "rozszerzalność liniową");

        private static readonly UnitDefinition momentum
            = new UnitDefinition("Momentum", "Nm", "moment");

        private static readonly UnitDefinition angle
            = new UnitDefinition("Angle", "°", "stopnie kątowe");
    }
}