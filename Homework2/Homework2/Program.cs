using IlClasses;
using System;

namespace Homework2
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var check = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            if (check != 0) return check;
            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Result is: {result}");
            return 0;
        }
    }
}
