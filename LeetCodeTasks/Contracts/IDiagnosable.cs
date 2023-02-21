using BenchmarkDotNet.Reports;

namespace LeetCodeTasks.Contracts
{
    public interface IDiagnosable
    {
        Summary GetSummary();
    }
}
