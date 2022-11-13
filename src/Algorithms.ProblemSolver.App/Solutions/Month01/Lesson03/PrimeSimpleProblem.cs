namespace Algorithms.ProblemSolver.App.Solutions.Month01.Lesson03
{
    [Problem(1, 3, nameof(PrimeSimpleProblem))]
    public class PrimeSimpleProblem : BaseProblemSolver, IProblemSolver
    {
        public string[] SolveProblem(string[] inputs)
        {
            var n = int.Parse(inputs[0]);
            return SingleResult(CountPrimes(n));
        }

        private ulong CountPrimes(int n)
        {
            ulong count = 0;
            for (var i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool IsPrime(int i)
        {
            for (var d = 2; d < i / 2; d++)
            {
                if (i % d == 0) return false;
            }

            return true;
        }
    }
}
