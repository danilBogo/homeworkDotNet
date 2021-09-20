using System;
using Homework2;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private const int SuccessfulExecution = 0;
        private const int WrongArgLength = 1;
        private const int WrongArgFormatInt = 2;
        private const int WrongArgFormatOperation = 3;
        private const int DividingByZero = 4;
        
        [Theory]
        [InlineData(10, 5)]
        public void TestCalculatorAddition(int value1, int value2)
        {
            Assert.Equal(value1 + value2, Calculator.Calculate(value1, CalculatorOperation.Plus, value2));
        }

        [Theory]
        [InlineData(10, 5)]
        public void TestCalculatorSubtraction(int value1, int value2)
        {
            Assert.Equal(value1 - value2, Calculator.Calculate(value1, CalculatorOperation.Minus, value2));
        }

        [Theory]
        [InlineData(10, 5)]
        public void TestCalculatorMultiplication(int value1, int value2)
        {
            Assert.Equal(value1 * value2, Calculator.Calculate(value1, CalculatorOperation.Multiply, value2));
        }

        [Theory]
        [InlineData(10, 5)]
        public void TestCalculatorDivision(int value1, int value2)
        {
            Assert.Equal(value1 / value2, Calculator.Calculate(value1, CalculatorOperation.Divide, value2));
        }

        [Theory]
        [InlineData(new object[] { new string[] { "f", "+", "3" } })]
        public void TestParserWrongFirstValue(string[] args)
        {
            Assert.Equal(WrongArgFormatInt,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", "+", "f" } })]
        public void TestParserWrongSecondValue(string[] args)
        {
            Assert.Equal(WrongArgFormatInt,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "a", "+", "f" } })]
        public void TestParserWrongFirstAndSecondValue(string[] args)
        {
            Assert.Equal(WrongArgFormatInt,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", ".", "4" } })]
        public void TestParserWrongOperation(string[] args)
        {
            Assert.Equal(WrongArgFormatOperation,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", "+", "4", "5" } })]
        public void TestParserWrongLength(string[] args)
        {
            Assert.Equal(WrongArgLength,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "f", ".", "4" } })]
        public void TestParserWrongOperationAndWrongFirstValue(string[] args)
        {
            Assert.Equal(WrongArgFormatOperation,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", ".", "f" } })]
        public void TestParserWrongOperationAndWrongSecondValue(string[] args)
        {
            Assert.Equal(WrongArgFormatOperation,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "+", "3" } })]
        public void TestParserAdditionCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "-", "3" } })]
        public void TestParserSubstractingCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "*", "3" } })]
        public void TestParserMultiplicationCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "/", "3" } })]
        public void TestParserDivisionCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution,
                Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "+", "3" } })]
        public void TestMainAdditionCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "-", "3" } })]
        public void TestMainSubstractingCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "*", "3" } })]
        public void TestMainMultiplicationCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", "/", "3" } })]
        public void TestMainDivisionCorrectValues(string[] args)
        {
            Assert.Equal(SuccessfulExecution, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "f", "+", "3" } })]
        public void TestMainWrongFirstValue(string[] args)
        {
            Assert.Equal(WrongArgFormatInt, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", "+", "f" } })]
        public void TestMainWrongSecondValue(string[] args)
        {
            Assert.Equal(WrongArgFormatInt, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "a", "+", "f" } })]
        public void TestMainWrongFirstAndSecondValue(string[] args)
        {
            Assert.Equal(WrongArgFormatInt, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", ".", "4" } })]
        public void TestMainWrongOperation(string[] args)
        {
            Assert.Equal(WrongArgFormatOperation, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", "+", "4", "5" } })]
        public void TestMainWrongLength(string[] args)
        {
            Assert.Equal(WrongArgLength, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "f", ".", "4" } })]
        public void TestMainWrongOperationAndWrongFirstValue(string[] args)
        {
            Assert.Equal(WrongArgFormatOperation, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "4", ".", "f" } })]
        public void TestMainWrongOperationAndWrongSecondValue(string[] args)
        {
            Assert.Equal(WrongArgFormatOperation, Program.Main(args));
        }
        
        [Theory]
        [InlineData(new object[] { new string[] { "3", "/", "0"} })]
        public void TestMainDividingByZero(string[] args)
        {
            Assert.Equal(DividingByZero, Program.Main(args));
        }
    }
}