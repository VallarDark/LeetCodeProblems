using LeetCodeTasks.ProblemItems;
using System.Text.Json;

namespace LeetCodeTasks.Contracts
{
    internal abstract class ProblemBase<Output, Input> : IProblem
    {
        private ProblemSolution<Output, Input> _problemSolution;

        protected readonly List<ProblemTestCase<Output, Input>> _ProblemTestCases;

        public ProblemBase()
        {
            _problemSolution = new ProblemSolution<Output, Input>(Solution);
            _ProblemTestCases = new List<ProblemTestCase<Output, Input>>();
        }

        public virtual bool Check()
        {
            if (_ProblemTestCases.Count() == 0)
            {
                return false;
            }

            return _ProblemTestCases.All(e =>
                {
                    if (e.Input == null || e.CorrectResult == null)
                    {
                        throw new Exception("Wrong test data");
                    }

                    var solutionResult = _problemSolution.Solve(e.Input);

                    var result = ((IEquatable<Output>)e.CorrectResult).Equals(solutionResult);

                    if (!result)
                    {
                        throw new Exception($"\t Test didn't pass: Input data: {JsonSerializer.Serialize(e.Input)}\n\t Expected result: {JsonSerializer.Serialize(e.CorrectResult)} but was {JsonSerializer.Serialize(solutionResult)} ");
                    }

                    return result;
                }
            );
        }

        protected abstract Output Solution(Input input);
    }
}
