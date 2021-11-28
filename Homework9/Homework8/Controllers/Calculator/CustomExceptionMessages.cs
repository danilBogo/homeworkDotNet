using System.Linq.Expressions;

namespace Homework8.Controllers.Calculator
{
    public static class CustomExceptionMessages
    {
        public const string FirstValueIsWrong = "Первое значение не является числом";
        public const string SecondValueIsWrong = "Второе значение не является числом";
        public const string OperationIsUndefined = "Допустимы следующие операции: plus, minus, multiply, divide";
        public const string DivideOnZero = "На ноль делить нельзя";

        public static readonly Expression InvalidBracketsPlacement =
            Expression.Constant("Brackets placement is invalid");

        public static readonly Expression InvalidOperand = Expression.Constant("Operand is invalid");

        public static readonly Expression InvalidExpressionInBrackets =
            Expression.Constant("Expression in brackets is invalid");

        public static readonly Expression InvalidExpression = Expression.Constant("Expression is invalid");

        public static readonly Expression UndefinedElement = Expression.Constant("Element is undefined");

        public static readonly Expression EmptyString = Expression.Constant("Expression is null");
    }
}