using LeetCodeTasks.Contracts;
using LeetCodeTasks.Promlems;

var tasks = new List<IProblem>();

tasks.Add(new Problem1());
tasks.Add(new Problem2());
tasks.Add(new Problem3());
tasks.Add(new Problem4());

for (int i = 0; i < tasks.Count; i++)
{
    var task = tasks[i];

    Console.WriteLine($"Problem № {i + 1}:");

    try
    {
        if (task.Check())
        {
            Console.WriteLine("All tests cases passed");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine();
}