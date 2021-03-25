using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Xunit;
using iSukces.UnitedValues;


namespace iSukces.UnitedValues.Test
{
    public class AlgebraTests
    {
        [Fact]
        public void ShoulDivideMass()
        {
			var a = new Mass(10m, MassUnits.Kg);
			var b = new Mass(5m, MassUnits.Kg);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddWeight()
        {
			var a = new Mass(10m, MassUnits.Kg);
			var b = new Mass(5m, MassUnits.Kg);
            var expected = new Mass(15m, MassUnits.Kg);            
			var c = a + b;
			Assert.Equal(expected, c);
        }

        [Fact]
        public void ShoulSubstractWeight()
        {
			var a = new Mass(10m, MassUnits.Kg);
			var b = new Mass(6m, MassUnits.Kg);
            var expected = new Mass(4m, MassUnits.Kg);            
			var c = a - b;
			Assert.Equal(expected, c);
        }
        [Fact]
        public void ShoulDivideLength()
        {
			var a = new Length(10m, LengthUnits.Meter);
			var b = new Length(5m, LengthUnits.Meter);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddLength()
        {
			var a = new Length(10m, LengthUnits.Meter);
			var b = new Length(5m, LengthUnits.Meter);
            var expected = new Length(15m, LengthUnits.Meter);            
			var c = a + b;
			Assert.Equal(expected, c);
        }

        [Fact]
        public void ShoulSubstractLength()
        {
			var a = new Length(10m, LengthUnits.Meter);
			var b = new Length(6m, LengthUnits.Meter);
            var expected = new Length(4m, LengthUnits.Meter);            
			var c = a - b;
			Assert.Equal(expected, c);
        }
        [Fact]
        public void ShoulDivideArea()
        {
			var a = new Area(10m, AreaUnits.SquareMeter);
			var b = new Area(5m, AreaUnits.SquareMeter);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddArea()
        {
			var a = new Area(10m, AreaUnits.SquareMeter);
			var b = new Area(5m, AreaUnits.SquareMeter);
            var expected = new Area(15m, AreaUnits.SquareMeter);            
			var c = a + b;
			Assert.Equal(expected, c);
        }

        [Fact]
        public void ShoulSubstractArea()
        {
			var a = new Area(10m, AreaUnits.SquareMeter);
			var b = new Area(6m, AreaUnits.SquareMeter);
            var expected = new Area(4m, AreaUnits.SquareMeter);            
			var c = a - b;
			Assert.Equal(expected, c);
        }
        [Fact]
        public void ShoulDivideVolume()
        {
			var a = new Volume(10m, VolumeUnits.CubicMeter);
			var b = new Volume(5m, VolumeUnits.CubicMeter);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddVolume()
        {
			var a = new Volume(10m, VolumeUnits.CubicMeter);
			var b = new Volume(5m, VolumeUnits.CubicMeter);
            var expected = new Volume(15m, VolumeUnits.CubicMeter);            
			var c = a + b;
			Assert.Equal(expected, c);
        }

        [Fact]
        public void ShoulSubstractVolume()
        {
			var a = new Volume(10m, VolumeUnits.CubicMeter);
			var b = new Volume(6m, VolumeUnits.CubicMeter);
            var expected = new Volume(4m, VolumeUnits.CubicMeter);            
			var c = a - b;
			Assert.Equal(expected, c);
        }
        [Fact]
        public void ShoulDivideForce()
        {
			var a = new Force(10m, ForceUnits.Newton);
			var b = new Force(5m, ForceUnits.Newton);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddForce()
        {
			var a = new Force(10m, ForceUnits.Newton);
			var b = new Force(5m, ForceUnits.Newton);
            var expected = new Force(15m, ForceUnits.Newton);            
			var c = a + b;
			Assert.Equal(expected, c);
        }

        [Fact]
        public void ShoulSubstractForce()
        {
			var a = new Force(10m, ForceUnits.Newton);
			var b = new Force(6m, ForceUnits.Newton);
            var expected = new Force(4m, ForceUnits.Newton);            
			var c = a - b;
			Assert.Equal(expected, c);
        }
	}
}