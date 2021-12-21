using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace Homework8.Controllers.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly IExpressionVisitor visitor;

        public Calculator(IExpressionVisitor visitor) => this.visitor = visitor;
        
        public Expression ParseStringToExpression(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException($"{str} is null");
            if (!IsBracketsPlacementValid(str))
                throw new ArgumentException($"{str} has invalid brackets placement");
            var listElements = new List<string>();
            if (!TryGetListOperands(str, listElements))
                throw new ArgumentException($"invalid operands");
            
            var expressionsStack = new Stack<Expression>();
            var operationsStack = new Stack<CalculatorOperation>();
            foreach (var element in listElements)
            {
                if (double.TryParse(element, out var numberResult))
                    expressionsStack.Push(Expression.Constant(numberResult, typeof(double)));
                else if (CalculatorOperationExtensions.TryParse(element, out var currentOperation))
                {
                    if (currentOperation == CalculatorOperation.RightBracket)
                        TryProcessExpressionInBrackets(operationsStack, expressionsStack);
                    while (operationsStack.Count > 0 &&
                           currentOperation != CalculatorOperation.LeftBracket &&
                           GetOperationPriority(operationsStack.Peek()) >= GetOperationPriority(currentOperation))
                    {
                        TryJoinExpressionsToBinaryExpression(expressionsStack, operationsStack.Pop());
                    }

                    if (currentOperation != CalculatorOperation.RightBracket)
                        operationsStack.Push(currentOperation);
                }
            }

            if (operationsStack.Count == 0 && expressionsStack.Count == 0)
                throw new InvalidExpressionException();
            return operationsStack.Any(operation =>
                !TryJoinExpressionsToBinaryExpression(expressionsStack, operation))
                ? throw new InvalidExpressionException()
                : expressionsStack.Pop();
        }

        public string GetExpressionResult(Expression expression) =>
            visitor.VisitAsync(expression).Result.ToString();

        private bool IsBracketsPlacementValid(string str)
        {
            var stack = new Stack<char>();
            foreach (var ch in str)
                if (IsCharBracket(ch))
                    ProcessCurrentBracket(ch, stack);
            return stack.Count == 0;
        }

        private static bool IsCharBracket(char ch) => ch is '(' or ')';

        private static bool IsFirstBracketOpenAndSecondClose(char firstBracket, char secondBracket) =>
            firstBracket == '(' && secondBracket == ')';

        private static void ProcessCurrentBracket(char bracket, Stack<char> stack)
        {
            if (stack.Count > 0 && IsFirstBracketOpenAndSecondClose(stack.Peek(), bracket))
                stack.Pop();
            else
                stack.Push(bracket);
        }

        private bool TryGetListOperands(string str, ICollection<string> result)
        {
            str = str.Replace(" ", "")
                .Replace(".", ",")
                .ToLower();

            var indexOfBeginningNumber = int.MinValue;
            for (var i = 0; i < str.Length; i++)
            {
                var currentChar = str[i];
                if (!IsCharSupported(currentChar)) return false;
                if (char.IsDigit(currentChar) ||
                    currentChar == ',' ||
                    currentChar == '-' && CanNumberBeNegative(str, i))
                {
                    if (indexOfBeginningNumber == int.MinValue) indexOfBeginningNumber = i;
                    continue;
                }

                if (indexOfBeginningNumber != int.MinValue)
                {
                    result.Add(str[indexOfBeginningNumber..i]);
                    indexOfBeginningNumber = int.MinValue;
                }

                result.Add(currentChar.ToString());
            }

            if (indexOfBeginningNumber != int.MinValue)
                result.Add(str[indexOfBeginningNumber..]);

            return true;

            bool CanNumberBeNegative(string str, int i) => i == 0 || str[i - 1] == '(';

            bool IsCharSupported(char chr) =>
                char.IsDigit(chr) || chr is '+' or '-' or '*' or '/' or '(' or ')' or ',';
        }

        private void TryProcessExpressionInBrackets(Stack<CalculatorOperation> operationsStack,
            Stack<Expression> expressionsStack)
        {
            CalculatorOperation currentOperation;
            while ((currentOperation = operationsStack.Pop()) != CalculatorOperation.LeftBracket)
                TryJoinExpressionsToBinaryExpression(expressionsStack, currentOperation);
        }

        private bool TryJoinExpressionsToBinaryExpression(Stack<Expression> expressionsStack,
            CalculatorOperation operation)
        {
            if (expressionsStack.Count < 2) return false;
            var rightValue = expressionsStack.Pop();
            var leftValue = expressionsStack.Pop();
            operation.ConvertToBinaryExpression(leftValue, rightValue, out var expression);
            expressionsStack.Push(expression);
            return true;
        }

        private int GetOperationPriority(CalculatorOperation operation)
        {
            var result = operation switch
            {
                CalculatorOperation.LeftBracket => 0,
                CalculatorOperation.RightBracket => 0,
                CalculatorOperation.Plus => 1,
                CalculatorOperation.Minus => 1,
                CalculatorOperation.Multiply => 2,
                CalculatorOperation.Divide => 2
            };
            return result;
        }
    }
}