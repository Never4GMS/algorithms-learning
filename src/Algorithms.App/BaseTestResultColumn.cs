using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;

namespace Algorithms;

public abstract class BaseTestResultColumn : IColumn
{
    public BaseTestResultColumn(string id, string name, string defaultValue)
    {
        Id = id;
        ColumnName = name;
        _defaultValue = defaultValue;
    }

    public string Id { get; private set; }

    public string ColumnName { get; private set; }

    public bool AlwaysShow => true;

    public ColumnCategory Category => ColumnCategory.Custom;

    public int PriorityInCategory => 0;

    public bool IsNumeric => false;

    public UnitType UnitType => UnitType.Dimensionless;

    public string Legend => "Is test pass";

    public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
    {
        try
        {
            foreach (var param in benchmarkCase.Parameters.Items)
            {
                if (param.Value is ITestResult result)
                {
                    return GetValue(result);
                }
            }
        }
        catch
        {
        }

        return _defaultValue;
    }

    protected abstract string GetValue(ITestResult result);

    private string _defaultValue;

    public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) =>
        GetValue(summary, benchmarkCase);

    public bool IsAvailable(Summary summary) => true;

    public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
}
