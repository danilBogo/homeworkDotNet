namespace Homework1
{
    public static class Calculator
    {
        public static int Calculate(int value1, CalculatorOperation operation, int value2)
        {
            var result = operation switch
            {
                CalculatorOperation.Plus => value1 + value2,
                CalculatorOperation.Minus => value1 - value2,
                CalculatorOperation.Multiply => value1 * value2,
                CalculatorOperation.Divide => value1 / value2,
            };
            return result;
        }
    }
}