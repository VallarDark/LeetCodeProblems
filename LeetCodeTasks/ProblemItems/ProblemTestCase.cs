namespace LeetCodeTasks.ProblemItems
{
    internal class ProblemTestCase<OutputData, InputData>
    {
        public InputData Input { get; set; }

        public OutputData CorrectResult { get; set; }

        public ProblemTestCase(InputData inputData, OutputData correctResult)
        {
            this.Input = inputData;
            CorrectResult = correctResult;
        }
    }
}
