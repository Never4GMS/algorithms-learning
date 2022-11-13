namespace Algorithms;

public class SingleStringOutput : BaseProblemOutput<string>
{
    public string Value { get; private set; }

    public override bool Equals(string? other) => Value == other;

    public override void Parse(string[] data)
    {
        Value = data[0];
    }

    public override string ToString() => Value;
}
