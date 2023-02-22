using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;

namespace LeetCodeTasks.Promlems
{
    #region ProblemCondition

    /// <summary>

    ///    Given two sorted arrays nums1 and nums2 of size m and n respectively,
    /// return the median of the two sorted arrays.

    /// The overall run time complexity should be O(log (m+n)).


    /// Example 1:

    /// Input: nums1 = [1,3], nums2 = [2]
    ///    Output: 2.00000
    /// Explanation: merged array = [1, 2, 3] and median is 2.


    /// Example 2:

    /// Input: nums1 = [1,2], nums2 = [3,4]
    ///    Output: 2.50000
    /// Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.

    /// </summary>

    #endregion

    public class Problem5 : ProblemBase<Problem5.Output, Problem5.Input>
    {
        #region ProblemItems

        public class Input
        {
            public int[] Array1 { get; set; }

            public int[] Array2 { get; set; }

            public Input(int[] array1, int[] array2)
            {
                Array1 = array1;
                Array2 = array2;
            }
        }

        public class Output : IEquatable<Output>
        {
            public double Result { get; set; }

            public Output(double result)
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

        public Problem5()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(new[] { 1, 3 }, new[] { 2 }),
                    correctResult: new Output(2)
            ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(new[] { 1, 2 }, new[] { 3, 4 }),
                    correctResult: new Output(2.5d)
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(GetMedian(input.Array1, input.Array2));
        }

        private double GetMedian(int[] arr1, int[] arr2)
        {
            var resultArr = JoinSortedArrays(arr1, arr2);

            var remainder = resultArr.Length % 2;

            if (remainder == 0)
            {
                return (double)(resultArr[resultArr.Length / 2 - 1] + resultArr[resultArr.Length / 2]) / 2;
            }

            return resultArr[resultArr.Length / 2 - 1 + remainder];
        }


        private int[] JoinSortedArrays(int[] arr1, int[] arr2)
        {
            var resultArr = new int[arr1.Length + arr2.Length];

            int arr1Index = 0;
            int arr2Index = 0;

            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (arr1Index >= arr1.Length)
                {
                    resultArr[i] = arr2[arr2Index];

                    arr2Index++;

                    continue;
                }

                if (arr2Index >= arr2.Length)
                {
                    resultArr[i] = arr1[arr1Index];

                    arr1Index++;

                    continue;
                }

                if (arr1[arr1Index] <= arr2[arr2Index])
                {
                    resultArr[i] = arr1[arr1Index];

                    arr1Index++;
                }
                else
                {
                    resultArr[i] = arr2[arr2Index];

                    arr2Index++;
                }
            }

            return resultArr;
        }

        #endregion
    }
}
