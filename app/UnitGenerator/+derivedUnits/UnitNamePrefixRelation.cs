#nullable disable
namespace UnitGenerator;

public class UnitNamePrefixRelation
{
    public UnitNamePrefixRelation(string other, string my, string myUnitContainer, string otherUnitContainer)
    {
        Other              = other;
        My                 = my;
        MyUnitContainer    = myUnitContainer;
        OtherUnitContainer = otherUnitContainer;
    }

    public override string ToString()
    {
        return
            $"Other={Other}, My={My}, MyUnitContainer={MyUnitContainer}, OtherUnitContainer={OtherUnitContainer}";
    }

    public string Other { get; }

    public string My { get; }

    public string MyUnitContainer { get; }

    public string OtherUnitContainer { get; }
}
