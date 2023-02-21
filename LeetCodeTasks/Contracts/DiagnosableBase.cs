using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace LeetCodeTasks.Contracts
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public abstract class DiagnosableBase<Diagnoser>
    {
        public static Summary GetSummary()
        {
            return BenchmarkRunner.Run<Diagnoser>();
        }
    }
}
