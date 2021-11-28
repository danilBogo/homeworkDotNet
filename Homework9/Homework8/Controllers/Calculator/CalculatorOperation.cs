using System;
using System.Linq.Expressions;

namespace Homework8.Controllers
{
    public enum CalculatorOperation
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        LeftBracket,
        RightBracket
    }

    public static class CalculatorOperationExtensions
    {
        public static bool TryParse(string str, out CalculatorOperation operation)
        {
            operation = str switch
            {
                "+" => CalculatorOperation.Plus,
                "-" => CalculatorOperation.Minus,
                "*" => CalculatorOperation.Multiply,
                "/" => CalculatorOperation.Divide,
                "(" => CalculatorOperation.LeftBracket,
                ")" => CalculatorOperation.RightBracket,
            };
            return str == "+" || operation != CalculatorOperation.Plus;
        }

        public static bool TryConvertToBinaryExpression(this CalculatorOperation operation,
            Expression left,
            Expression right,
            out BinaryExpression expression)
        {
            if (operation is CalculatorOperation.LeftBracket or CalculatorOperation.RightBracket)
            {
                expression = null;
                return false;
            }

            expression = operation switch
            {
                CalculatorOperation.Plus => Expression.Add(left, right),
                CalculatorOperation.Minus => Expression.Subtract(left, right),
                CalculatorOperation.Multiply => Expression.Multiply(left, right),
                CalculatorOperation.Divide => Expression.Divide(left, right),
                _ => throw new ArgumentException($"{operation} is undefined")
            };

            return true;
        }
    }
}