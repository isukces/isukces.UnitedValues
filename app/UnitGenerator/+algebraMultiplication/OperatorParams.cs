namespace UnitGenerator
{
    public class OperatorParams
    {
        public OperatorParams(TypesGoup left, TypesGoup right, TypesGoup result, string leftName, string rightName, string oper)
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

        public TypesGoup Left { get; }

        public TypesGoup Right { get; }

        public TypesGoup Result { get; }

        public string LeftName { get; }

        public string RightName { get; }

        public string Oper { get; }

    }
}