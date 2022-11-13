namespace Algorithms.Month01.Les03;

[Problem(1, 3, "Fibo")]
[TestPassColumn]
[BenchmarkCategory(Level.Junior)]
public class FibonacciJunior : BaseProblemBenchmark<FibonacciInput, BigIntegerOutput, BigInteger>
{
    public FibonacciJunior()
    {
        TestLimit = 7;
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
}
