using System.Linq;
using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class UnitDecomposerTests
    {
        [Fact]
        public void T01_should_decompose_kg_per_meter()
        {
            var d = new LinearDensityUnit(MassUnits.Kg, LengthUnits.Meter);
            var q = d.Decompose();
            Assert.Equal(2, q.Count);
            Assert.Equal("kg", q[0].Unit.UnitName);
            Assert.Equal(1, q[0].Power);
            Assert.Equal("m", q[1].Unit.UnitName);
            Assert.Equal(-1, q[1].Power);
        }
        
        [Fact]
        public void T02_should_decompose_kg_per_square()
        {
            var d = new PlanarDensityUnit(MassUnits.Kg, AreaUnits.SquareMeter);
            var q = d.Decompose();
            Assert.Equal(2, q.Count);
            Assert.Equal("kg", q[0].Unit.UnitName);
            Assert.Equal(1, q[0].Power);
            Assert.Equal("m", q[1].Unit.UnitName);
            Assert.Equal(-2, q[1].Power);
        }
    }
}