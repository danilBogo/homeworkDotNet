using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework8.Controllers.Calculator
{
    public class CalculatorVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression binaryExpression)
        {
            var left = Task.Run(() => Visit(binaryExpression.Left));
            var right = Task.Run(() => Visit(binaryExpression.Right));
            Thread.Sleep(1000);
            Task.WhenAll(left, right);
            var leftResult = (left.Result as ConstantExpression)?.Value as double?;
            var rightResult = (right.Result as ConstantExpression)?.Value as double?;
            var result = binaryExpression.NodeType switch
            {
                ExpressionType.Add        => leftResult + rightResult,
                ExpressionType.Subtract   => leftResult - rightResult,
                ExpressionType.Multiply   => leftResult * rightResult,
                ExpressionType.Divide     => leftResult / rightResult,
                _                         => throw new ArgumentException()
            };
            return Expression.Constant(result, typeof(double));
        }
    }
}