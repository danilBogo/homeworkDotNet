using System.Collections.Generic;
using System.Linq.Expressions;
using Homework8.Models;

namespace Homework8.Services.Calculator
{
    public class ExpressionCacheService
    {
        private readonly Dictionary<string, string> _dictionary = new ();

        public ExpressionCacheService()
        {
        }

        public void Add(ExpressionModel expressionModel)
        {
            _dictionary.Add(expressionModel.ExpressionValue, expressionModel.ExpressionResult);
        }

        public ExpressionModel Get(Expression expressionModel)
        {
            var expressionValue = expressionModel.ToString();
            if (!_dictionary.ContainsKey(expressionValue))
                return null;
            var expressionResult = _dictionary[expressionValue];
            return new ExpressionModel {ExpressionValue = expressionValue, ExpressionResult = expressionResult};
        }
    }
}