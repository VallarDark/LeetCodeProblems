namespace LeetCodeTasks.Tasks
{
    #region TaskCondition
    /// <summary>
    /// Given two non-negative integers low and high. 
    /// Return the count of odd numbers between low and high (inclusive).

    ///Example 1:

    ///Input: low = 3, high = 7
    ///Output: 3
    ///Explanation: The odd numbers between 3 and 7 are[3, 5, 7].

    ///Example 2:

    ///Input: low = 8, high = 10
    ///Output: 1
    ///Explanation: The odd numbers between 8 and 10 are[9].

    /// </summary>
    #endregion

    internal class Task1 : ITask<int>
    {
        private readonly int _Start = 3;
        private readonly int _End = 7;

        public int GetResult()
        {
            return CountOdds(_Start, _End);
        }

        private int CountOdds(int start, int end)
        {
            return start % 2 + end % 2 + (end - start - start % 2 - end % 2) / 2;
        }
    }
}
