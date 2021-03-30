using UnitGenerator.Local;

namespace UnitGenerator
{
    public partial class XUnitContainerTypeName: ITypeNameProvider
    {
        public string GetTypename()
        {
            return TypeName;
        }
    }
}