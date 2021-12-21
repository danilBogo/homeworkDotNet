using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework8.Controllers.Calculator
{
    public class CalculatorVisitor : IExpressionVisitor
    {
        public async Task<Expression> VisitAsync(Expression expression) => await VisitAsync((dynamic) expression);
    
        public async Task<Expression> VisitAsync(BinaryExpression expression)
        {
            await Task.Delay(1000);
            var left = VisitAsync(expression.Left);
            var right = VisitAsync(expression.Right);
            var leftResult = (await left as ConstantExpression)?.Value as double?;
            var rightResult = (await right as ConstantExpression)?.Value as double?;
            
            var result = expression.NodeType switch
            {
                ExpressionType.Add        => leftResult + rightResult,
                ExpressionType.Subtract   => leftResult - rightResult,
                ExpressionType.Multiply   => leftResult * rightResult,
                ExpressionType.Divide     => leftResult / rightResult,
            };
            return Expression.Constant(result, typeof(double));
        }

        public async Task<Expression> VisitAsync(ConstantExpression expression) => expression;
    }
}