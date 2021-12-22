using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework8.Controllers.Calculator
{
    public interface IExpressionVisitor
    {
        Task<Expression> VisitAsync(Expression expression);
        Task<Expression> VisitAsync(BinaryExpression expression);
        Task<Expression> VisitAsync(ConstantExpression expression);
    }
}