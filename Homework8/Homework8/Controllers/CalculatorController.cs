using System;
using Homework8.Controllers.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    public class CalculatorController : Controller
    {
        public string Calculate([FromServices] ICalculator calculator,
            string firstValue,
            string operation,
            string secondValue)
        {
            var isFirstValueDouble = double.TryParse(firstValue, out var value1);
            var isSecondValueDouble = double.TryParse(secondValue, out var value2);
            if (!isFirstValueDouble)
                return ExceptionValues.FirstValueIsWrong;
            if (!isSecondValueDouble)
                return ExceptionValues.SecondValueIsWrong;

            var isOperation = isOperationDefined(operation, out var calculatorOperation);
            if (!isOperation) return ExceptionValues.OperationIsUndefined;
            if (calculatorOperation == CalculatorOperation.Divide && value2 == 0)
                return ExceptionValues.DivideOnZero;
            return calculatorOperation switch
            {
                CalculatorOperation.Plus => calculator.Add(value1, value2),
                CalculatorOperation.Minus => calculator.Subtract(value1, value2),
                CalculatorOperation.Multiply => calculator.Multiply(value1, value2),
                CalculatorOperation.Divide => calculator.Divide(value1, value2),
            };
        }

        private static bool isOperationDefined(string operation, out CalculatorOperation result)
        {
            var correctView = char.ToUpper(operation[0]) + operation[1..operation.Length].ToLower();
            var isOperation = Enum.TryParse(correctView, out result);
            return isOperation;
        }
    }
}