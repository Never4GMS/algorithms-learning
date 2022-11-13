namespace Algorithms.ProblemSolver.App.Solutions.Month01.Lesson02
{
    [Problem(1, 2, "0.String")]
    public class StringProblem : BaseProblemSolver, IProblemSolver
    {
        public string[] SolveProblem(string[] inputs)
        {
            if (IsEmpty(inputs)) return Empty;

            var input = inputs[0];

            return SingleResult(input.Length);
        }
    }
}
