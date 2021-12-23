using System.Linq.Expressions;
using Homework8.Controllers.Calculator;

namespace Homework8.Services
{
    public abstract class CalculatorDecorator : ICalculator
    {
        protected readonly ICalculator Calculator;

        protected CalculatorDecorator(ICalculator calculator)
        {
            Calculator = calculator;
        }
        
        public virtual Expression ParseStringToExpression(string str)
        {
            return Calculator.ParseStringToExpression(str);
        }

        public virtual string GetExpressionResult(Expression expression)
        {
            return Calculator.GetExpressionResult(expression);
        }
    }
}