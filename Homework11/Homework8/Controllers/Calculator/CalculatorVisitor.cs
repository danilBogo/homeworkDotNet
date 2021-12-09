using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework8.Controllers.Calculator
{
    public class CalculatorVisitor : IExpressionVisitor
    {
        public Expression Visit(Expression expression) => Visit((dynamic) expression);

        public Expression Visit(BinaryExpression expression)
        {
            var left = Task.Run(() => Visit(expression.Left));
            var right = Task.Run(() => Visit(expression.Right));
            Thread.Sleep(1000);
            Task.WhenAll(left, right);
            var leftResult = (left.Result as ConstantExpression)?.Value as double?;
            var rightResult = (right.Result as ConstantExpression)?.Value as double?;
            var result = expression.NodeType switch
            {
                ExpressionType.Add        => leftResult + rightResult,
                ExpressionType.Subtract   => leftResult - rightResult,
                ExpressionType.Multiply   => leftResult * rightResult,
                ExpressionType.Divide     => leftResult / rightResult,
            };
            return Expression.Constant(result, typeof(double));
        }

        public Expression Visit(ConstantExpression expression) => expression;
    }
}