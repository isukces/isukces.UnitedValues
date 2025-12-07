#nullable enable

using System.Linq;
using UnitGenerator;
using Xunit;

namespace iSukces.UnitedValues.Test;

public sealed class NullableTests
{

    [Fact]
    public void T01_Should_identify_nullable()
    {
        var constructor = typeof(TestClass).GetConstructors().Single();
        var array       = NullableFinder.FindArguments(constructor);
        Assert.Equal(6, array.Length);
        Assert.Equal(NullableType.ValueType, array[0]);
        Assert.Equal(NullableType.Nullable, array[1]);
        Assert.Equal(NullableType.ReferenceNotNull, array[2]);
        Assert.Equal(NullableType.ReferenceNullable, array[3]);
        Assert.Equal(NullableType.ReferenceNotNull, array[4]);
        Assert.Equal(NullableType.ReferenceNullable, array[5]);
    }

    [Fact]
    public void T02_Should()
    {
        var constructor = typeof(TestClassRef).GetConstructors().Single();
        var array       = NullableFinder.FindArguments(constructor);
        Assert.Equal(6, array.Length);
        Assert.Equal(NullableType.ReferenceNotNull, array[0]);
        Assert.Equal(NullableType.ReferenceNullable, array[1]);
        Assert.Equal(NullableType.ReferenceNotNull, array[2]);
        Assert.Equal(NullableType.ReferenceNullable, array[3]);
        Assert.Equal(NullableType.ReferenceNotNull, array[4]);
        Assert.Equal(NullableType.ReferenceNullable, array[5]);
    }


    public class TestClassRef
    {
        public TestClassRef(
            ref int  number,
            ref int? nullableNumber,
            ref string name, 
            ref string? nullableName,
            ref INono nono,
            ref INono? nullableNono)
        {
            
        }
    }
    public class TestClass
    {
        public TestClass(
            int  number,
            int? nullableNumber,
            string name, 
            string? nullableName,
            INono nono,
            INono? nullableNono)
        {
            
        }
    }

    public interface INono
    {
        
    }
}
