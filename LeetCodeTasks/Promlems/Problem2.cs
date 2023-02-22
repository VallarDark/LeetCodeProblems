using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;

namespace LeetCodeTasks.Promlems
{
    #region ProblemCondition
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

    public class Problem2 : ProblemBase<Problem2.Output, Problem2.Input>
    {
        #region ProblemItems

        public class Input
        {
            public int[] Numbs { get; set; }

            public int Target { get; set; }

            public Input(int[] nums, int target)
            {
                Numbs = nums;
                Target = target;
            }
        }

        public class Output : IEquatable<Output>
        {
            public int[]? Numbs { get; set; }

            public Output(int[]? nums)
            {
                Numbs = nums;
            }

            public bool Equals(Output? other)
            {
                if (other == null || other.Numbs == null || Numbs == null)
                {
                    return false;
                }

                return other.Numbs.SequenceEqual(Numbs);
            }
        }

        #endregion

        #region ProblemSetup

        public Problem2()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(new[] { 2, 7, 11, 15 }, 9),
                    correctResults: new Output(new[] { 0, 1 })
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(new[] { 3, 2, 4 }, 6),
                    correctResults: new Output(new[] { 1, 2 })
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(new[] { 3, 3 }, 6),
                    correctResults: new Output(new[] { 0, 1 })
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(TwoSum(input.Numbs, input.Target));
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
