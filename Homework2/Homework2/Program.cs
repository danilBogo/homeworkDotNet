using System;
using System.Runtime.CompilerServices;

namespace Homework2
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine(ClassLibrary1.Class.Square(10));
            //Console.WriteLine("kek");
            //Square(10);
            // var check = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            // if (check != 0) return check;
            //
            // var result = Calculator.Calculate(val1, operation, val2);
            // Console.WriteLine($"Result is: {result}");
            return 0;
        }
        
        // [MethodImpl(MethodImplOptions.ForwardRef)]
        // public static extern int Square(int number);
    }
}