using System;
using BenchmarkDotNet.Running;
using hw11;

namespace Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkTests>();
        }
    }
}