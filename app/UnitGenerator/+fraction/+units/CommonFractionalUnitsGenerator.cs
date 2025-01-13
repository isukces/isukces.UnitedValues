using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator;

/// <summary>
///     Creates units like m/s²
/// </summary>
internal class CommonFractionalUnitsGenerator : MultipleFilesGenerator
{
    // CommonFractionalUnits
    public CommonFractionalUnitsGenerator(string nameSpace) : base(nameSpace)
    {
    }


    public void Generate(CommonFractionalUnitsCollection collection)
    {
        foreach (var item in collection.Items)
        {
            var cl = GetClass(item.Type.Container.GetTypename());
            cl.AddComment(item.ToString());

            FractionUnit? fuDefinition = null;

            var description = string.Format("represents {0} unit '{1}'",
                item.Type.Value.FirstLower(), item.GetUnitName(ref fuDefinition));
            var p1 = fuDefinition.CounterUnit.Container + "." + item.CounterUnit;
            var p2 = fuDefinition.DenominatorUnit.Container + "." + item.DenominatorUnit;

            var x = new CsArguments(p1, p2).Create(item.Type.Unit);
            var f = cl.AddField(item.TargetPropertyName, (CsType)item.Type.Unit.GetTypename())
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue(x);

            f.Description = description;
        }
    }
}
