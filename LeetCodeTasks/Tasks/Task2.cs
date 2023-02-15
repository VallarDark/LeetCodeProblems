using LeetCodeTasks.Contracts;
using LeetCodeTasks.TaskItems;

namespace LeetCodeTasks.Tasks
{
    #region TaskCondition
    /// <summary>

    /// Given an array of integers nums and an integer target,
    /// return indices of the two numbers such that they add up to target.

    /// You may assume that each input would have exactly one solution,
    /// and you may not use the same element twice.

    /// You can return the answer in any order.


    /// Example 1:

    /// Input: nums = [2, 7, 11, 15], target = 9
    /// Output: [0,1]
    /// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].


    /// Example 2:

    /// Input: nums = [3, 2, 4], target = 6
    /// Output: [1,2]


    /// Example 3:

    /// Input: nums = [3, 3], target = 6
    /// Output: [0,1]

    /// </summary>

    #endregion

    #region TaskItems

    internal class Task2Input
    {
        public int[] Numbs { get; set; }

        public int Target { get; set; }

        public Task2Input(int[] nums, int target)
        {
            Numbs = nums;
            Target = target;
        }
    }

    internal class Task2Output : IEquatable<Task2Output>
    {
        public int[]? Numbs { get; set; }

        public Task2Output(int[]? nums)
        {
            Numbs = nums;
        }

        public bool Equals(Task2Output? other)
        {
            if (other == null || other.Numbs == null || this.Numbs == null)
            {
                return false;
            }

            return Enumerable.SequenceEqual(other.Numbs, Numbs);
        }
    }

    #endregion

    internal class Task2 : TaskBase<Task2Output, Task2Input>
    {
        #region TaskSetup

        public Task2()
        {
            _TaskExamples.Add(new TaskExample<Task2Output, Task2Input>
                (
                    inputData: new Task2Input(new[] { 2, 7, 11, 15 }, 9),
                    correctResult: new Task2Output(new[] { 0, 1 })
                ));

            _TaskExamples.Add(new TaskExample<Task2Output, Task2Input>
                (
                    inputData: new Task2Input(new[] { 3, 2, 4 }, 6),
                    correctResult: new Task2Output(new[] { 1, 2 })
                ));

            _TaskExamples.Add(new TaskExample<Task2Output, Task2Input>
                (
                    inputData: new Task2Input(new[] { 3, 3 }, 6),
                    correctResult: new Task2Output(new[] { 0, 1 })
                ));
        }

        #endregion

        #region Solution

        protected override Task2Output Solution(Task2Input input)
        {
            return new Task2Output(TwoSum(input.Numbs, input.Target));
        }

        private int[]? TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
