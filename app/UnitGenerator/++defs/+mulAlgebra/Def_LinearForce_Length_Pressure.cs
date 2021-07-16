using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    sealed class Def_LinearForce_Length_Pressure : AlgebraDefinitionBase
    {
        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            if (!e.ShouldITryToCreate(nameof(Def_LinearForce_Length_Pressure)))
                return;
             
            var input = e.Input;
            var result = e.Result;


            if (input.Is<Length, Pressure, LinearForce>("*"))
            {
                e.SetHandled();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_Length, U_Pressure, U_LinearForce, input.Oper);
                return;
            }

            if (input.Is<Length, Pressure, LinearForce>("*"))
            {
                e.SetHandled();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_Length, U_Pressure, U_LinearForce, input.Oper);
                return;
            }

            if (input.Is<Pressure, Length, LinearForce>("*"))
            {
                e.SetHandled();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_Pressure, U_Length, U_LinearForce, input.Oper);
                return;
            }

            if (input.Is<LinearForce, Pressure, Length>("/"))
            {
                e.SetHandled();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_LinearForce, U_Pressure, U_Length, input.Oper);
                return;
            }
            if (input.Is<LinearForce, Length, Pressure>("/"))
            {
                e.SetHandled();
                result.Comment += " " + nameof(Def_LinearForce_Length_Pressure);
                AddAB(result, U_LinearForce, U_Length, U_Pressure, input.Oper);
                return;
            }
          
        }


        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.ImplementingClass  =  nameof(Def_LinearForce_Length_Pressure);
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<LinearForce, Length, Pressure>( hints);
        }

        private const string U_Pressure = "PressureUnits.Pascal";

        const string U_Length = "LengthUnits.Meter";

        const string U_LinearForce = "new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter)";
    }
}
