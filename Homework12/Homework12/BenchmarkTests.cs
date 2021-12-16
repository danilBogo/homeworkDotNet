using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace hw11
{
    [MinColumn]
    [MaxColumn]
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    public class BenchmarkTests
    {
        private HttpClient _clientCSharp;
        private HttpClient _clientFSharp;
        
        private const string FSharpUrl = "http://localhost:5000/calculate";
        private const string CSharpUrl = "https://localhost:5001/Calculator/Calculate";

        [GlobalSetup]
        public void GlobalSetUp()
        {
            _clientCSharp = new HostBuilderCSharp().CreateClient();
            _clientFSharp = new HostBuilderFSharp().CreateClient();
        }

        [Benchmark(Description = "F# all")]
        public async Task FullFSharp() 
            => await _clientFSharp.GetAsync(FSharpUrl + "?v1=5&operation=plus&v2=5");
        
        [Benchmark(Description = "C# all")]
        public async Task FullCSharp() 
            => await _clientCSharp.GetAsync(CSharpUrl + "?firstValue=5&operation=plus&secondValue=5");

        [Benchmark(Description = "C# TryParseEnum")]
        public void CSharp_TryParseEnum() 
            => hw7.Controllers.Calculator.CalculatorController.TryParseEnum<CalculatorOperation>("PLUS", out _);
    }
}