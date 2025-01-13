using Xunit;

namespace iSukces.UnitedValues.Test;

public class UMathTests
{
    [Fact]
    public void T01_Should_sqr()
    {
        var length = Length.FromInches(3);
        var area   = length.Sqr();
        Assert.Equal(9, area.Value);
        Assert.Equal(AreaUnits.SquareInch, area.Unit);
    }

    [Fact]
    public void T02_Should_sqrt()
    {
        var area   = Area.FromSquareInches(9);
        var length = area.Sqrt();
        Assert.Equal(3, length.Value);
        Assert.Equal(LengthUnits.Inch, length.Unit);
    }
}
