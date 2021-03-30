using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class WeightUnitTests
    {
        [Fact]
        public void T01_Should_trim_parsed_unit()
        {
            var w  = new MassUnit("kg");
            var w2 = new MassUnit(" kg ");
            Assert.Equal(w, w2);
        }


        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void T02_Should_not_create_null_unit()
        {
            Assert.Throws<NullReferenceException>(() => new MassUnit(null));
        }

        [Fact]
        public void T03_Should_not_create_spaces_only_unit()
        {
            Assert.Throws<ArgumentException>(() => new MassUnit(" "));
        }
    }
}