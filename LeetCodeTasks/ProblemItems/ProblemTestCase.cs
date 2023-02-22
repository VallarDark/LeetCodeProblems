namespace LeetCodeTasks.ProblemItems
{
    public class ProblemTestCase<OutputData, InputData>
    {
        public InputData Input { get; set; }

        public List<OutputData> CorrectResults { get; set; }

        public ProblemTestCase(InputData inputData, params OutputData[] correctResults)
        {
            this.Input = inputData;
            CorrectResults = new List<OutputData>(correctResults);
        }
    }
}
