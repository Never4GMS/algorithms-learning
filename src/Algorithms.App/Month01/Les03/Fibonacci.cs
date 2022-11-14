namespace Algorithms.Month01.Les03;

[Problem(1, 3, "Fibo")]
[TestPassColumn]
[BenchmarkCategory(Level.Junior)]
public class Fibonacci : BaseProblemBenchmark<FibonacciInput, BigIntegerOutput, BigInteger>
{
    public Fibonacci()
    {
        TestLimit = 8;
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Cases))]
    public Task<BigInteger> Iterative(FibonacciInput input, BigIntegerOutput output)
    {
        static BigInteger Algorithm(FibonacciInput input)
        {
            var sec = new BigInteger[3] { 0, 1, 1 };
            for (ulong i = 3; i <= input.N; i++)
            {
                sec[i % 3] = sec[(i - 1) % 3] + sec[(i - 2) % 3];
            }

            return sec[input.N % 3];
        }

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Cases))]
    public Task<BigInteger> Recursive(FibonacciInput input, BigIntegerOutput output)
    {
        static BigInteger Algorithm(FibonacciInput input) => Fib(input.N);

        static BigInteger Fib(uint n) => n < 2 ? n : Fib(n - 1) + Fib(n - 2);

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }

    private static readonly double s_rootFromFive = Math.Sqrt(5);
    private static readonly double s_phi = (1 + s_rootFromFive) / 2;
    private static readonly double s_nphi = (1 - s_rootFromFive) / 2;

    [Benchmark]
    [ArgumentsSource(nameof(Cases))]
    public Task<BigInteger> GoldenRatio(FibonacciInput input, BigIntegerOutput output)
    {
        static BigInteger Algorithm(FibonacciInput input) =>
            new BigInteger((Math.Pow(s_phi, input.N) - Math.Pow(s_nphi, input.N)) / s_rootFromFive);

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }
}
