using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Homework12
{
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    [MinColumn]
    [MaxColumn]
    public class BenchmarkTests
    {
        private readonly string FUrl = "http://localhost:5000/calculate";
        private readonly string CUrl = "https://localhost:5001/Calculator/Calculate";
        
        private HttpClient clientC;
        private HttpClient clientF;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            clientC = new HostBuilderC().CreateClient();
            clientF = new HostBuilderF().CreateClient();
        }

        [Benchmark(Description = "F# all")]
        public async Task FullFSharp()
            => await clientF.GetAsync(FUrl + "?value1=10&operation=plus&value2=20");
        
        [Benchmark(Description = "C# all")]
        public async Task FullCSharp() 
            => await clientC.GetAsync(CUrl + "?firstValue=5&operation=plus&secondValue=5");
    }
}