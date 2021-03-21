using System.IO;
using System.Linq;
using iSukces.Code;
using iSukces.UnitedValues;

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
                var unitGenerator = new UnitGenerator(Path.Combine(path1, "+IUnits"), nameSpace);
                unitGenerator.Generate(infos.Select(a => a.Unit).Distinct());

                var unitedValues = new UnitedValuesGenerator(Path.Combine(path1, "+IUnitedValue"), nameSpace);
                unitedValues.Generate(infos);

                var jsonConverter = new UnitJsonConverterGenerator(Path.Combine(path1, "+jsonConverters"), nameSpace);
                jsonConverter.Generate(infos);

                var ext = new UnitExtensionsGenerator(Path.Combine(path1, "+extensions"), nameSpace);
                ext.Generate(infos);
            }
            {
                // public LinearDensityUnit(WeightUnit counterUnit, LengthUnit denominatorUnit)
                var q = new[]
                {
                    new FractionUnitInfo("LinearDensity", "LinearDensityUnit", "WeightUnit", "LengthUnit"),
                    new FractionUnitInfo("Density", "DensityUnit", "WeightUnit", "VolumeUnit"),
                    new FractionUnitInfo("PlanarDensity", "PlaneDensityUnit", "WeightUnit", "AreaUnit")
                };
                var gen1 = new FractionUnitGenerator(Path.Combine(path1, "+fractionUnits"), nameSpace);
                gen1.Generate(q);

                var jsonConverter = new UnitJsonConverterGenerator(Path.Combine(path1, "+jsonConverters"), nameSpace);
                jsonConverter.ClassicImpl = true;
                jsonConverter.Generate(q);
            }
            {
                var arr = new[]
                {
                    new DerivedUnitInfo(nameof(Weight))
                        .WithUnit("kg", null, 1)
                        .WithUnit("t", "Tone", 1000, "ton")
                        .WithUnit("g", "Gram", 0.001m),
                    new DerivedUnitInfo(nameof(Length)).WithLengths(1),
                    new DerivedUnitInfo(nameof(Area)).WithLengths(2),
                    new DerivedUnitInfo(nameof(Volume)).WithLengths(3)
                };
                var ano = new AnotherGenerator(Path.Combine(path1, "+units4"), nameSpace);
                ano.Generate(arr);
            }
        }
    }

    public class UnitDefinition2
    {
        public UnitDefinition2(string unitShortName, string multiplicator, string nameSingular, string namePlural,
            string propertyName)
        {
            if (string.IsNullOrEmpty(namePlural) && !string.IsNullOrEmpty(nameSingular))
                namePlural = nameSingular + "s";
            UnitShortName = unitShortName;
            Multiplicator = multiplicator;
            NameSingular  = nameSingular;
            NamePlural    = namePlural;

            if (string.IsNullOrEmpty(propertyName))
                propertyName = UnitShortName;
            PropertyName = propertyName.FirstUpper();
        }

        public override string ToString()
        {
            return
                $"UnitShortName={UnitShortName}, Multiplicator={Multiplicator}, NameSingular={NameSingular}, NamePlural={NamePlural}";
        }

        public string UnitShortName { get; }

        public string Multiplicator { get; }

        public string NameSingular { get; }

        public string NamePlural   { get; }
        public string PropertyName { get; }
    }
}