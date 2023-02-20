using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;
using System.Text;

namespace LeetCodeTasks.Tasks
{
    #region ProblemCondition

    /// <summary>

    /// Given a string s, find the length of the longest
    /// substring
    /// without repeating characters.


    /// Example 1:

    /// Input: s = "abcabcbb"
    /// Output: 3
    /// Explanation: The answer is "abc", with the length of 3.


    /// Example 2:

    /// Input: s = "bbbbb"
    /// Output: 1
    /// Explanation: The answer is "b", with the length of 1.


    /// Example 3:

    /// Input: s = "pwwkew"
    /// Output: 3
    /// Explanation: The answer is "wke", with the length of 3.
    /// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

    /// </summary>

    #endregion

    internal class Problem4 : ProblemBase<Problem4.Output, Problem4.Input>
    {
        #region ProblemItems

        internal class Input
        {
            public string Data { get; set; }

            public Input(string data)
            {
                Data = data;
            }
        }

        internal class Output : IEquatable<Output>
        {
            public int Length { get; set; }

            public Output(int length)
            {
                Length = length;
            }

            public bool Equals(Output? other)
            {
                return other?.Length == Length;
            }
        }

        #endregion

        #region ProblemSetup
        public Problem4()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("abcabcbb"),
                    correctResult: new Output(3)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("bbbbb"),
                    correctResult: new Output(1)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("pwwkew"),
                    correctResult: new Output(3)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(" "),
                    correctResult: new Output(1)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("dvdf"),
                    correctResult: new Output(3)
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(LengthOfLongestSubstring2(input.Data));
        }


        /// <summary>
        /// 1st solution
        /// </summary>

        private int LengthOfLongestSubstring(string data)
        {
            int maxLength = 0;
            StringBuilder currentSubString = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (!currentSubString.ToString().Contains(data[i]))
                {
                    currentSubString.Append(data[i]);
                }
                else
                {
                    i -= currentSubString.Length;
                    currentSubString.Clear();
                }

                if (maxLength < currentSubString.Length)
                {
                    maxLength = currentSubString.Length;
                }
            }

            return maxLength;
        }

        /// <summary>
        /// 2nd solution
        /// </summary>

        private int LengthOfLongestSubstring2(string data)
        {
            int maxLength = 1;
            bool hasSameChar = false;

            if (data.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < data.Length; i++)
            {
                hasSameChar = false;

                for (int j = i + 1; j < data.Length; j++)
                {
                    for (int c = i; c < j; c++)
                    {
                        if (data[j] == data[c])
                        {
                            hasSameChar = true;
                            break;
                        }
                    }

                    if (hasSameChar)
                    {
                        break;
                    }

                    if (maxLength < j - i + 1)
                    {
                        maxLength = j - i + 1;
                    }
                }
            }

            return maxLength;
        }

        /// <summary>
        /// 3rd solution
        /// </summary>

        private int LengthOfLongestSubstring3(string data)
        {
            if (data.Length == 0)
            {
                return 0;
            }

            int maxLength = 1;

            for (int i = 0; i < data.Length; i++)
            {
                LengthOfLongestSubstring3Inner(ref data, ref maxLength, i);
            }

            return maxLength;
        }

        private void LengthOfLongestSubstring3Inner(ref string data, ref int maxLength, int startIndex)
        {
            for (int j = startIndex + 1; j < data.Length; j++)
            {
                for (int c = startIndex; c < j; c++)
                {
                    if (data[j] == data[c])
                    {
                        return;
                    }
                }

                if (maxLength < j - startIndex + 1)
                {
                    maxLength = j - startIndex + 1;
                }
            }
        }

        #endregion
    }
}
