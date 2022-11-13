namespace Algorithms.Month01.Les03;

[Problem(1, 3, "Power")]
[TestPassColumn]
[BenchmarkCategory(Level.Junior)]
public class PowerJunior : BaseProblemBenchmark<PowerInput, SingleDoubleOutput, double>
{
    public PowerJunior()
    {
        TestLimit = 9;
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Cases))]
    public Task<double> Iterative(PowerInput input, SingleDoubleOutput output)
    {
        static double Algorithm(PowerInput input)
        {
            double result = 1;
            for (var i = 1UL; i <= input.Power; i++)
            {
                result *= input.Value;
            }

            return Math.Round(result, 11);
        }

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }
}

[Problem(1, 3, "Power")]
[TestPassColumn]
[BenchmarkCategory(Level.Middle)]
public class PowerMiddle : BaseProblemBenchmark<PowerInput, SingleDoubleOutput, double>
{
    public PowerMiddle()
    {
        TestLimit = 10;
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Cases))]
    public Task<double> Iterative(PowerInput input, SingleDoubleOutput output)
    {
        static double Algorithm(PowerInput input)
        {
            double a = input.Value;
            double res = 1;
            var n = input.Power;
            while (n != 0)
            {
                if (n % 2 == 1)
                {
                    res *= a;
                }
                a *= a;
                n >>= 1;
            }

            return Math.Round(res, 11);
        }

        return RunAsync(input, output, Algorithm, DefaultThreshold);
    }
}
