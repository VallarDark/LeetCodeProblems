using LeetCodeTasks.Contracts;
using LeetCodeTasks.Tasks;



var tasks = new List<ITask>();

tasks.Add(new Task1());
tasks.Add(new Task2());
tasks.Add(new Task3());

for (int i = 0; i < tasks.Count; i++)
{
    var task = tasks[i];

    Console.WriteLine($"Task № {i + 1}:");

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