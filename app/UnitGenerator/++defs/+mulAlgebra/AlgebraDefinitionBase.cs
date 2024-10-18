namespace UnitGenerator;

class AlgebraDefinitionBase
{
    protected static void AddAB(OperatorCodeBuilderInput result, string aUnit, string bUnit, string resultUnit, string operator1)
    {
            
        result.AddVariable("leftConverted", ConversionCode(ExpressionSide.Left, aUnit));
        result.AddVariable("rightConverted", ConversionCode(ExpressionSide.Right, bUnit));
        result.UseValueExpression = "leftConverted.Value " + operator1 + " rightConverted.Value";
        result.ResultUnit         = resultUnit;
    }

    private static string ConversionCode(ExpressionSide s, string unit)
    {
        var ss = s == ExpressionSide.Left ? "left" : "right";
        return "$(" + ss + ").ConvertTo(" + unit + ")";
    }
}