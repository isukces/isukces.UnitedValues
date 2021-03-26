using System;
using Newtonsoft.Json;
using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class DensityTests
    {
        [Fact]
        public void T01_ShouldEqual()
        {
            {
                var density = new Density(8000, MassUnits.Kg, VolumeUnits.CubicMeter);
                Assert.Equal(density, new Density(8000, MassUnits.Kg, VolumeUnits.CubicMeter));
                Assert.NotEqual(density, new Density(8001, MassUnits.Kg, VolumeUnits.CubicMeter));
                Assert.NotEqual(density, new Density(8000, MassUnits.Kg, VolumeUnits.CubicMm));
                Assert.NotEqual(density, new Density(8000, MassUnits.Gram, VolumeUnits.CubicMeter));
            }
            {
                var density = new PlanarDensity(8000, MassUnits.Kg, AreaUnits.SquareMeter);
                Assert.Equal(density, new PlanarDensity(8000, MassUnits.Kg, AreaUnits.SquareMeter));
                Assert.NotEqual(density, new PlanarDensity(8001, MassUnits.Kg, AreaUnits.SquareMeter));
                Assert.NotEqual(density, new PlanarDensity(8000, MassUnits.Kg, AreaUnits.SquareMm));
                Assert.NotEqual(density, new PlanarDensity(8000, MassUnits.Gram, AreaUnits.SquareMeter));
            }
            {
                var density = new LinearDensity(8000, MassUnits.Kg, LengthUnits.Meter);
                Assert.Equal(density, new LinearDensity(8000, MassUnits.Kg, LengthUnits.Meter));
                Assert.NotEqual(density, new LinearDensity(8001, MassUnits.Kg, LengthUnits.Meter));
                Assert.NotEqual(density, new LinearDensity(8000, MassUnits.Kg, LengthUnits.Mm));
                Assert.NotEqual(density, new LinearDensity(8000, MassUnits.Gram, LengthUnits.Meter));
            }
        }

        [Fact]
        public void T02_ShouldComputeDensity()
        {
            var w       = Mass.FromKg(8000);
            var volume  = new Volume(1, VolumeUnits.CubicMeter);
            var density = w / volume;
            Assert.Equal(8000m, density.Value);
            Assert.Equal("kg/m³", density.Unit.UnitName);
            Assert.Equal("8000kg/m³", density.ToString());

            var d2 = density.ConvertTo(new DensityUnit(MassUnits.Kg, VolumeUnits.CubicDm));
            Assert.Equal(8m, d2.Value);
            Assert.Equal("kg/dm³", d2.Unit.UnitName);
            Assert.Equal("8kg/dm³", d2.ToString());

            var area       = new Area(10 * 100, AreaUnits.SquareDm);
            var pd         = w / area;
            var pdExpected = PlanarDensity.Parse("8kg/dm2");
            Assert.Equal(8m, pd.Value);
            Assert.Equal(pdExpected.Unit, pd.Unit);

            pdExpected = PlanarDensity.Parse("800kg/m2");
            pd         = pd.ConvertTo(new PlanarDensityUnit(w.Unit, AreaUnits.SquareMeter));
            Assert.Equal(800m, pd.Value);
            Assert.Equal(pdExpected.Unit, pd.Unit);

            Assert.Equal(10, area.ConvertToMeter().Value);
        }

        [Fact]
        public void T03_ShouldConvertDensityAndPlanarDensity()
        {
            var density = new Density(8000, MassUnits.Kg, VolumeUnits.CubicMeter);
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

            area          = area.ConvertTo(AreaUnits.SquareCm);
            linearDensity = density * area;
            linearDensity = new LinearDensity(Math.Round(linearDensity.Value), linearDensity.Unit);
            Assert.Equal("24000kg/m", linearDensity.ToString());
            linearDensity = area * density;
            linearDensity = new LinearDensity(Math.Round(linearDensity.Value), linearDensity.Unit);
            Assert.Equal("240kg/cm", linearDensity.ToString());

            linearDensity = linearDensity.ConvertTo(new LinearDensityUnit(MassUnits.Kg, LengthUnits.Meter));
            Assert.Equal("24000kg/m", linearDensity.ToString());
        }

        [Fact]
        public void T04_ShouldConvertDensityAndLinearDensity()
        {
            var density = new Density(8000, MassUnits.Kg, VolumeUnits.CubicMeter);
            Assert.Equal("8000kg/m³", density.ToString());
            var area = Length.FromMilimeters(50) * Length.FromMilimeters(5);
            Assert.Equal("250mm²", area.ToString());

            var linearDensity = density * area;
            Assert.Equal(2m, linearDensity.Value);
            Assert.Equal("kg/m", linearDensity.Unit.ToString());

            linearDensity = area * density;
            Assert.Equal(0.002m, linearDensity.Value);
            Assert.Equal("kg/mm", linearDensity.Unit.ToString());
        }

        [Fact]
        public void T05_ShouldSerializeToJson()
        {
            var density = new Density(8000, MassUnits.Kg, VolumeUnits.CubicMeter);
            var json    = JsonConvert.SerializeObject(density);
            Assert.Equal("\"8000kg/m³\"", json);
            var planarDensity = new PlanarDensity(8000, MassUnits.Kg, AreaUnits.SquareMeter);
            json = JsonConvert.SerializeObject(planarDensity);
            Assert.Equal("\"8000kg/m²\"", json);
            var linearDensity = new LinearDensity(8000, MassUnits.Kg, LengthUnits.Meter);
            json = JsonConvert.SerializeObject(linearDensity);
            Assert.Equal("\"8000kg/m\"", json);
        }

        [Fact]
        public void T06_ShouldDeserializeFromJson()
        {
            var testValues = "8000kg/m³,8000 kg / m³, 8000  kg / m3";
            foreach (var xx in testValues.Split(','))
            {
                var tmp = JsonConvert.DeserializeObject<Density>("\"" + xx + "\"");
                Assert.Equal(8000, tmp.Value);
                Assert.Equal(MassUnits.Kg, tmp.Unit.CounterUnit);
                Assert.Equal(VolumeUnits.CubicMeter, tmp.Unit.DenominatorUnit);
            }

            testValues = "8000kg/m²,8000 kg / m², 8000  kg / m2";
            foreach (var xx in testValues.Split(','))
            {
                var tmp = JsonConvert.DeserializeObject<PlanarDensity>("\"" + xx + "\"");
                Assert.Equal(8000, tmp.Value);
                Assert.Equal(MassUnits.Kg, tmp.Unit.CounterUnit);
                Assert.Equal(AreaUnits.SquareMeter, tmp.Unit.DenominatorUnit);
            }

            testValues = "8000kg/m,8000 kg / m, 8000  kg / m";
            foreach (var xx in testValues.Split(','))
            {
                var tmp = JsonConvert.DeserializeObject<LinearDensity>("\"" + xx + "\"");
                Assert.Equal(8000, tmp.Value);
                Assert.Equal(MassUnits.Kg, tmp.Unit.CounterUnit);
                Assert.Equal(LengthUnits.Meter, tmp.Unit.DenominatorUnit);
            }
        }

        [Fact]
        public void T07_Should_multiply_density_with_volume()
        {
            var den = Density.Parse("10kg/m3");
            var vol = Volume.Parse("30cm3");
            var mul = den * vol;
            Assert.Equal(0.0003m, mul.Value);
            Assert.Equal("kg", mul.Unit.UnitName);
        }

        [Fact]
        public void T08a_should_mul_PlanarDensity_and_Length()
        {
            var planarDensity = new PlanarDensity(12, MassUnits.Kg, AreaUnits.SquareMeter);
            var length        = new Length(50, LengthUnits.Cm);
            var mul           = planarDensity * length;
            Assert.Equal(6, mul.Value);
            Assert.Equal("kg/m", mul.Unit.UnitName);
        }

        [Fact]
        public void T08b_should_mul_Length_and_PlanarDensity()
        {
            var planarDensity = new PlanarDensity(12, MassUnits.Kg, AreaUnits.SquareMeter);
            var length        = new Length(50, LengthUnits.Cm);
            var mul           = length * planarDensity;
            Assert.Equal(0.06m, mul.Value);
            Assert.Equal("kg/cm", mul.Unit.UnitName);

            mul = mul.ConvertTo(new LinearDensityUnit(MassUnits.Kg, LengthUnits.Meter));
            Assert.Equal(6, mul.Value);
            Assert.Equal("kg/m", mul.Unit.UnitName);
        }
        
        
        
        [Fact]
        public void T09_should_mul()
        {
            /*
             * 52480mm³
7850kg/m³

6685350318.4713375796178343949kg
             */

            var v = new Volume(52480, VolumeUnits.CubicMm);
            var d = new Density(7850, new DensityUnit(MassUnits.Kg, VolumeUnits.CubicMeter));

            var bb = v * d;
            bb = bb.ConvertToKg();
            Assert.Equal(0.411968m, bb.Value);
            Assert.Equal("kg", bb.Unit.UnitName);
        }
    }
}