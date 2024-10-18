using System.Diagnostics;
using iSukces.UnitedValues;

namespace UnitGenerator;

internal class AlgebraDefUtils
{
    public static void Add1(OperatorCodeBuilderInput result, string name)
    {
        var l = result.OperatorParameters.LeftMethodArgumentName;
        var r = result.OperatorParameters.RightMethodArgumentName;
        result.AddVariable(l + "Value", l + ".GetBaseUnitValue()");
        result.AddVariable(r + "Value", r + ".GetBaseUnitValue()");
        result.AddVariable(name, $"{l}Value {result.OperatorParameters.Oper} {r}Value");
    }

    public static void CreateHeuristicCode(OperatorHints.CreateOperatorCodeEventArgs args)
    {
        var clrTypesResolver = new ClrTypesResolver(typeof(Length).Assembly);
        HeuristicOperatorGenerator.TryCreate(args, clrTypesResolver);
    }

    public static OperatorHints GetBasicOperatorHints()
    {
        var hints = new OperatorHints();
        hints.CreateOperatorCode += (sender, args) =>
        {
            args.Result.Comment = args.Input.DebugIs;
            Debug.WriteLine("Processing " + args.Input.DebugIs);
            CreateHeuristicCode(args);
            args.SetHandled();
        };
        return hints;
    }
}