using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;

namespace LeetCodeTasks.Promlems
{
    #region ProblemCondition

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

    public class Problem1 : ProblemBase<Problem1.Output, Problem1.Input>
    {
        #region ProblemItems

        public class Input
        {
            public int Start { get; set; }

            public int End { get; set; }

            public Input(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        public class Output : IEquatable<Output>
        {
            public int Result { get; set; }

            public Output(int result)
            {
                Result = result;
            }

            public bool Equals(Output? other)
            {
                return other?.Result == Result;
            }
        }

        #endregion

        #region ProblemSetup

        public Problem1()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(3, 7),
                    correctResults: new Output(3)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(8, 10),
                    correctResults: new Output(1)
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(CountOdds(input.Start, input.End));
        }

        private int CountOdds(int start, int end)
        {
            return start % 2 + end % 2 + (end - start - start % 2 - end % 2) / 2;
        }

        #endregion
    }
}
