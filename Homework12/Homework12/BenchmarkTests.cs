using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Homework12
{
    [MinColumn]
    [MaxColumn]
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    public class BenchmarkTests
    {
        private const string FUrl = "http://localhost:5000/calculate";
        private const string CUrl = "https://localhost:5001/Calculator/Calculate";

        private HttpClient clientC;
        private HttpClient clientF;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            clientC = new HostBuilderC().CreateClient();
            clientF = new HostBuilderF().CreateClient();
        }
        [Benchmark(Description = "F#")]
        public async Task FullFSharp()
            => await clientF.GetAsync(FUrl + "?value1=10&operation=plus&value2=20");
        
        [Benchmark(Description = "C#")]
        public async Task FullCSharp() 
            => await clientC.GetAsync(CUrl + "?str=123*123");
    }
}