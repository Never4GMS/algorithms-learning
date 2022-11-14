using System.Globalization;

namespace Algorithms;

public class SingleDoubleOutput : BaseProblemOutput<double>
{
    public override bool Equals(double other) => Value == other;

    public override void Parse(string[] data)
    {
        Value = double.Parse(data[0], CultureInfo.InvariantCulture.NumberFormat);
    }
}
