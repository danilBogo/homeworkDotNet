using System;

namespace Homework2
{
    public class Parser
    {
        private const int SuccessfulExecution = 0;
        private const int WrongArgLength = 1;
        private const int WrongArgFormatInt = 2;
        private const int WrongArgFormatOperation = 3;
        private const int DividingByZero = 4;

        public static int ParseCalcArguments(string[] args, out int value1, out CalculatorOperation operation,
            out int value2)
        {
            var isInt1 = int.TryParse(args[0], out value1);
            var isInt2 = int.TryParse(args[2], out value2);
            
            if (!IsOperationSupported(args[1], out operation)) return WrongArgFormatOperation;
            if (!IsArgLengthSupported(args.Length)) return WrongArgLength;
            if (!IsValueInt(args[0], isInt1) || !IsValueInt(args[2], isInt2)) return WrongArgFormatInt;
            if (operation == CalculatorOperation.Divide && value2 == 0) return DividingByZero;

            return SuccessfulExecution;
        }
        
        private static bool IsArgLengthSupported(int length)
        {
            if (length == 3) return true;
            Console.WriteLine($"The program requires 3 arguments, but was {length}");
            return false;
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
            if (isInt) return true;
            Console.WriteLine($"Value is not int: {arg}");
            return false;
        }
    }
}