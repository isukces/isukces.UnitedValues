using System.IO;
using System.Linq;

namespace UnitGenerator
{
    internal class Program
    {
        private static DirectoryInfo FindProjectRootDirectory()
        {
            var projectRoot = new FileInfo(typeof(Program).Assembly.Location).Directory;
            while (true)
            {
                var ff = Path.Combine(projectRoot.FullName, ".gitignore ");
                if (File.Exists(ff))
                    break;
                projectRoot = projectRoot.Parent;
            }

            return projectRoot;
        }

        private static void Main(string[] args)
        {
            var distance     = new UnitDefinition("Meter", "m", "odległość");
            var area         = new UnitDefinition("SquareMeter", "m²", "powierzchnię");
            var acceleration = new UnitDefinition("Acceleration", "m/s²", "przyspieszenie");
            var density      = new UnitDefinition("Density", "kg/m³", "gęstość");
            var areaDensity  = new UnitDefinition("AreaDensity", "kg/m²", "gęstość powierzchniową");

            var pressure        = new UnitDefinition("Pressure", "N/m²", "ciśnienie");
            var linForce        = new UnitDefinition("LinearForce", "N/m", "siłę na jedn. długości");
            var force           = new UnitDefinition("Force", "N", "siłę");
            var mass            = new UnitDefinition("Mass", "kg", "masę");
            var temperature     = new UnitDefinition("Temperature", "°C", "temperaturę");
            var linearExpansion = new UnitDefinition("LinearExpansion", "1/°C", "rozszerzalność liniową");

            var momentum = new UnitDefinition("Momentum", "Nm", "moment");
            var angle    = new UnitDefinition("Angle", "°", "stopnie kątowe");

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
            AddDiv(linForce, distance, pressure); // N/m  / m  => N/m²
            AddDiv(force, area, pressure); // N / m² => N/m²
            AddMul(mass, acceleration, force); // kg * m/s² => N
            AddMul(areaDensity, acceleration, pressure); // kg/m² * m/s² => N/m²

            AddMul(density, distance, areaDensity); // kg/m³ * m => kh/m²
            // AddMul(areaDensity, area,         pressure);

            AddMul(force, distance, momentum); // N * m = Nm
            AddMul(linForce, area, momentum); // N/m * m² = Nm

            AddMul(temperature, linearExpansion, UnitDefinition.Scalar);

            var all = new[]
            {
                distance,
                area,
                acceleration,
                density,
                areaDensity,

                pressure,
                linForce,
                force,
                mass,
                momentum,
                temperature,
                linearExpansion,
                angle
            };
            var projectRoot = FindProjectRootDirectory();
            var path1       = Path.Combine(projectRoot.FullName, "app", "iSukces.UnitedValues");
            var nameSpace   = "iSukces.UnitedValues";
            var gen         = new Generator(Path.Combine(path1, "+units"), nameSpace);

            // gen.Generate(all);
            {
                var data = @"
Force,ForceUnit,+,ForceUnit.Newton
Weight,WeightUnit,+,WeightUnits.Kg
Length,LengthUnit,+,LengthUnits.Meter
Area,AreaUnit,-,AreaUnits.SquareMeter
Volume,VolumeUnit,-,VolumeUnits.QubicMeter
";
                var infos = data.Split('\n', '\r')
                    .Select(UnitInfo.Parse).Where(a => a != null)
                    .ToArray();
                var gen2 = new UnitGenerator(Path.Combine(path1, "+IUnits"), nameSpace);
                gen2.Generate(infos.Select(a => a.Unit).Distinct());

                // var infos2 = infos.Take(1).ToArray();

                var gen3 = new UnitedValuesGenerator(Path.Combine(path1, "+IUnitedValue"), nameSpace);
                gen3.Generate(infos);

                var gen4 = new UnitJsonConverterGenerator(Path.Combine(path1, "+jsonConverters"), nameSpace);
                gen4.Generate(infos);

                var gen5 = new UnitExtensionsGenerator(Path.Combine(path1, "+extensions"), nameSpace);
                gen5.Generate(infos);
            }
        }
    }
}