namespace UnitGenerator
{
    public class OperatorParams
    {
        public OperatorParams(TypesGroup left, TypesGroup right, TypesGroup result, string leftName, string rightName, string oper)
        {
            Left      = left;
            Right     = right;
            Result    = result;
            LeftName  = leftName;
            RightName = rightName;
            Oper      = oper;
        }

        public override string ToString()
        {
            return $"Left={Left}, Right={Right}, Result={Result}, LeftName={LeftName}, RightName={RightName}, Oper={Oper}";
        }

        public TypesGroup Left { get; }

        public TypesGroup Right { get; }

        public TypesGroup Result { get; }

        public string LeftName { get; }

        public string RightName { get; }

        public string Oper { get; }

    }
}