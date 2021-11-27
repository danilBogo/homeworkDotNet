using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Homework8;
using Homework8.Controllers.Calculator;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public static class StaticMethods
    {
        public static string GenerateUrl(object firstValue, object operation, object secondValue)
        {
            return @$"/Calculator/Calculate?firstValue={firstValue}&operation={operation}&secondValue={secondValue}";
        }

        public static bool IsInaccuracyAcceptable(string expectedValue, string actualValue)
        {
            double.TryParse(expectedValue, out var firstValue);
            double.TryParse(actualValue, out var secondValue);
            var result = secondValue - firstValue;
            return result == 0 || result < 10e-6;
        }

        public static bool IsActualValueParseToDouble(string actualValue)
        {
            return double.TryParse(actualValue, out _);
        }
    }

    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> list = new()
        {
            new object[] {StaticMethods.GenerateUrl(1, "plus", 2), "3"},
            new object[] {StaticMethods.GenerateUrl(1.5, "plus", 2.1), "3.6"},
            new object[] {StaticMethods.GenerateUrl(-1, "plus", -2), "-3"},
            new object[] {StaticMethods.GenerateUrl(-1.5, "plus", -2.1), "-3.6"},

            new object[] {StaticMethods.GenerateUrl(1, "minus", 2.1), "-1.1"},
            new object[] {StaticMethods.GenerateUrl(2.1, "minus", 1), "1.1"},
            new object[] {StaticMethods.GenerateUrl(2.1, "minus", 1.1), "1"},
            new object[] {StaticMethods.GenerateUrl(-2.1, "minus", 1.1), "-3.2"},
            new object[] {StaticMethods.GenerateUrl(-2.1, "minus", -1.1), "-1"},

            new object[] {StaticMethods.GenerateUrl(1, "multiply", 2.1), "2.1"},
            new object[] {StaticMethods.GenerateUrl(0, "multiply", 1), "0"},
            new object[] {StaticMethods.GenerateUrl(0, "multiply", 0), "0"},
            new object[] {StaticMethods.GenerateUrl(-1, "multiply", 1.1), "-1.1"},

            new object[] {StaticMethods.GenerateUrl(-1.1, "divide", -1.1), "1"},
            new object[] {StaticMethods.GenerateUrl(-1.1, "divide", 1.1), "-1"},
            new object[] {StaticMethods.GenerateUrl(1.1, "divide", -1.1), "-1"},
            new object[] {StaticMethods.GenerateUrl(0, "divide", 1.1), "0"},
            new object[] {StaticMethods.GenerateUrl(2, "divide", 0.5), "4"},
            
            new object[] {StaticMethods.GenerateUrl(-1.1, "divide", 0), ExceptionValues.DivideOnZero},
            new object[] {StaticMethods.GenerateUrl(-1.1, "divide", "a"), ExceptionValues.SecondValueIsWrong},
            new object[] {StaticMethods.GenerateUrl("a", "divide", -1.1), ExceptionValues.FirstValueIsWrong},
            new object[] {StaticMethods.GenerateUrl(0, "aboba", 1.1), ExceptionValues.OperationIsUndefined},
        };

        public IEnumerator<object[]> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class BasicTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public async Task Test(string url, string expectedResult)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            var actualResult = await response.Content.ReadAsStringAsync();
            if (StaticMethods.IsActualValueParseToDouble(actualResult))
                Assert.True(StaticMethods.IsInaccuracyAcceptable(expectedResult, actualResult));
            Assert.Equal(expectedResult, actualResult);
        }
    }
}