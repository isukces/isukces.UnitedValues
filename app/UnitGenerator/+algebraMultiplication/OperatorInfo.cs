#nullable disable
namespace UnitGenerator;

public class OperatorInfo
{
    static OperatorInfo()
    {
        var left = new ParameterNameAndDescription("dividend",
            "a dividend (counter) - a value that is being divided");
        var right = new ParameterNameAndDescription("divisor",
            "a divisor (denominator) - a value which dividend is divided by");
        Div = new OperatorInfo(left, right,
            "Division operation, calculates value dividend/divisor with unit that derives from dividend unit");

        //  the first factor is the multiplicand and the second the multiplier
        // Both numbers can be referred to as factors.
        left = new ParameterNameAndDescription("leftFactor",
            "left factor (multiplicand)");
        right = new ParameterNameAndDescription("rightFactor",
            "rigth factor (multiplier)");
        Mul = new OperatorInfo(left, right, "Multiplication operation");
    }

    public OperatorInfo(ParameterNameAndDescription left, ParameterNameAndDescription right, string description)
    {
        Left        = left;
        Right       = right;
        Description = description;
    }

    public override string ToString()
    {
        return $"Left={Left}, Right={Right}";
    }

    public ParameterNameAndDescription Left { get; }

    public ParameterNameAndDescription Right       { get; }
    public string                      Description { get; }

    public static readonly OperatorInfo Div;
    public static readonly OperatorInfo Mul;
}
