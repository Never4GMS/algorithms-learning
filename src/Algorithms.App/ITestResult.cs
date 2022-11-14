namespace Algorithms;

public interface ITestResult<T> : ITestResult
{
    T Result { get; }
}

public interface ITestResult
{
    object GetResult();
    bool Success { get; }
}
