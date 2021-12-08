using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Homework8;
using Homework8.Controllers.Calculator;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> list = new()
        {
            new object[] {"1+2", "3"},
            new object[] {"1.5+2.1", "3,6"},
            new object[] {"-1+(-2)", "-3"},
            new object[] {"1-2.1", "-1,1"},
            new object[] {"2.1-1", "1,1"},
            new object[] {"2.1-1.1", "1"},
            new object[] {"-2.1-1.1", "-3,2"},
            new object[] {"-2.1-(-1.1)", "-1"},
            new object[] {"1*2.1", "2,1"},
            new object[] {"0*1", "0"},
            new object[] {"0*0", "0"},
            new object[] {"-1*1.1", "-1,1"},
            new object[] {"1-1*1.1", "-0,1"},
            new object[] {"-1*1.1+1", "-0,1"},
            new object[] {"2*4+3*3", "17"},
            new object[] {"(2+3)*2", "10"},
            new object[] {"2*(2+3)", "10"},
            new object[] {"2*(2+3)+4", "14"},
            new object[] {"2 * ( 2 + 3 ) + 4", "14"},
            new object[] {"1.1+1,1", "2,2"},
            new object[] {"1,1+1.1", "2,2"},
            new object[] {"1,1+1,1", "2,2"},
            new object[] {"-1.1/(-1.1)", "1"},
            new object[] {"-1.1/1.1", "-1"},
            new object[] {"1.1/(-1.1)", "-1"},
            new object[] {"0/1.1", "0"},
            new object[] {"2/0.5", "4"},

            new object[] {"-1.1/0", "-&#x221E;"},
            new object[] {"-1.1/a", CustomExceptionMessages.InvalidOperand.ToString().Replace("\"", "&quot;")},
            new object[] {"a/(-1.1)", CustomExceptionMessages.InvalidOperand.ToString().Replace("\"", "&quot;")},
            new object[] {"0aboba1.1", CustomExceptionMessages.InvalidOperand.ToString().Replace("\"", "&quot;")},
            new object[] {"()", CustomExceptionMessages.InvalidExpression.ToString().Replace("\"", "&quot;")},
            new object[] {")(", CustomExceptionMessages.InvalidBracketsPlacement.ToString().Replace("\"", "&quot;")},
            new object[] {"+2", CustomExceptionMessages.InvalidExpression.ToString().Replace("\"", "&quot;")},
            new object[] {"-2", "-2"},
            new object[] {"+", CustomExceptionMessages.InvalidExpression.ToString().Replace("\"", "&quot;")},
            new object[] {"(323+24", CustomExceptionMessages.InvalidBracketsPlacement.ToString().Replace("\"", "&quot;")},
            new object[] {"323+24)", CustomExceptionMessages.InvalidBracketsPlacement.ToString().Replace("\"", "&quot;")},
            new object[] {"", CustomExceptionMessages.EmptyString.ToString().Replace("\"", "&quot;")}
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
        public async Task Test(string expression, string expectedResult)
        {
            var client = _factory.CreateClient();
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Calculator/Calculate");
            var formModel = new Dictionary<string, string> {{"str", expression}};
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await client.SendAsync(postRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains(expectedResult, responseString);
        }
        
        [Theory]
        [InlineData("(2+3) / 12 * 7 + 8 * 9", "74,91666666666667")]
        public async Task ParallelTest(string expression, string expectedResult)
        {
            var watch = new Stopwatch();
            var client = _factory.CreateClient();
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Calculator/Calculate");
            var formModel = new Dictionary<string, string> {{"str", expression}};
            postRequest.Content = new FormUrlEncodedContent(formModel);
            watch.Start();
            var response = await client.SendAsync(postRequest);
            watch.Stop();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.True(watch.ElapsedMilliseconds - 2000 < 500);
            Assert.Contains(expectedResult, responseString);
        }
        
        [Theory]
        [InlineData("(2+3 + 7) / 12 * 7 + 8 * 9", "79")]
        public async Task CacheTest(string expression, string expectedResult)
        {
            var firstTime = GetRequestTime(expression, expectedResult).Result;
            var secondTime = GetRequestTime(expression, expectedResult).Result;
            Assert.True(firstTime - secondTime > 1000);
        }

        private async Task<long> GetRequestTime(string expression, string expectedResult)
        {
            var watch = new Stopwatch();
            var client = _factory.CreateClient();
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Calculator/Calculate");
            var formModel = new Dictionary<string, string> {{"str", expression}};
            postRequest.Content = new FormUrlEncodedContent(formModel);
            watch.Start();
            var response = await client.SendAsync(postRequest);
            watch.Stop();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains(expectedResult, responseString);
            return watch.ElapsedMilliseconds;
        }
    }
}