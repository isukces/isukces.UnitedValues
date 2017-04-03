using System;
using System.Activities.Expressions;
using Newtonsoft.Json;
using Xunit;

namespace isukces.UnitedValues.Test
{
  
    public class DensityTests
    {
        [Fact]
        public void T01_ShouldEqual()
        {
            {
                var density = new Density(8000, WeightUnits.Kg, VolumeUnits.QubicMeter);
                Assert.Equal(density, new Density(8000, WeightUnits.Kg, VolumeUnits.QubicMeter));
                Assert.NotEqual(density, new Density(8001, WeightUnits.Kg, VolumeUnits.QubicMeter));
                Assert.NotEqual(density, new Density(8000, WeightUnits.Kg, VolumeUnits.QubicMm));
                Assert.NotEqual(density, new Density(8000, WeightUnits.Gram, VolumeUnits.QubicMeter));
            }
            {
                var density = new PlanarDensity(8000, WeightUnits.Kg, AreaUnits.SquareMeter);
                Assert.Equal(density, new PlanarDensity(8000, WeightUnits.Kg, AreaUnits.SquareMeter));
                Assert.NotEqual(density, new PlanarDensity(8001, WeightUnits.Kg, AreaUnits.SquareMeter));
                Assert.NotEqual(density, new PlanarDensity(8000, WeightUnits.Kg, AreaUnits.SquareMm));
                Assert.NotEqual(density, new PlanarDensity(8000, WeightUnits.Gram, AreaUnits.SquareMeter));
            }
            {
                var density = new LinearDensity(8000, WeightUnits.Kg, LengthUnits.Meter);
                Assert.Equal(density, new LinearDensity(8000, WeightUnits.Kg, LengthUnits.Meter));
                Assert.NotEqual(density, new LinearDensity(8001, WeightUnits.Kg, LengthUnits.Meter));
                Assert.NotEqual(density, new LinearDensity(8000, WeightUnits.Kg, LengthUnits.Mm));
                Assert.NotEqual(density, new LinearDensity(8000, WeightUnits.Gram, LengthUnits.Meter));
            }


        }

        [Fact]
        public void T02_ShouldComputeDensity()
        {
            var w = Weight.FromKg(8000);
            var volume = new Volume(1, VolumeUnits.QubicMeter);
            var density = w / volume;
            Assert.Equal(8000m, density.Value);
            Assert.Equal("kg/m³", density.Unit.UnitName);
            Assert.Equal("8000kg/m³", density.ToString());

            var d2 = density.ConvertTo(new DensityUnit(WeightUnits.Kg, VolumeUnits.QubicDm));
            Assert.Equal(8m, d2.Value);
            Assert.Equal("kg/dm³", d2.Unit.UnitName);
            Assert.Equal("8kg/dm³", d2.ToString());
        }

        [Fact]
        public void T03_ShouldConvertDensityAndPlanarDensity()
        {
            var density = new Density(8000, WeightUnits.Kg, VolumeUnits.QubicMeter);
            Assert.Equal("8000kg/m³", density.ToString());

            var length = new Length(2, LengthUnits.Meter);

            var planarDensity = density * length;
            Assert.Equal("16000kg/m²", planarDensity.ToString());

            planarDensity = length * density;
            Assert.Equal("16000kg/m²", planarDensity.ToString());

            var area = new Area(3, AreaUnits.SquareMeter);

            var linearDensity = density * area;
            Assert.Equal("24000kg/m", linearDensity.ToString());
            linearDensity = area * density;
            Assert.Equal("24000kg/m", linearDensity.ToString());

            area = area.ConvertTo(AreaUnits.SquareCm);
            linearDensity = density * area;
            linearDensity = new LinearDensity(Math.Round(linearDensity.Value), linearDensity.Unit);
            Assert.Equal("24000kg/m", linearDensity.ToString());
            linearDensity = area * density;
            linearDensity = new LinearDensity(Math.Round(linearDensity.Value), linearDensity.Unit);
            Assert.Equal("240kg/cm", linearDensity.ToString());

            linearDensity = linearDensity.ConvertTo(new LinearDensityUnit(WeightUnits.Kg, LengthUnits.Meter));
            Assert.Equal("24000kg/m", linearDensity.ToString());
        }


        [Fact]
        public void T04_ShouldConvertToJson()
        {
            var density = new Density(8000, WeightUnits.Kg, VolumeUnits.QubicMeter);
            var json = JsonConvert.SerializeObject(density);
            Assert.Equal("", json);
        }

    }
}