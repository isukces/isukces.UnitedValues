using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class Def_Energy_Time_Power
    {
        public static void Setup(MultiplicationAlgebra c)
        {
            var hints2 = new OperatorHints();
            hints2.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<Energy, Time, Power>(hints2);
        }

        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs args)
        {
            args.Handled = true;
            var input  = args.Input;
            var result = args.Result;
            result.Comment = args.Input.DebugIs;

            if (input.Is<Energy, Power, Time>("/"))
            {
                AlgebraDefUtils.Add1(result, "timeSeconds");
                result.AddVariable("returnType", "energy.Unit.GetSuggestedTimeUnit()");
                result.AddVariable("time", "Time.FromSecond(timeSeconds).ConvertTo(returnType)");
                result.UseReturnExpression = "time";
                return;
            }

            if (input.Is<Energy, Time, Power>("/"))
            {
                AlgebraDefUtils.CreateHeuristicCode(args);
                return;
            }

            if (input.Is<Time, Power, Energy>("*"))
            {
                AlgebraDefUtils.Add1(result, "basicEnergy");
                result.UseValueExpression = "basicEnergy";
                result.ResultUnit         = "EnergyUnits.Joule";
                return;
            }

            if (input.Is<Power, Time, Energy>("*"))
            {
                result.AddVariable("x", "4");
                AlgebraDefUtils.Add1(result, "basicEnergy");
                result.UseValueExpression = "basicEnergy";
                result.ResultUnit         = "EnergyUnits.Joule";
                return;
            }

            result.SetThrow();
        }
    }
}