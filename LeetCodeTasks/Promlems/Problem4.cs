using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;
using System.Text;

namespace LeetCodeTasks.Promlems
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

    public class Problem4 : ProblemBase<Problem4.Output, Problem4.Input>, IDiagnosable
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

        #region ProblemSolutionDiagnoser

        public class Diagnoser : DiagnosableBase<Diagnoser>
        {
            public List<Input> Inputs { get; set; }

            public Diagnoser()
            {
                Inputs = new List<Input>()
                {
                    new Input(""),
                    new Input(" "),
                    new Input("    "),
                    new Input("bbbbbbb"),
                    new Input("wfafwewfaeffe"),
                    new Input("EWFWAFWWFUHWFEFGWEYEWFBBbhibwwibfbbdcbsdbddfga"),
                    new Input("srrrrrfsvvwbbegwgwddsdfwgrgrwc3gghwhwwggwggrg3t455y56fgsvs"),
                    new Input("eretaavffferhIUIsfwipVYEfygfpewuhfwgwrgr4553324442223555523525fffgtherrh"),
                    new Input("dsqggafusgqadvgqdedggildqdgdgpqgfwaggagwwfweffwffdwddgqivwdwpqdpqgqgGPGDEGEG0WYFWr"),
                    new Input("dwfeffeefwefwefgrthhtegefwfdgwgdywgfpgywfpgfdwdscsgfdugfggwfgwfudfguwefupwffgu[wguguguofw[[wwhehrwrg"),
                    new Input("whhfwilwfebbBIIFEPehpfweifwpepefpefevwfvpwvfwevffvwfwfbpfguwqfhetipqhquohfeiphpihfnfbjeffq[qffofvfvfjfdvwf;wf"),
                    new Input("hggaiowefaifawfdawfgywfgwfagfusdufg0sffgywfgyewfegwhwrrwffwwfyywfgwygfyfgyfefygGGVJHCVJDBDWIHBJvfjnngjgeougsudssjjjjsjsdd"),
                    new Input("wgwgygpwfuepguhfhwu[ufgwowufuwgupfguwpufgwef'gowefufu  9guw9aaefipyfwoiwfe'hwfeugwo;jgjfgwyfguweufefhwefuwf;gwwgwggwfgrgehteghieri  wfwfwfe")
                };
            }

            [Benchmark(Baseline = true)]
            [ArgumentsSource(nameof(Inputs))]
            public void BaselineBenchmark(Input input)
            {
                LengthOfLongestSubstring3(input.Data);
            }

            [Benchmark]
            [ArgumentsSource(nameof(Inputs))]
            public void Benchmark2(Input input)
            {
                LengthOfLongestSubstring2(input.Data);
            }

            [Benchmark]
            [ArgumentsSource(nameof(Inputs))]
            public void Benchmark3(Input input)
            {
                LengthOfLongestSubstring(input.Data);
            }
        }

        public Summary GetSummary()
        {
            return Diagnoser.GetSummary();
        }

        #endregion

        #region ProblemSetup
        public Problem4()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("abcabcbb"),
                    correctResults: new Output(3)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("bbbbb"),
                    correctResults: new Output(1)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("pwwkew"),
                    correctResults: new Output(3)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(" "),
                    correctResults: new Output(1)
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("dvdf"),
                    correctResults: new Output(3)
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(LengthOfLongestSubstring3(input.Data));
        }


        /// <summary>
        /// 1st solution
        /// </summary>

        private static int LengthOfLongestSubstring(string data)
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

        private static int LengthOfLongestSubstring2(string data)
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

        private static int LengthOfLongestSubstring3(string data)
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

        private static void LengthOfLongestSubstring3Inner(ref string data, ref int maxLength, int startIndex)
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
