using LeetCodeTasks.Contracts;
using LeetCodeTasks.TaskItems;

namespace LeetCodeTasks.Tasks
{
    #region TaskCondition

    /// <summary>

    /// Given two non-negative integers low and high. 
    /// Return the count of odd numbers between low and high (inclusive).


    /// Example 1:

    /// Input: low = 3, high = 7
    /// Output: 3
    /// Explanation: The odd numbers between 3 and 7 are[3, 5, 7].


    /// Example 2:

    /// Input: low = 8, high = 10
    /// Output: 1
    /// Explanation: The odd numbers between 8 and 10 are[9].

    /// </summary>

    #endregion

    #region TaskItems

    internal class Task1Input
    {
        public int Start { get; set; }

        public int End { get; set; }

        public Task1Input(int start, int end)
        {
            Start = start;
            End = end;
        }
    }

    internal class Task1Output : IEquatable<Task1Output>
    {
        public int Result { get; set; }

        public Task1Output(int result)
        {
            Result = result;
        }

        public bool Equals(Task1Output? other)
        {
            return other?.Result == Result;
        }
    }

    #endregion

    internal class Task1 : TaskBase<Task1Output, Task1Input>
    {
        #region TaskSetup

        public Task1()
        {
            _TaskExamples.Add(new TaskExample<Task1Output, Task1Input>
                (
                    inputData: new Task1Input(3, 7),
                    correctResult: new Task1Output(3)
                ));

            _TaskExamples.Add(new TaskExample<Task1Output, Task1Input>
                (
                    inputData: new Task1Input(8, 10),
                    correctResult: new Task1Output(1)
                ));
        }

        #endregion

        #region Solution

        protected override Task1Output Solution(Task1Input input)
        {
            return new Task1Output(CountOdds(input.Start, input.End));
        }

        private int CountOdds(int start, int end)
        {
            return start % 2 + end % 2 + (end - start - start % 2 - end % 2) / 2;
        }

        #endregion
    }
}
