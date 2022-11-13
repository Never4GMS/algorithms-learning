namespace Algorithms.ProblemSolver.App.Solutions.Month01.Lesson03
{
    [Problem(1, 3, nameof(PowIterativeProblem))]
    public class PowIterativeProblem : BaseProblemSolver, IProblemSolver
    {
        public string[] SolveProblem(string[] inputs)
        {
            var input = ulong.Parse(inputs[0]);
            var pow = int.Parse(inputs[1]);
            ulong p = 1;
            for (var i = 1; i <= pow; i++)
            {
                p *= input;
            }

            return SingleResult(p);
        }
    }
}
