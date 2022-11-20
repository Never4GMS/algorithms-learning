namespace Algorithms.Month01.Les03;

[Problem(1, 3, "Primes")]
[TestColumn]
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

    [Benchmark]
    [ArgumentsSource(nameof(Cases))]
    public Task<ulong> SieveOfEratosthenes(PrimeInput input, SingleUlongOutput output)
    {
        static ulong Algorithm(PrimeInput input)
        {
            var full = 0xffffffffffffffff;
            var is_prime = new ulong[(input.N / 64) + 1];
            Array.Fill(is_prime, 0xffffffffffffffff);
            ulong count = 0;
            for (ulong i = 2; i <= input.N; i++)
            {
                var s = (ushort)(i % 64);
                var bit = 1ul << s;
                if ((is_prime[i / 64] & bit) == bit)
                {
                    for (ulong j = 2 * i; j <= input.N; j += i)
                    {
                        s = (ushort)(j % 64);
                        bit = 1ul << s;
                        is_prime[j / 64] &= (full ^ bit);
                    }

                    count++;
                }
            }

            return count;
        }

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }
}
