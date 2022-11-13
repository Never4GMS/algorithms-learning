namespace Algorithms;

public class TestPassColumnAttribute : ColumnConfigBaseAttribute
{
    public TestPassColumnAttribute() : base(
        TestPassColumn.Default,
        TestResultColumn.Default)
    {
    }
}

public class TestPassColumn : BaseTestResultColumn
{
    public TestPassColumn() : base(nameof(TestPassColumn), "Test pass", bool.FalseString)
    {
    }

    public static readonly TestPassColumn Default = new();

    protected override string GetValue(ITestResult result) => result.Success.ToString();
}

public class TestResultColumn : BaseTestResultColumn
{
    public TestResultColumn() : base(nameof(TestResultColumn), "Test result", "-")
    {
    }

    public static readonly TestResultColumn Default = new();

    protected override string GetValue(ITestResult result) => result.Result;
}
