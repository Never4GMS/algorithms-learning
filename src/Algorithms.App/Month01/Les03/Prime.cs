namespace Algorithms.Month01.Les03;

[Problem(1, 3, "Primes")]
[TestPassColumn]
[BenchmarkCategory(Level.Junior)]
public class PrimeJunior : BaseProblemBenchmark<PrimeInput, SingleUlongOutput, ulong>
{
    public PrimeJunior()
    {
        TestLimit = 10;
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Cases))]
    public Task<ulong> Iterative(PrimeInput input, SingleUlongOutput output)
    {
        static ulong Algorithm(PrimeInput input)
        {
            ulong count = 0;
            for (var i = 2UL; i <= input.N; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }

            return count;
        }

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }

    private static bool IsPrime(ulong i)
    {
        for (var d = 2ul; d <= i / 2; d++)
        {
            if (i % d == 0) return false;
        }

        return true;
    }
}
