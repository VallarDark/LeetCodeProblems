using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;
using System.Text;

namespace LeetCodeTasks.Promlems
{
    #region ProblemCondition

    /// <summary>

    ///    The string "PAYPALISHIRING" is written in a zigzag pattern on
    /// a given number of rows like this: (you may want to display this pattern in
    /// a fixed font for better legibility)

    ///     P   A   H   N
    ///     A P L S I I G
    ///     Y   I   R

    ///    And then read line by line: "PAHNAPLSIIGYIR" 
    ///    Write the code that will take a string and make this conversion given a number of rows:
    ///    string convert(string s, int numRows);


    ///   Example 1:

    /// Input: s = "PAYPALISHIRING", numRows = 3
    /// Output: "PAHNAPLSIIGYIR"


    /// Example 2:

    /// Input: s = "PAYPALISHIRING", numRows = 4
    /// Output: "PINALSIGYAHRPI"

    /// Explanation:

    ///     P     I     N
    ///     A   L S   I G
    ///     Y A   H R
    ///     P     I


    /// Example 3:

    /// Input: s = "A", numRows = 1
    /// Output: "A"

    /// </summary>

    #endregion

    public class Problem7 : ProblemBase<Problem7.Output, Problem7.Input>
    {
        #region ProblemItems

        public struct LetterPosition
        {
            public char Value { get; set; }

            public int XIndex { get; set; }

            public int YIndex { get; set; }

            public LetterPosition(char value, int xIndex, int yIndex)
            {
                Value = value;
                XIndex = xIndex;
                YIndex = yIndex;
            }
        }

        public class Input
        {
            public string Data { get; set; }

            public int NumRows { get; set; }


            public Input(string data, int numRows)
            {
                Data = data;
                NumRows = numRows;
            }

            public override string ToString()
            {
                return $"{nameof(Data)}: {Data}; {nameof(NumRows)}: {NumRows}";
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

        public Problem7()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("PAYPALISHIRING", 3),
                    correctResults: new Output("PAHNAPLSIIGYIR")
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("PAYPALISHIRING", 4),
                    correctResults: new Output("PINALSIGYAHRPI")
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("PAYPALISHIRING", 2),
                    correctResults: new Output("PYAIHRNAPLSIIG")
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input("A", 1),
                    correctResults: new Output("A")
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(Convert2(input.Data, input.NumRows));
        }

        private static string Convert(string data, int numRows)
        {
            if (numRows < 2)
            {
                return data;
            }

            var letersPositions = CalculateLetterPositons(data, numRows);

            var sortedPositions = letersPositions.OrderBy(lp => lp.YIndex).ThenBy(lp => lp.XIndex).ToArray();

            return new string(sortedPositions.Select(lp => lp.Value).ToArray());
        }

        private static LetterPosition[] CalculateLetterPositons(string data, int numRows)
        {
            var letersPositions = new LetterPosition[data.Length];

            int xIndex = 0;
            int yIndex = 0;

            int numRowsDecreased = numRows - 1;
            int divider = numRows + numRowsDecreased - 1;

            for (int i = 0; i < data.Length; i++)
            {
                letersPositions[i] = new LetterPosition(data[i], xIndex, yIndex);

                if (i % divider < numRowsDecreased)
                {
                    yIndex++;
                }
                else
                {
                    yIndex--;
                    xIndex++;
                }
            }

            return letersPositions;
        }

        private static string Convert2(string data, int numRows)
        {
            if (numRows < 2)
            {
                return data;
            }

            var rows = new List<char>[numRows];

            for (int i = 0; i < numRows; i++)
            {
                rows[i] = new List<char>();
            }

            for (int i = 0; i < data.Length; i++)
            {
                int divider = (numRows - 1) * 2;
                int reminder = i % divider;
                int rowNomber;

                if (reminder < numRows)
                {
                    rowNomber = reminder;
                }
                else
                {
                    rowNomber = divider - reminder;
                }

                rows[rowNomber].Add(data[i]);
            }

            var result = new StringBuilder();

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < rows[i].Count; j++)
                {
                    result.Append(rows[i][j]);
                }
            }

            return result.ToString();
        }

        #endregion
    }
}
