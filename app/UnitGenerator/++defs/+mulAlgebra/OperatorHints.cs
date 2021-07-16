using System;
using System.Runtime.CompilerServices;

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
            var ic = (input as OperatorParams)?.OperatorHints?.ImplementingClass;
            if (!string.IsNullOrEmpty(ic))
            {
                Console.WriteLine("Class " + ic + " need to be changed in order to support " + input.DebugIs);
            }
            return null;
        }


        public event EventHandler<CreateOperatorCodeEventArgs> CreateOperatorCode;

        public string ImplementingClass { get; set; }

        public sealed class CreateOperatorCodeEventArgs : EventArgs
        {
            public bool ShouldITryToCreate(string name)
            {
                if (!(Input is OperatorParams op))
                    return true;
                var implementingClass = op.OperatorHints?.ImplementingClass;
                if (string.IsNullOrEmpty(implementingClass))
                    return true;
                return name == implementingClass;
            }


            public void SetHandled([CallerLineNumber] int line = 0, [CallerMemberName] string method = null)
            {
                if (Handled)
                    throw new Exception("Already handled");
                Handled = true;
                Result.SetComment(line, method);
                Result.Comment = (this.Input.DebugIs + "\r\n" + Result.Comment).Trim();
            }

            public OperatorCodeBuilderInput Result  { get; set; }
            public OperatorParamsBase       Input   { get; set; }
            public bool                     Handled { get; private set; }
        }
    }
}
