using System.Reflection;

namespace Algorithms;

public abstract class BaseProblemBenchmark<TInput, TOutput, TResult>
    where TInput : BaseProblemInput<TResult>, new()
    where TOutput : BaseProblemOutput<TResult>, new()
{
    public BaseProblemBenchmark()
    {
        _provider = new ProblemsProvider(BasePath);
        var descriptor = GetType().GetCustomAttributes<ProblemAttribute>().FirstOrDefault()
            ?? throw new NotImplementedException(nameof(ProblemAttribute));

        Problem = _provider.ReadProblem(descriptor);
    }

    protected string BasePath { get; set; } = "data";
    protected Problem Problem { get; private set; }
    protected int? TestLimit { get; set; } = null;

    public IEnumerable<object[]> Cases()
    {
        var cases = _provider.ReadCases(Problem, TestLimit);

        if (cases != null)
        {
            ushort index = 0;
            foreach (var (inputData, outputData) in cases)
            {
                var input = new TInput();
                input.Parse(inputData);
                input.Index = index++;
                var output = new TOutput();
                output.Parse(outputData);

                yield return new object[] { input, output };
            }
        }
    }

    protected TResult Run(TInput input, TOutput expected, Func<TInput, TResult> func)
    {
        try
        {
            var result = func(input);

            expected.Validate(result);

            return result;
        }
        catch
        {
            return default(TResult);
        }
    }

    protected readonly TimeSpan DefaultThreshold = TimeSpan.FromSeconds(1);
    private ProblemsProvider _provider;

    protected async Task<TResult> RunAsync(TInput input, TOutput expected, Func<TInput, TResult> func, TimeSpan threshold)
    {
        var cts = new CancellationTokenSource();
        var task = Task.Run(() => func(input), cts.Token);

        try
        {
            await Task.WhenAny(task, Task.Delay(threshold));

            if (task.IsCompletedSuccessfully)
            {
                var result = task.Result;

                expected.Validate(result);

                return result;
            }

            cts.Cancel();
        }
        catch
        {
        }

        return default(TResult);
    }
}
