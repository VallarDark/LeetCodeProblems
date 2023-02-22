using LeetCodeTasks.Contracts;
using LeetCodeTasks.Promlems;

bool shouldBeDiagnosed = false;

var problems = new List<IProblem>();

problems.Add(new Problem1());
problems.Add(new Problem2());
problems.Add(new Problem3());
problems.Add(new Problem4());
problems.Add(new Problem5());

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

        if (shouldBeDiagnosed && problem is IDiagnosable diagnosableProblem)
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