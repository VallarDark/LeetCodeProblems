using LeetCodeTasks.TaskItems;
using System.Text.Json;

namespace LeetCodeTasks.Contracts
{
    internal abstract class TaskBase<TaskOutput, TaskInput> : ITask
    {
        private TaskSolution<TaskOutput, TaskInput> _taskSolution;

        protected readonly List<TaskTestCase<TaskOutput, TaskInput>> _TaskExamples;

        public TaskBase()
        {
            _taskSolution = new TaskSolution<TaskOutput, TaskInput>(Solution);
            _TaskExamples = new List<TaskTestCase<TaskOutput, TaskInput>>();
        }

        public virtual bool Check()
        {
            if (_TaskExamples.Count() == 0)
            {
                return false;
            }

            return _TaskExamples.All(e =>
                {
                    if (e.InputData == null || e.CorrectResult == null)
                    {
                        throw new Exception("Wrong test data");
                    }

                    var solutionResult = _taskSolution.Solve(e.InputData);

                    var result = ((IEquatable<TaskOutput>)e.CorrectResult).Equals(solutionResult);

                    if (!result)
                    {
                        throw new Exception($"\t Test didn't pass: Input data: {JsonSerializer.Serialize(e.InputData)}\n\t Expected result: {JsonSerializer.Serialize(e.CorrectResult)} but was {JsonSerializer.Serialize(solutionResult)} ");
                    }

                    return result;
                }
            );
        }

        protected abstract TaskOutput Solution(TaskInput input);
    }
}
