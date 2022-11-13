using System.Globalization;

namespace Algorithms.Month01.Les03;

public class PowerInput : BaseProblemInput<double>
{
    public double Value { get; private set; }
    public ulong Power { get; private set; }

    public override void Parse(string[] data)
    {
        Value = double.Parse(data[0], CultureInfo.InvariantCulture.NumberFormat);
        Power = ulong.Parse(data[1]);
    }

    public override string ToString() => $"{Value}^{Power}";
}
