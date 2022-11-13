namespace Algorithms.ProblemSolver.App.Solutions.Month01.Lesson03
{
    [Problem(1, 3, nameof(FibRecursiveProblem))]
    public class FibRecursiveProblem : BaseProblemSolver, IProblemSolver
    {
        public string[] SolveProblem(string[] inputs)
        {
            var n = ulong.Parse(inputs[0]);
            return SingleResult(Fib(n));
        }

        private ulong Fib(ulong n) => n < 2 ? n : Fib(n - 1) + Fib(n - 2);
    }
}
