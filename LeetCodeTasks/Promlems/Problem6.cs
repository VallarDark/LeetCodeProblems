using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;

namespace LeetCodeTasks.Promlems
{
    #region ProblemCondition

    /// <summary>

    /// Given a string s, return the longest palindromic substring in s.


    /// Example 1:

    /// Input: s = "babad"
    /// Output: "bab"
    /// Explanation: "aba" is also a valid answer.


    /// Example 2:

    /// Input: s = "cbbd"
    /// Output: "bb"

    /// </summary>

    #endregion

    public class Problem6 : ProblemBase<Problem6.Output, Problem6.Input>
    {
        #region ProblemItems

        public class Input
        {
            public string Data { get; set; }

            public Input(string data)
            {
                Data = data;
            }

            public override string ToString()
            {
                return Data;
            }
        }

        public class Output : IEquatable<Output>
        {
            public string Data { get; set; }

            public Output(string data)
            {
                Data = data;
            }

            public bool Equals(Output? other)
            {
                return string.Equals(other?.Data, Data);
            }
        }

        #endregion

        #region ProblemSetup
        public Problem6()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("babad"),
                    correctResults: new[] { new Output("aba"), new Output("bab") }
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("babad1"),
                    correctResults: new[] { new Output("aba"), new Output("bab") }
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("cbbd"),
                    correctResults: new Output("bb")
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
               (
                   inputData: new Input("rataroorbrooran2"),
                   correctResults: new Output("aroorbroora")
               ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(LongestPalindrome(input.Data));
        }

        private static string LongestPalindrome(string data)
        {
            if (data.Length <= 1)
            {
                return data;
            }

            string longestPalindrome = string.Empty;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = data.Length - 1; j >= i; j--)
                {
                    string currentPalindrome = GetSubstringIfPalindrome(data, i, j);

                    if (currentPalindrome != string.Empty && longestPalindrome.Length < currentPalindrome.Length)
                    {
                        longestPalindrome = currentPalindrome;
                    }
                }
            }

            return longestPalindrome;
        }

        private static string GetSubstringIfPalindrome(string data, int startIndex, int endIndex)
        {
            for (int j = 0; j <= (endIndex - startIndex) / 2; j++)
            {
                if (data[startIndex + j] != data[endIndex - j])
                {
                    return string.Empty;
                }
            }

            return data.Substring(startIndex, endIndex - startIndex + 1);
        }

        #endregion
    }
}
