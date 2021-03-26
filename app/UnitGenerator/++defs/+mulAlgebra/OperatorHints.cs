using System;

namespace UnitGenerator
{
    public class OperatorHints
    {
        public OperatorCodeBuilderInput GetBuilder(OperatorParamsBase input)
        {
            var h = CreateOperatorCode;
            if (h is null)
                return null;
            var args = new CreateOperatorCodeEventArgs
            {
                Input  = input,
                Result = new OperatorCodeBuilderInput(input)
            };
            h(this, args);
            if (args.Handled)
                return args.Result;
            return null;
        }


        public event EventHandler<CreateOperatorCodeEventArgs> CreateOperatorCode;

        public sealed class CreateOperatorCodeEventArgs : EventArgs
        {
            public OperatorCodeBuilderInput Result  { get; set; }
            public OperatorParamsBase       Input   { get; set; }
            public bool                     Handled { get; set; }
        }
    }
}