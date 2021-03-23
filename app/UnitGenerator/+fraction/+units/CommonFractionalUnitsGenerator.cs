using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    /// <summary>
    ///     Creates units like m/s²
    /// </summary>
    internal class CommonFractionalUnitsGenerator : MultipleFilesGenerator
    {
        // CommonFractionalUnits
        public CommonFractionalUnitsGenerator(string nameSpace) : base(nameSpace)
        {
        }


        public void Generate(CommonFractionalUnitsCollection getAll)
        {
            foreach (var q in getAll.Items)
            {
                var cl = GetClass(q.Type.Container);
                cl.AddComment(q.ToString());

                FractionUnitInfo fuDefinition = null;

                var description = string.Format("represents {0} unit '{1}'",
                    q.Type.Value.FirstLower(), q.GetUnitName(ref fuDefinition));
                var p1          = fuDefinition.CounterUnit.Container + "." + q.CounterUnit;
                var p2          = fuDefinition.DenominatorUnit.Container + "." + q.DenominatorUnit;

                var x = new Args(p1, p2).Create(q.Type.Unit);
                var f = cl.AddField(q.TargetPropertyName, q.Type.Unit)
                    .WithStatic()
                    .WithIsReadOnly()
                    .WithConstValue(x);

                f.Description = description;
            }
        }
    }
}