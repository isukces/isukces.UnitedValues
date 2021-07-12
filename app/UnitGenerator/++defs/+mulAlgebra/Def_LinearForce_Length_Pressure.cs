using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    sealed class Def_LinearForce_Length_Pressure : AlgebraDefinitionBase
    {
        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            e.Result.Comment = e.Input.DebugIs;
            var input = e.Input;
            e.Handled = true;
            var result = e.Result;


            if (input.Is<Length, Pressure, LinearForce>("*"))
            {
                result.SetComment();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_Length, U_Pressure, U_LinearForce, input.Oper);
                return;
            }

            if (input.Is<Length, Pressure, LinearForce>("*"))
            {
                result.SetComment();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_Length, U_Pressure, U_LinearForce, input.Oper);
                return;
            }

            if (input.Is<Pressure, Length, LinearForce>("*"))
            {
                result.SetComment();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_Pressure, U_Length, U_LinearForce, input.Oper);
                return;
            }

            if (input.Is<LinearForce, Pressure, Length>("/"))
            {
                result.SetComment();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_LinearForce, U_Pressure, U_Length, input.Oper);
                return;
            }
            if (input.Is<LinearForce, Length, Pressure>("/"))
            {
                result.SetComment();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_LinearForce, U_Length, U_Pressure, input.Oper);
                return;
            }
            Console.WriteLine(input.DebugIs);

            result.SetThrow();
        }


        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<LinearForce, Length, Pressure>(hints);
        }

        private const string U_Pressure = "PressureUnits.Pascal";

        const string U_Length = "LengthUnits.Meter";

        const string U_LinearForce = "new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter)";
    }
}
