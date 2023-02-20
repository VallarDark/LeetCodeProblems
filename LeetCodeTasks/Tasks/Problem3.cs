using LeetCodeTasks.Contracts;
using LeetCodeTasks.ProblemItems;
using System.Text;

namespace LeetCodeTasks.Tasks
{
    #region ProblemCondition

    /// <summary>

    /// You are given two non-empty linked lists representing two non-negative integers.
    /// The digits are stored in reverse order, 
    /// and each of their nodes contains a single digit. 
    /// Add the two numbers and return the sum as a linked list.

    /// You may assume the two numbers do not contain any leading zero,
    /// except the number 0 itself.


    /// Example 1:

    ///Input: l1 = [2,4,3], l2 = [5,6,4]
    /// Output: [7,0,8]
    /// Explanation: 342 + 465 = 807.


    /// Example 2:

    /// Input: l1 = [0], l2 = [0]
    /// Output: [0]


    /// Example 3:

    /// Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    /// Output: [8,9,9,9,0,0,0,1]

    /// </summary>

    #endregion

    internal class Problem3 : ProblemBase<Problem3.Output, Problem3.Input>
    {
        #region ProblemItems

        public class ListNode : IEquatable<ListNode>
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public override string ToString()
            {
                if (this == null)
                {
                    return string.Empty;
                }

                StringBuilder result = new StringBuilder();

                result.Append(this.val);

                if (this.next != null)
                {
                    result.Append("->" + this.next);
                }

                return result.ToString();
            }

            public bool Equals(ListNode? other)
            {
                return EqualsInner(this, other);
            }

            private static bool EqualsInner(ListNode? node1, ListNode? node2)
            {
                if (node1 == null && node2 == null)
                {
                    return true;
                }

                if (node1?.val != node2?.val)
                {
                    return false;
                }

                return EqualsInner(node1?.next, node2?.next);
            }
        }

        internal class Input
        {
            public ListNode Node1 { get; set; }

            public ListNode Node2 { get; set; }

            public Input(ListNode node1, ListNode node2)
            {
                Node1 = node1;
                Node2 = node2;
            }
        }

        internal class Output : IEquatable<Output>
        {
            public ListNode Node { get; set; }

            public Output(ListNode node)
            {
                Node = node;
            }

            public bool Equals(Output? other)
            {
                return Node.Equals(other?.Node);
            }
        }

        #endregion

        #region ProblemSetup

        public Problem3()
        {
            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(
                        new ListNode(
                            2, new ListNode(
                                4, new ListNode(
                                    3))),
                        new ListNode(
                            5, new ListNode(
                                6, new ListNode(
                                    4)))),

                    correctResult: new Output(
                        new ListNode(
                            7, new ListNode(
                                0, new ListNode(
                                    8))))
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(
                        new ListNode(0),
                        new ListNode(0)),

                    correctResult: new Output(
                        new ListNode(0))
                ));

            _ProblemTestCases.Add(new ProblemTestCase<Output, Input>
                (
                    inputData: new Input(
                        new ListNode(
                            9, new ListNode(
                                9, new ListNode(
                                    9, new ListNode(
                                        9, new ListNode(
                                            9, new ListNode(
                                                9, new ListNode(
                                                    9))))))),
                        new ListNode(
                            9, new ListNode(
                                9, new ListNode(
                                    9, new ListNode(
                                        9))))),

                    correctResult: new Output(
                        new ListNode(
                            8, new ListNode(
                                9, new ListNode(
                                    9, new ListNode(
                                        9, new ListNode(
                                            0, new ListNode(
                                                0, new ListNode(
                                                    0, new ListNode(
                                                        1)))))))))
                ));
        }

        #endregion

        #region ProblemSolution

        protected override Output Solution(Input input)
        {
            return new Output(AddTwoNumbers(input.Node1, input.Node2));
        }

        private ListNode AddTwoNumbers(ListNode listNode1, ListNode listNode2)
        {
            return AddTwoNumbersInner(listNode1, listNode2, new ListNode());
        }

        private ListNode AddTwoNumbersInner(
            ListNode listNode1,
            ListNode listNode2,
            ListNode result)
        {
            if (listNode1 == null && listNode2 == null)
            {
                if (result.val == 0)
                {
                    return null;
                }

                return result;
            }

            result.val += listNode1?.val ?? 0;
            result.val += listNode2?.val ?? 0;

            var next = new ListNode(result.val / 10);

            result.val = result.val % 10;

            result.next = AddTwoNumbersInner(listNode1?.next, listNode2?.next, next);

            return result;
        }

        #endregion
    }
}
