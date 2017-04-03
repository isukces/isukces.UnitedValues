using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;

namespace isukces.UnitedValues.Test
{
    public class WeightTest
    {
        [Fact]
        public void T01_ShoulEqual()
        {
            var a = Weight.FromKg(123);
            var b = Weight.FromKg(123);
            var c = Weight.FromKg(121);
            Assert.Equal(a, a);
            Assert.Equal(a, b);
            Assert.NotEqual(a, c);
            Assert.Equal(Weight.Zero, Weight.FromKg(0));
        }

        [Fact]
        public void T02_ShoulSerializeToJson()
        {
            var a = Weight.FromKg(123);
            var s = JsonConvert.SerializeObject(-a);
            Assert.Equal("\"-123kg\"", s);
            s = JsonConvert.SerializeObject(a);
            Assert.Equal("\"123kg\"", s);

            var d = JsonConvert.DeserializeObject<Weight>(s);
            Assert.Equal(a, d);

            var possibilities = "123kg;123 kg; 123.00kg; 123.000 kg ;0.12300 ton; 123000g";

            foreach (var prefix in ";+;  ; + ".Split(';'))
            {
                foreach (var i in possibilities.Split(';'))
                {
                    var json = "\"" + prefix + i + "\"";
                    d = JsonConvert.DeserializeObject<Weight>(json);
                    var dd = d.ConvertToKg();
                    Assert.Equal(a, dd);
                }
            }
            foreach (var prefix in "-; - ".Split(';'))
            {
                foreach (var i in possibilities.Split(';'))
                {
                    var json = "\"" + prefix + i + "\"";
                    d = JsonConvert.DeserializeObject<Weight>(json);
                    var dd = d.ConvertToKg();
                    Assert.Equal(-a, dd);
                }
            }

            d = JsonConvert.DeserializeObject<Weight>("123");
            Assert.Equal(a, d);
            d = JsonConvert.DeserializeObject<Weight>("123.0");
            Assert.Equal(a, d);
        }

        [Fact]
        public void T03_ShoulSerializeComlexToJson()
        {
            var c = new Complex
            {
                Name = "A",
                W1 = Weight.FromKg(123),
                W2 = null
            };
            {
                var json = JsonConvert.SerializeObject(c);
                var expected = @"{""Name"":""A"",""W1"":""123kg"",""W2"":null}";
                Assert.Equal(expected, json);
                var cc = JsonConvert.DeserializeObject<Complex>(json);
                Assert.Equal(c.W1, cc.W1);
                Assert.Null(cc.W2);
            }
            c.W2 = c.W1;
            {
                var json = JsonConvert.SerializeObject(c);
                var expected = @"{""Name"":""A"",""W1"":""123kg"",""W2"":""123kg""}";
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
            var a = Weight.FromKg(5);
            var b = Weight.FromKg(2);
            Assert.Equal(Weight.FromKg(7), a + b);
            Assert.Equal(Weight.FromKg(3), a - b);
            Assert.Equal(Weight.FromKg(10), a * 2);
            Assert.Equal(Weight.FromKg(10), 2 * a);
            Assert.Equal(Weight.FromKg(2.5m), a / 2);
            Assert.Equal(Weight.FromKg(-5), -a);
        }

        [Fact]
        public void T05_ShouldCalculateSums()
        {
            var a = Weight.FromKg(5);
            var b = Weight.FromKg(2);
            {
                IEnumerable<Weight> items = null;
                var sum = items.Sum();
                Assert.Equal(Weight.Zero, sum);
                items = new Weight[0];
                sum = items.Sum();
                Assert.Equal(Weight.Zero, sum);

                sum = new[] {a}.Sum();
                Assert.Equal(a, sum);

                sum = new[] {a, b}.Sum();
                Assert.Equal(Weight.FromKg(7), sum);
            }
            {
                IEnumerable<Weight?> items = null;
                var sum = items.Sum();
                Assert.Equal(Weight.Zero, sum);

                items = new Weight?[0];
                sum = items.Sum();
                Assert.Equal(Weight.Zero, sum);

                items = new[] {(Weight?)a};
                sum = items.Sum();
                Assert.Equal(a, sum);

                items = new[] {(Weight?)a, Weight.Zero, null};
                sum = items.Sum();
                Assert.Equal(a, sum);

                items = new[] {(Weight?)a, Weight.Zero, null, b};
                sum = items.Sum();
                Assert.Equal(Weight.FromKg(7), sum);
            }
        }


        [Fact]
        public void T06_ShouldCompare()
        {
            Assert.True(Weight.FromKg(1001) > Weight.FromTons(1));
            Assert.True(Weight.FromKg(1000) == Weight.FromTons(1));
        }


     


        private class Complex
        {
            public string Name { get; set; }
            public Weight W1 { get; set; }
            public Weight? W2 { get; set; }
        }
    }
}