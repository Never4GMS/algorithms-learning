namespace Algorithms.ProblemSolver.App.Solutions.Month01.Lesson03
{
    [Problem(1, 3, nameof(FibIterativeProblem))]
    public class FibIterativeProblem : BaseProblemSolver, IProblemSolver
    {
        public string[] SolveProblem(string[] inputs)
        {
            var n = ulong.Parse(inputs[0]);
            return SingleResult(Fib(n));
        }

        private static ulong Fib(ulong n)
        {
            var sec = new ulong[3] { 0, 1, 1 };
            for (ulong i = 3; i <= n; i++)
            {
                sec[i % 3] = sec[(i - 1) % 3] + sec[(i - 2) % 3];
            }

            return sec[n % 3];
        }
    }
}
