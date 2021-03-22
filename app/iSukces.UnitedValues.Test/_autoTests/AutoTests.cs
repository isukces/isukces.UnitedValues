﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Xunit;
using iSukces.UnitedValues;


namespace isukces.UnitedValues.Test
{
    public class AlgebraTests
    {
        [Fact]
        public void ShoulDivideWeight()
        {
			var a = new Weight(10m, WeightUnits.Kg);
			var b = new Weight(5m, WeightUnits.Kg);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddWeight()
        {
			var a = new Weight(10m, WeightUnits.Kg);
			var b = new Weight(5m, WeightUnits.Kg);
            var expected = new Weight(15m, WeightUnits.Kg);            
			var c = a + b;
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
        public void ShoulDivideVolume()
        {
			var a = new Volume(10m, VolumeUnits.QubicMeter);
			var b = new Volume(5m, VolumeUnits.QubicMeter);
			var c = a / b;
			Assert.Equal(2, c);
        }


        [Fact]
        public void ShoulAddVolume()
        {
			var a = new Volume(10m, VolumeUnits.QubicMeter);
			var b = new Volume(5m, VolumeUnits.QubicMeter);
            var expected = new Volume(15m, VolumeUnits.QubicMeter);            
			var c = a + b;
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
	}
}