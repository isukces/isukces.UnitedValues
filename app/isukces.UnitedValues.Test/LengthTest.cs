using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;

namespace isukces.UnitedValues.Test
{
    public class LengthTest
    {
        [Fact]
        public void T01_ShoulEqual()
        {
            var a = Length.FromMeter(123);
            var b = Length.FromMeter(123);
            var c = Length.FromMeter(121);
            Assert.Equal(a, a);
            Assert.Equal(a, b);
            Assert.NotEqual(a, c);
            Assert.Equal(Length.Zero, Length.FromMeter(0));
        }

        [Fact]
        public void T02_ShoulSerializeToJson()
        {
            var a = Length.FromMeter(123);
            var s = JsonConvert.SerializeObject(-a);
            Assert.Equal("\"-123m\"", s);
            s = JsonConvert.SerializeObject(a);
            Assert.Equal("\"123m\"", s);

            var d = JsonConvert.DeserializeObject<Length>(s);
            Assert.Equal(a, d);

            var possibilities = "123m;123 m; 123.00m; 123.000 m ;0.12300 km; 123000mm";

            foreach (var prefix in ";+;  ; + ".Split(';'))
            {
                foreach (var i in possibilities.Split(';'))
                {
                    var json = "\"" + prefix + i + "\"";
                    d = JsonConvert.DeserializeObject<Length>(json);
                    var dd = d.ConvertToMeter();
                    Assert.Equal(a, dd);
                }
            }
            foreach (var prefix in "-; - ".Split(';'))
            {
                foreach (var i in possibilities.Split(';'))
                {
                    var json = "\"" + prefix + i + "\"";
                    d = JsonConvert.DeserializeObject<Length>(json);
                    var dd = d.ConvertToMeter();
                    Assert.Equal(-a, dd);
                }
            }

            d = JsonConvert.DeserializeObject<Length>("123");
            Assert.Equal(a, d);
            d = JsonConvert.DeserializeObject<Length>("123.0");
            Assert.Equal(a, d);
        }

        [Fact]
        public void T03_ShoulSerializeComlexToJson()
        {
            var c = new Complex
            {
                Name = "A",
                W1 = Length.FromMeter(123),
                W2 = null
            };
            {
                var json = JsonConvert.SerializeObject(c);
                var expected = @"{""Name"":""A"",""W1"":""123m"",""W2"":null}";
                Assert.Equal(expected, json);
                var cc = JsonConvert.DeserializeObject<Complex>(json);
                Assert.Equal(c.W1, cc.W1);
                Assert.Null(cc.W2);
            }
            c.W2 = c.W1;
            {
                var json = JsonConvert.SerializeObject(c);
                var expected = @"{""Name"":""A"",""W1"":""123m"",""W2"":""123m""}";
                Assert.Equal(expected, json);
                var cc = JsonConvert.DeserializeObject<Complex>(json);
                Assert.Equal(c.W1, cc.W1);
                Assert.NotNull(cc.W2);
                Assert.Equal(c.W1, cc.W2);
            }
        }


        [Fact]
        public void T04_ShouldSupportAlgebra()
        {
            var a = Length.FromMeter(5);
            var b = Length.FromMeter(2);
            Assert.Equal(Length.FromMeter(7), a + b);
            Assert.Equal(Length.FromMeter(3), a - b);
            Assert.Equal(Length.FromMeter(10), a * 2);
            Assert.Equal(Length.FromMeter(10), 2 * a);
            Assert.Equal(Length.FromMeter(2.5m), a / 2);
            Assert.Equal(Length.FromMeter(-5), -a);
        }

        [Fact]
        public void T05_ShouldCalculateSums()
        {
            var a = Length.FromMeter(5);
            var b = Length.FromMeter(2);
            {
                IEnumerable<Length> items = null;
                var sum = items.Sum();
                Assert.Equal(Length.Zero, sum);
                items = new Length[0];
                sum = items.Sum();
                Assert.Equal(Length.Zero, sum);

                sum = new[] { a }.Sum();
                Assert.Equal(a, sum);

                sum = new[] { a, b }.Sum();
                Assert.Equal(Length.FromMeter(7), sum);
            }
            {
                IEnumerable<Length?> items = null;
                var sum = items.Sum();
                Assert.Equal(Length.Zero, sum);

                items = new Length?[0];
                sum = items.Sum();
                Assert.Equal(Length.Zero, sum);

                items = new[] { (Length?)a };
                sum = items.Sum();
                Assert.Equal(a, sum);

                items = new[] { (Length?)a, Length.Zero, null };
                sum = items.Sum();
                Assert.Equal(a, sum);

                items = new[] { (Length?)a, Length.Zero, null, b };
                sum = items.Sum();
                Assert.Equal(Length.FromMeter(7), sum);
            }
        }


        [Fact]
        public void T06_ShouldCompare()
        {
            Assert.True(Length.FromMeter(1001) > Length.FromKm(1));
            Assert.True(Length.FromMeter(1000) == Length.FromKm(1));
        }

        [Fact]
        public void T07_ShouldConvert()
        {
            var a = new Length(10, LengthUnits.Yard);
            var b = a.ConvertTo(LengthUnits.Inch);
            Assert.Equal(360, b.Value);
        }

        [Fact]
        public void T08_ShouldCalculateAreaAndVolume()
        {
            var a = new Length(10, LengthUnits.Yard);
            var b = a * a;
            Assert.Equal(100, b.Value);
            Assert.Equal(AreaUnits.SquareYard, b.Unit);
            var bMeters = b.ConvertTo(AreaUnits.SquareMeter);
            Assert.Equal(100 * (36 * 0.0254m) * (36 * 0.0254m), bMeters.Value);

            var vol = a * b;
            Assert.Equal(1000, vol.Value);
            Assert.Equal(VolumeUnits.QubicYard, vol.Unit);

        }

        private class Complex
        {
            public string Name { get; set; }
            public Length W1 { get; set; }
            public Length? W2 { get; set; }
        }
    }
}