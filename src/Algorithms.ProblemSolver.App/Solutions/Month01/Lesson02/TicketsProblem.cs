namespace Algorithms.ProblemSolver.App.Solutions.Month01.Lesson02
{
    [Problem(1, 2, "1.Tickets")]
    public class TicketsProblem : BaseProblemSolver, IProblemSolver
    {
        public TicketsProblem()
        {
            _factorials = new double[100];
            _factorials[1] = 1;
        }

        private readonly double[] _factorials;
        private int _lastFactorial = 2;

        public string[] SolveProblem(string[] inputs)
        {
            if (IsEmpty(inputs)) return Empty;

            var n = int.Parse(inputs[0]);
            var count = CountLuckyTicketsFor(n);

            return SingleResult(count.ToString("F0"));
        }

        private double CountLuckyTicketsFor(int n)
        {
            double sum = 0;
            var N = n * 9;
            const int m = 10;

            for (var k = 0; k < n; k++)
            {
                var a = C(2 * n, k);
                var b = C(2 * n + N - k * m - 1, 2 * n - 1);

                if (k % 2 == 0)
                {
                    sum += a * b;
                }
                else
                {
                    sum -= a * b;
                }
            }

            return sum;
        }

        private double C(int n, int k)
        {
            if (k == 0) return 1;

            double p = 1;
            for (var value = n - k + 1; value <= n; value++)
            {
                p *= value;
            }

            return p / Factorial(k);
        }

        private double Factorial(int k)
        {
            if (k <= _factorials.Length)
            {
                if (_factorials[k] == 0)
                {
                    FillFatorials(k);
                }

                return _factorials[k];
            }

            var last = _factorials.Length - 1;
            var value = _factorials[last];
            if (value == 0)
            {
                value = FillFatorials(last);
            }

            for (var i = last + 1; i <= k; i++)
            {
                value *= i;
            }

            return value;
        }

        private double FillFatorials(int k)
        {
            for (var i = _lastFactorial; i <= k; i++)
            {
                _factorials[i] = _factorials[i - 1] * i;
            }

            _lastFactorial = k;

            return _factorials[_lastFactorial];
        }
    }
}
