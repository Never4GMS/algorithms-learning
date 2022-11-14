namespace Algorithms;

public class BigIntegerOutput : BaseProblemOutput<BigInteger>
{
    public override bool Equals(BigInteger other) => Value == other;

    public override void Parse(string[] data) => Value = BigInteger.Parse(data[0]);
}
