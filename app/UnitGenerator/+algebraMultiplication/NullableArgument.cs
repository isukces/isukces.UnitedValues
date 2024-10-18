using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator;

internal class NullableArgument
{
    private NullableArgument(string argName, bool isNullable)
    {
        _argName    = argName;
        _isNullable = isNullable;
    }

    public static CsCodeWriter CreateCode(string leftName, string rightName,
        string op, NullableArguments nullableArguments)
    {
        var cw = Ext.Create<MultiplyAlgebraGenerator>();
        var n1 = new NullableArgument(leftName, (nullableArguments & NullableArguments.Left) != 0);
        var n2 = new NullableArgument(rightName, (nullableArguments & NullableArguments.Right) != 0);
        var a  = new[] {n1, n2}.Where(q => q._isNullable).Select(q => q.IsNullCondition);
        cw.SingleLineIf(string.Join(" || ", a), "return null;");
        cw.WriteLine($"return {n1.Value} {op} {n2.Value};");
        return cw;
    }

    private string IsNullCondition => _argName + " is null";

    private string Value => _isNullable ? _argName + ".Value" : _argName;

    private readonly string _argName;
    private readonly bool   _isNullable;
}