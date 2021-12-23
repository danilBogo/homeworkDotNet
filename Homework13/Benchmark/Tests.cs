using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    [MeanColumn]
    [StdDevColumn]
    [MemoryDiagnoser]
    public class Tests
    {
        private const int countTimes = 10000;
        private const string ConcatenatedString = "aboba";

        private Methods Method { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            Method = new Methods();
        }

        [Benchmark(Description = "Common method")]
        public void SimpleMethod()
        {
            for (var i = 0; i < countTimes; i++)
                Method.Common(ConcatenatedString);
        }

        [Benchmark(Description = "Virtual method")]
        public void VirtualMethod()
        {
            for (var i = 0; i < countTimes; i++)
                Method.Virtual(ConcatenatedString);
        }

        [Benchmark(Description = "Generic method")]
        public void GenericMethod()
        {
            for (var i = 0; i < countTimes; i++)
                Method.Generic(ConcatenatedString);
        }

        [Benchmark(Description = "Static method")]
        public void StaticMethod()
        {
            for (var i = 0; i < countTimes; i++)
                Methods.Static(ConcatenatedString);
        }

        [Benchmark(Description = "Dynamic method")]
        public void DynamicMethod()
        {
            for (var i = 0; i < countTimes; i++)
                Method.Dynamic(ConcatenatedString);
        }

        [Benchmark(Description = "Reflection method")]
        public void ReflectionMethod()
        {
            for (var i = 0; i < countTimes; i++)
                Method.GetType().GetMethod("Reflection")?.Invoke(Method, new object[] {ConcatenatedString});
        }
    }
}