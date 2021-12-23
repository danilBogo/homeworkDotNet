﻿using Homework8.Controllers.Calculator;
using Homework8.Models;
using Expression = System.Linq.Expressions.Expression;

namespace Homework8.Services.Calculator
{
    public class CacheCalculatorDecorator : CalculatorDecorator
    {
        private readonly ExpressionCacheService _expressionCacheService;

        public CacheCalculatorDecorator(ICalculator calculator, ExpressionCacheService expressionCacheService) :
            base(calculator)
        {
            _expressionCacheService = expressionCacheService;
        }

        public override string GetExpressionResult(Expression expression)
        {
            var cachedExpression = _expressionCacheService.Get(expression);
            if (cachedExpression != null)
                return cachedExpression.ExpressionResult;
            var result = Calculator.GetExpressionResult(expression);
            _expressionCacheService.Add(new ExpressionModel
                {ExpressionValue = expression.ToString(), ExpressionResult = result});
            return result;
        }
    }
}