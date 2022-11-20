namespace Algorithms.Month01.Les03;

[Problem(1, 3, "Power")]
[TestColumn]
[BenchmarkCategory(Level.Junior, Level.Middle)]
public class Power : BaseProblemBenchmark<PowerInput, SingleDoubleOutput, double>
{
    public Power()
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

    [Benchmark]
    [ArgumentsSource(nameof(Cases))]
    public Task<double> Div2(PowerInput input, SingleDoubleOutput output)
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
