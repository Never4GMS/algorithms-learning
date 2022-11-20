namespace Algorithms;

public class TestColumnAttribute : ColumnConfigBaseAttribute
{
    public TestColumnAttribute() : base(
        TestCaseColumn.Default,
        TestPassColumn.Default,
        TestResultColumn.Default)
    {
    }
}

public class TestPassColumn : BaseCustomInputColumn<ITestResult>
{
    public TestPassColumn() : base(nameof(TestPassColumn), "Test pass", bool.FalseString)
    {
    }

    public static readonly TestPassColumn Default = new();

    protected override string GetValue(ITestResult result) => result?.Success.ToString() ?? bool.FalseString;
}

public class TestResultColumn : BaseCustomInputColumn<ITestResult>
{
    public TestResultColumn() : base(nameof(TestResultColumn), "Test result", "-")
    {
    }

    public static readonly TestResultColumn Default = new();

    protected override string GetValue(ITestResult result) => result?.GetResult()?.ToString() ?? "-";
}

public class TestCaseColumn : BaseCustomInputColumn<ITestCase>
{
    public TestCaseColumn() : base(nameof(TestCaseColumn), "Test case", "-")
    {
    }

    public static readonly TestCaseColumn Default = new();

    protected override string GetValue(ITestCase @case) => @case?.Index.ToString() ?? "-";
}
