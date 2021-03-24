using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class WeightTest
    {
        [Fact]
        public void T01_ShoulEqual()
        {
            var a = Mass.FromKg(123);
            var b = Mass.FromKg(123);
            var c = Mass.FromKg(121);
            Assert.Equal(a, a);
            Assert.Equal(a, b);
            Assert.NotEqual(a, c);
            Assert.Equal(Mass.Zero, Mass.FromKg(0));
        }

        [Fact]
        public void T02_ShoulSerializeToJson()
        {
            var a = Mass.FromKg(123);
            var s = JsonConvert.SerializeObject(-a);
            Assert.Equal("\"-123kg\"", s);
            s = JsonConvert.SerializeObject(a);
            Assert.Equal("\"123kg\"", s);

            var d = JsonConvert.DeserializeObject<Mass>(s);
            Assert.Equal(a, d);

            var possibilities = "123kg;123 kg; 123.00kg; 123.000 kg ;0.12300 tons; 123000g";

            foreach (var prefix in ";+;  ; + ".Split(';'))
            foreach (var i in possibilities.Split(';'))
            {
                var json = "\"" + prefix + i + "\"";
                d = JsonConvert.DeserializeObject<Mass>(json);
                var dd = d.ConvertToKg();
                Assert.Equal(a, dd);
            }

            foreach (var prefix in "-; - ".Split(';'))
            foreach (var i in possibilities.Split(';'))
            {
                var json = "\"" + prefix + i + "\"";
                d = JsonConvert.DeserializeObject<Mass>(json);
                var dd = d.ConvertToKg();
                Assert.Equal(-a, dd);
            }

            d = JsonConvert.DeserializeObject<Mass>("123");
            Assert.Equal(a, d);
            d = JsonConvert.DeserializeObject<Mass>("123.0");
            Assert.Equal(a, d);
        }

        [Fact]
        public void T03_ShoulSerializeComlexToJson()
        {
            var c = new Complex
            {
                Name = "A",
                W1   = Mass.FromKg(123),
                W2   = null
            };
            {
                var json     = JsonConvert.SerializeObject(c);
                var expected = @"{""Name"":""A"",""W1"":""123kg"",""W2"":null}";
                Assert.Equal(expected, json);
                var cc = JsonConvert.DeserializeObject<Complex>(json);
                Assert.Equal(c.W1, cc.W1);
                Assert.Null(cc.W2);
            }
            c.W2 = c.W1;
            {
                var json     = JsonConvert.SerializeObject(c);
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
            var a = Mass.FromKg(5);
            var b = Mass.FromKg(2);
            Assert.Equal(Mass.FromKg(7), a + b);
            Assert.Equal(Mass.FromKg(3), a - b);
            Assert.Equal(Mass.FromKg(10), a * 2);
            Assert.Equal(Mass.FromKg(10), 2 * a);
            Assert.Equal(Mass.FromKg(2.5m), a / 2);
            Assert.Equal(Mass.FromKg(-5), -a);
        }

        [Fact]
        public void T05_ShouldCalculateSums()
        {
            var a = Mass.FromKg(5);
            var b = Mass.FromKg(2);
            {
                IEnumerable<Mass> items = null;
                var                 sum   = items.Sum();
                Assert.Equal(Mass.Zero, sum);
                items = new Mass[0];
                sum   = items.Sum();
                Assert.Equal(Mass.Zero, sum);

                sum = new[] {a}.Sum();
                Assert.Equal(a, sum);

                sum = new[] {a, b}.Sum();
                Assert.Equal(Mass.FromKg(7), sum);
            }
            {
                IEnumerable<Mass?> items = null;
                var                  sum   = items.Sum();
                Assert.Equal(Mass.Zero, sum);

                items = new Mass?[0];
                sum   = items.Sum();
                Assert.Equal(Mass.Zero, sum);

                items = new[] {(Mass?)a};
                sum   = items.Sum();
                Assert.Equal(a, sum);

                items = new[] {(Mass?)a, Mass.Zero, null};
                sum   = items.Sum();
                Assert.Equal(a, sum);

                items = new[] {(Mass?)a, Mass.Zero, null, b};
                sum   = items.Sum();
                Assert.Equal(Mass.FromKg(7), sum);
            }
        }


        [Fact]
        public void T06_ShouldCompare()
        {
            Assert.True(Mass.FromKg(1001) > Mass.FromTons(1));
            Assert.True(Mass.FromKg(1000) == Mass.FromTons(1));
        }

        [Fact]
        public void T07_ShouldConvertToString()
        {
            var w   = Mass.FromKg(1234.56789);
            var txt = w.ToString("F3", CultureInfo.InvariantCulture);
            Assert.Equal("1234.568 kg", txt);

            FormattableString formattableString = $"{w:F1}";
            txt = formattableString.ToString(CultureInfo.InvariantCulture);
            Assert.Equal("1234.6 kg", txt);
        }


        [Fact]
        public void T08_ShouldAddToEmptyValue()
        {
            var nullValue = new Mass();
            var w         = Mass.FromKg(1234.56789);

            var sum = nullValue + w;
            Assert.Equal(w, sum);
            sum = w + nullValue;
            Assert.Equal(w, sum);
        }

        [Fact]
        public void T09_ShouldSubstractFromEmptyValue()
        {
            var nullValue  = new Mass();
            var w          = Mass.FromKg(1234.56789);
            var difference = nullValue - w;
            Assert.Equal(-w, difference);
            difference = w - nullValue;
            Assert.Equal(w, difference);
        }


        private class Complex
        {
            public string  Name { get; set; }
            public Mass  W1   { get; set; }
            public Mass? W2   { get; set; }
        }
    }
}