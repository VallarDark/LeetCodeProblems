namespace LeetCodeTasks.TaskItems
{
    internal class TaskExample<TaskOutput, TaskInput>
    {
        public TaskInput InputData { get; set; }

        public TaskOutput CorrectResult { get; set; }

        public TaskExample(TaskInput inputData, TaskOutput correctResult)
        {
            InputData = inputData;
            CorrectResult = correctResult;
        }
    }
}
