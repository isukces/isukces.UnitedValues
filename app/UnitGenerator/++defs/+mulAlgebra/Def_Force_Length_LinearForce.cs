using System;
using iSukces.UnitedValues;

namespace UnitGenerator;

sealed class Def_Force_Length_LinearForce : AlgebraDefinitionBase
{
    private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
    {
        if (!e.ShouldITryToCreate(nameof(Def_Force_Length_LinearForce)))
            return;
        e.Result.Comment = e.Input.DebugIs;
        var input  = e.Input;
        var result = e.Result;

        if (input.Is<Force, Length, LinearForce>("/"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment    += " " + nameof(Def_Force_Length_LinearForce);
            result.ResultUnit =  "new LinearForceUnit(force.Unit, length.Unit)";
            return;
        }

        if (input.Is<LinearForce, Length, Force>("*"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment    += " " + nameof(Def_Force_Length_LinearForce);
            result.ConvertRight("linearForce.Unit.DenominatorUnit");
            result.ResultUnit = "linearForce.Unit.CounterUnit";
            return;   
        }
            
           


            
    }


    public static void Setup(MultiplicationAlgebra c)
    {
        var hints = new OperatorHints();
        hints.CreateOperatorCode += HandleCreateOperatorCode;
        hints.ImplementingClass  =  nameof(Def_Force_Length_LinearForce);
        // c.WithDiv<LinearForce, Length, Pressure>(hints);
        c.WithDiv<Force, Length, LinearForce>( hints);
    }
        
}