namespace Algorithms;

public class SingleStringOutput : BaseProblemOutput<string>
{
    public override bool Equals(string? other) => Value == other;

    public override void Parse(string[] data)
    {
        Value = data[0];
    }
}
