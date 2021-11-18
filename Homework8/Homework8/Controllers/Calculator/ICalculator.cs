namespace Homework8.Controllers.Calculator
{
    public interface ICalculator
    {
        string Add(double firstValue, double secondValue);
        string Subtract(double firstValue, double secondValue);
        string Multiply(double firstValue, double secondValue);
        string Divide(double firstValue, double secondValue);
    }
}