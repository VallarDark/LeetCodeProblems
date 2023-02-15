namespace LeetCodeTasks.TaskItems
{
    internal class TaskSolution<OutputData, InputData>
    {
        private readonly Func<InputData, OutputData> _func;

        public TaskSolution(Func<InputData, OutputData> func)
        {
            _func = func;
        }

        public virtual OutputData Solve(InputData inputData)
        {
            return _func(inputData);
        }
    }
}
