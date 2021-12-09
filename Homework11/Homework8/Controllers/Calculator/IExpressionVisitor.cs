using System.Linq.Expressions;

namespace Homework8.Controllers.Calculator
{
    public interface IExpressionVisitor
    {
        Expression Visit(Expression expression);
        Expression Visit(BinaryExpression expression);
        Expression Visit(ConstantExpression expression);
    }
}