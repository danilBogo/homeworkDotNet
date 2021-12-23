using System.Data.Common;
using Homework8.DbModels;
using Homework8.Services;
using Homework8.Services.Calculator;
using Expression = System.Linq.Expressions.Expression;

namespace Homework8.Controllers.Calculator
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