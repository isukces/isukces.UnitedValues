using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class Def_Force_Area_Pressure
    {
        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            if (!e.ShouldITryToCreate(nameof(Def_Force_Area_Pressure)))
                return;
            var input  = e.Input;
            var result = e.Result;

            void Simple(string leftUnit, string rightUnit, string resultUnit)
            {
                result.AddVariable("leftConverted", "$(left).ConvertTo(" + leftUnit + ")");
                result.AddVariable("rightConverted", "$(right).ConvertTo(" + rightUnit + ")");
                result.ResultUnit         = resultUnit;
                result.UseValueExpression = "leftConverted.Value " + input.Oper + " rightConverted.Value";
            }

            if (input.Is<Force, Area, Pressure>("/"))
            {
                e.SetHandled();
                Simple(ForceU, AreaU, PressureU);
                return;
            }

            if (input.Is<Force, Pressure, Area>("/"))
            {
                e.SetHandled();
                Simple(ForceU, PressureU, AreaU);
                return;
            }

            if (input.Is<Area, Pressure, Force>("*"))
            {
                e.SetHandled();
                Simple(AreaU, PressureU, ForceU);
                return;
            }

            if (input.Is<Pressure, Area, Force>("*"))
            {
                e.SetHandled();
                Simple(PressureU, AreaU, ForceU);
                return;
            }

            result.SetThrow();
        }

        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints
            {
                ImplementingClass = nameof(Def_Force_Area_Pressure)
            };
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<Force, Area, Pressure>(hints);
        }

        private const string ForceU = "ForceUnits.Newton";
        private const string AreaU = "AreaUnits.SquareMeter";
        private const string PressureU = "PressureUnits.Pascal";
    }
}
