namespace Algorithms;

public class SingleUlongOutput : BaseProblemOutput<ulong>
{
    public override bool Equals(ulong other) => Value == other;

    public override void Parse(string[] data) => Value = ulong.Parse(data[0]);
}
