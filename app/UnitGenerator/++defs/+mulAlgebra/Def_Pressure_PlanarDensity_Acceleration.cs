
using TMul = iSukces.UnitedValues.Pressure;
using T1 = iSukces.UnitedValues.PlanarDensity;
using T2 = iSukces.UnitedValues.Acceleration;

namespace UnitGenerator
{
    public class Def_Pressure_PlanarDensity_Acceleration
    {
        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            if (!e.ShouldITryToCreate(nameof(Def_Pressure_PlanarDensity_Acceleration)))
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

            if (input.Is<TMul, T1, T2>("/"))
            {
                e.SetHandled();
                Simple(TMulUnit, T1Unit, T2Unit);
                return;
            }

            if (input.Is<TMul, T2, T1>("/"))
            {
                e.SetHandled();
                Simple(TMulUnit, T2Unit, T1Unit);
                return;
            }

            if (input.Is<T1, T2, TMul>("*"))
            {
                e.SetHandled();
                Simple(T1Unit, T2Unit, TMulUnit);
                return;
            }

            if (input.Is<T2, T1, TMul>("*"))
            {
                e.SetHandled();
                Simple(T2Unit, T1Unit, TMulUnit);
                return;
            }

            result.SetThrow();
        }

        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints
            {
                ImplementingClass = nameof(Def_Pressure_PlanarDensity_Acceleration)
            };
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<TMul, T1, T2>(hints);
        }

        private const string TMulUnit = "PressureUnits.Pascal";
        private const string T1Unit = "PlanarDensityUnits.KgPerSquareMeter";
        private const string T2Unit = "AccelerationUnits.MetersPerSquareSeconds";
    }
}
