using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class RelatedUnitsTests
    {
        [Fact]
        public void T01_Should_find_length_unit_related_to_square_meter()
        {
            var        newUnit  = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(AreaUnits.SquareMeter);
            LengthUnit expected = LengthUnits.Meter;
            Assert.Equal(expected, newUnit);
        }

        [Fact]
        public void T02_Should_find_length_unit_related_to_cubic_meter()
        {
            var newUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, LengthUnit>(VolumeUnits.QubicMeter);
            LengthUnit expected = LengthUnits.Meter;
            Assert.Equal(expected, newUnit);
        }


        [Fact]
        public void T03_Should_not_find_length_unit_related_to_kilogram()
        {
            var excp = Assert.Throws<UnableToFindRelatedUnitException>(() =>
            {
                var newUnit = GlobalUnitRegistry.Relations.GetOrThrow<WeightUnit, LengthUnit>(WeightUnits.Kg);
                return newUnit;
            });
            Assert.Equal(typeof(WeightUnit), excp.SourceUnitType);
            Assert.Equal(typeof(LengthUnit), excp.RelatedUnitType);
            Assert.Equal(WeightUnits.Kg, (WeightUnit)excp.Unit);
            const string message = "Unable to find related LengthUnit for WeightUnit 'kg'.";
            Assert.Equal(message, excp.Message);
        }
    }
}