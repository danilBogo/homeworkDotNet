using System.Net;
using System.Threading.Tasks;
using Homework6;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x => { x.UseStartup<App.Startup>().UseTestServer(); });
            return builder;
        }
    }

    public class BasicTests
        : IClassFixture<CustomWebApplicationFactory<App.Startup>>
    {
        private readonly CustomWebApplicationFactory<App.Startup> _factory;

        public BasicTests(CustomWebApplicationFactory<App.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("10", "Plus", "5", "15", HttpStatusCode.OK)]
        [InlineData("1.9", "Plus", "5", "6,9", HttpStatusCode.OK)]
        [InlineData("1.9", "Plus", "5.9", "7,8", HttpStatusCode.OK)]
        [InlineData("1.009", "Plus", "5.9", "6,909", HttpStatusCode.OK)]
        [InlineData("-1.9", "Plus", "5.9", "4,0", HttpStatusCode.OK)]
        [InlineData("-1.9", "Plus", "boba", "Could not parse value 'boba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Plus", "5.9", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Plus", "boba", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        public async Task TestCalculatorAddition(string value1, string operation, string value2,
            string expectedValueOrError, HttpStatusCode statusCode)
        {
            await RunTest(value1, operation, value2, expectedValueOrError, statusCode);
        }

        [Theory]
        [InlineData("10", "Minus", "5", "5", HttpStatusCode.OK)]
        [InlineData("1.9", "Minus", "5", "-3,1", HttpStatusCode.OK)]
        [InlineData("1.9", "Minus", "5.9", "-4,0", HttpStatusCode.OK)]
        [InlineData("5.9", "Minus", "1.9", "4,0", HttpStatusCode.OK)]
        [InlineData("-1.9", "Minus", "boba", "Could not parse value 'boba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Minus", "5.9", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Minus", "boba", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        public async Task TestCalculatorSubstraction(string value1, string operation, string value2,
            string expectedValueOrError, HttpStatusCode statusCode)
        {
            await RunTest(value1, operation, value2, expectedValueOrError, statusCode);
        }

        [Theory]
        [InlineData("10", "Multiply", "5", "50", HttpStatusCode.OK)]
        [InlineData("10", "Multiply", "5.0", "50,0", HttpStatusCode.OK)]
        [InlineData("10", "Multiply", "5.1", "51,0", HttpStatusCode.OK)]
        [InlineData("10.1", "Multiply", "5.1", "51,51", HttpStatusCode.OK)]
        [InlineData("-10", "Multiply", "-5", "50", HttpStatusCode.OK)]
        [InlineData("-10", "Multiply", "5", "-50", HttpStatusCode.OK)]
        [InlineData("-1.9", "Multiply", "boba", "Could not parse value 'boba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Multiply", "5.9", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Multiply", "boba", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        public async Task TestCalculatorMultiplication(string value1, string operation, string value2,
            string expectedValueOrError, HttpStatusCode statusCode)
        {
            await RunTest(value1, operation, value2, expectedValueOrError, statusCode);
        }

        [Theory]
        [InlineData("10", "Divide", "5", "2", HttpStatusCode.OK)]
        [InlineData("10.5", "Divide", "5.0", "2,1", HttpStatusCode.OK)]
        [InlineData("10.2", "Divide", "5.1", "2", HttpStatusCode.OK)]
        [InlineData("-10.2", "Divide", "5.1", "-2", HttpStatusCode.OK)]
        [InlineData("10.2", "Divide", "-5.1", "-2", HttpStatusCode.OK)]
        [InlineData("-10.2", "Divide", "-5.1", "2", HttpStatusCode.OK)]
        [InlineData("-1.9", "Divide", "boba", "Could not parse value 'boba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Divide", "5.9", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        [InlineData("biba", "Divide", "boba", "Could not parse value 'biba' to type System.Decimal.",
            HttpStatusCode.BadRequest)]
        public async Task TestCalculatorDivision(string value1, string operation, string value2,
            string expectedValueOrError, HttpStatusCode statusCode)
        {
            await RunTest(value1, operation, value2, expectedValueOrError, statusCode);
        }

        [Fact]
        public async Task TestParserWrongOperation()
        {
            await RunTest("3", ".", "4", "Could not parse value '.' to type Homework6.CalculatorOperation.",
                HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task TestParserWrongOperation()
        {
            await RunTest("3", ".", "4", "Could not parse value '.' to type Homework6.CalculatorOperation.",
                HttpStatusCode.BadRequest);
        }
        
        private async Task RunTest(string value1, string operation, string value2, string expectedValueOrError,
            HttpStatusCode statusCode)
        {
            var client = _factory.CreateClient();
            var url = $"/calculate?value1={value1}&operation={operation}&value2={value2}";
            var response = await client.GetAsync(url);
            Assert.True(response.StatusCode == statusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedValueOrError, result);
        }
    }
}