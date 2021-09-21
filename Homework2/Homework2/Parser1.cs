using System;

namespace Homework2
{
    public static class Parser
    {
        public static int ParseCalcArguments(string[] args, out int value1, out CalculatorOperation operation,
            out int value2)
        {
            var isInt1 = int.TryParse(args[0], out value1);
            var isInt2 = int.TryParse(args[2], out value2);
            
            if (!IsOperationSupported(args[1], out operation)) return (int) Message.WrongArgFormatOperation;
            if (!IsArgLengthSupported(args.Length)) return (int) Message.WrongArgLength;
            if (!IsValueInt(args[0], isInt1) || !IsValueInt(args[2], isInt2)) return (int) Message.WrongArgFormatInt;
            if (operation == CalculatorOperation.Divide && value2 == 0) return (int) Message.DividingByZero;

            return (int) Message.SuccessfulExecution;
        }
        
        private static bool IsArgLengthSupported(int length)
        {
            return length == 3;
        }

        private static bool IsOperationSupported(string arg, out CalculatorOperation operation)
        {
            operation = arg switch
            {
                "+" => CalculatorOperation.Plus,
                "-" => CalculatorOperation.Minus,
                "*" => CalculatorOperation.Multiply,
                "/" => CalculatorOperation.Divide,
                _ => CalculatorOperation.UndefinedOperation
            };
            return operation != CalculatorOperation.UndefinedOperation;
        }

        private static bool IsValueInt(string arg, bool isInt)
        {
            return isInt;
        }
    }
}