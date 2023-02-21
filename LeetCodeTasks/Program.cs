using LeetCodeTasks.Contracts;
using LeetCodeTasks.Promlems;

var problems = new List<IProblem>();

problems.Add(new Problem1());
problems.Add(new Problem2());
problems.Add(new Problem3());
problems.Add(new Problem4());

for (int i = 0; i < problems.Count; i++)
{
    var problem = problems[i];

    Console.WriteLine($"Problem № {i + 1}:");

    try
    {
        if (problem.Check())
        {
            Console.WriteLine("All tests cases passed");
        }

        if (problem is IDiagnosable diagnosableProblem)
        {
            var result = diagnosableProblem.GetSummary();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine();
}

//// the way to check which method is faster 
//BenchmarkRunner.Run<Problem4.Diagnoser>();