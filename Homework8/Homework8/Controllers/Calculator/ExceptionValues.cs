namespace Homework8.Controllers.Calculator
{
    public static class ExceptionValues
    {
        public const string FirstValueIsWrong = "Первое значение не является числом";
        public const string SecondValueIsWrong = "Второе значение не является числом";
        public const string OperationIsUndefined = "Допустимы следующие операции: plus, minus, multiply, divide";
        public const string DivideOnZero = "На ноль делить нельзя";
    }
}