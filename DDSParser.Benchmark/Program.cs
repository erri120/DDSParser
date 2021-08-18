using System.Reflection;
using BenchmarkDotNet.Running;

namespace DDSParser.Benchmark
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
        }
    }
}
