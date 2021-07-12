using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    sealed class Def_Force_Length_LinearForce : AlgebraDefinitionBase
    {
        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            e.Result.Comment = e.Input.DebugIs;
            var input = e.Input;
            e.Handled = true;
            var result = e.Result;

            if (input.Is<Force, Length, LinearForce>("/"))
            {


                result.SetComment();
                result.Comment    += " " + nameof(Def_Force_Length_LinearForce);
                result.ResultUnit =  "new LinearForceUnit(force.Unit, length.Unit)";
                return;
            }

            if (input.Is<LinearForce, Length, Force>("*"))
            {
                result.SetComment();
                result.Comment    += " " + nameof(Def_Force_Length_LinearForce);
                result.ConvertRight("linearForce.Unit.DenominatorUnit");
                result.ResultUnit = "linearForce.Unit.CounterUnit";
                return;   
            }
            
            /*if (input.Is<Length, LinearForce,  Force>("*"))
            {
                result.SetComment();
                result.Comment += " " + nameof(Def_Force_Length_LinearForce);
                result.ConvertRight("linearForce.Unit.DenominatorUnit");
                result.ResultUnit = "linearForce.Unit.CounterUnit";
                return;   
            }*/

            Console.WriteLine(input.DebugIs);

            result.SetThrow();
        }


        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            // c.WithDiv<LinearForce, Length, Pressure>(hints);
            c.WithDiv<Force, Length, LinearForce>(hints);
        }

        private const string U_Force = "ForceUnits.Newton";

        const string U_Length = "LengthUnits.Meter";

        const string U_LinearForce = "new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter)";
    }
}
