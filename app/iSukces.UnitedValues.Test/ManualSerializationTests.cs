using Newtonsoft.Json;
using Xunit;

namespace iSukces.UnitedValues.Test;

public sealed class ManualSerializationTests
{
    [Fact]
    public void T01_Should_Serialize_Empty_Mass()
    {
        Mass mass = default;
        var  json = JsonConvert.SerializeObject(mass);
        Assert.Equal("\"0kg\"", json);
    } 
    [Fact]
    public void T02_Should_deserialize_Empty_Mass()
    {
        var  value = JsonConvert.DeserializeObject<Mass>("\"0\"");
        Assert.Equal(0, value.Value);
        Assert.Equal("kg", value.Unit.UnitName);
    }
}