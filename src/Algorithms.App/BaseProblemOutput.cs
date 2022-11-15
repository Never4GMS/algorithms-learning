namespace Algorithms;

public abstract class BaseProblemOutput<T> : BaseData, IEquatable<T>, ITestResult<T>
{
    public bool Success { get; private set; }

    public T Result { get; private set; }

    public T Value { get; protected set; }

    public abstract bool Equals(T? other);

    public void Validate(T input)
    {
        Success = Equals(input);
        Result = input;
    }

    public override string ToString() => Value?.ToString() ?? "-";

    public object GetResult() => Result;
}
