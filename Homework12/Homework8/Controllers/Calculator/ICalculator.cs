using System.Linq.Expressions;

namespace Homework8.Controllers.Calculator
{
    public interface ICalculator
    {
        Expression ParseStringToExpression(string str);
        string GetExpressionResult(Expression expression);
    }
}