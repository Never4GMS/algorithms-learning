namespace Algorithms;

public abstract class BaseProblemOutput<T> : BaseData, IEquatable<T>, ITestResult
{
    public bool Success { get; private set; }

    public string Result { get; private set; }

    public abstract bool Equals(T? other);

    public void Validate(T input)
    {
        Success = Equals(input);
        Result = input?.ToString() ?? "-";
    }
}
