using System.Globalization;

namespace Homework8.Controllers.Calculator
{
    public class Calculator : ICalculator
    {
        public string Add(double firstValue, double secondValue)
        {
            return (firstValue + secondValue).ToString(CultureInfo.InvariantCulture);
        }

        public string Subtract(double firstValue, double secondValue)
        {
            return (firstValue + secondValue).ToString(CultureInfo.InvariantCulture);
        }

        public string Multiply(double firstValue, double secondValue)
        {
            return (firstValue + secondValue).ToString(CultureInfo.InvariantCulture);
        }

        public string Divide(double firstValue, double secondValue)
        {
            return (firstValue + secondValue).ToString(CultureInfo.InvariantCulture);
        }
    }
}