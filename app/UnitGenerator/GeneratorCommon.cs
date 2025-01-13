using iSukces.Code;

namespace UnitGenerator;

public static class GeneratorCommon
{
    public static string EqualExpression(CsType compareType)
    {
        return $"other is {compareType.Declaration} value && Equals(value)";
    }

    internal static CsClass Setup(CsClass c)
    {
        c.IsPartial = true;
        const CodeFormattingFeatures flags = CodeFormattingFeatures.ExpressionBody | CodeFormattingFeatures.IsNotNull |
                                             CodeFormattingFeatures.MakeAutoImplementIfPossible;
        c.Formatting = new CodeFormatting(flags, 120);
        return c;
    }
}
