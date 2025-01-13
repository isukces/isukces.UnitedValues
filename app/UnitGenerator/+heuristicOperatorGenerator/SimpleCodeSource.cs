#nullable disable
namespace UnitGenerator;

public class SimpleCodeSource : ICodeSource1
{
    public override string ToString()
    {
        return Code;
    }

    public SimpleCodeSource(string code)
    {
        Code = code;
    }

    /*
    public void AddToDeleteMe(ExpressionsReductor reductor)
    {
        reductor.Add(ExpressionPath.FromSingleElement(Code));
    }
    */


    public string Code { get; private set; }
}
