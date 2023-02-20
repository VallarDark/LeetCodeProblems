namespace LeetCodeTasks.TaskItems
{
    internal class TaskTestCase<TaskOutput, TaskInput>
    {
        public TaskInput InputData { get; set; }

        public TaskOutput CorrectResult { get; set; }

        public TaskTestCase(TaskInput inputData, TaskOutput correctResult)
        {
            InputData = inputData;
            CorrectResult = correctResult;
        }
    }
}
