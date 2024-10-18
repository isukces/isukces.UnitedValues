using iSukces.Code;
using UnitGenerator.Local;

namespace UnitGenerator;

public partial class XUnitTypeName : ITypeNameProvider
{
    public string GetTypename()
    {
        return TypeName;
    }

    public XUnitContainerTypeName ToUnitContainerTypeName()
    {
        return new XUnitContainerTypeName(TypeName + "s");
    }
}