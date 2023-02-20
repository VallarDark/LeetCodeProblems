namespace LeetCodeTasks.ProblemItems
{
    internal class ProblemSolution<OutputData, InputData>
    {
        private readonly Func<InputData, OutputData> _func;

        public ProblemSolution(Func<InputData, OutputData> func)
        {
            _func = func;
        }

        public virtual OutputData Solve(InputData inputData)
        {
            return _func(inputData);
        }
    }
}
