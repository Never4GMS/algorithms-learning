namespace Algorithms.Month01.Les03;

public class FibonacciInput : BaseProblemInput<BigInteger>
{
    public uint N { get; set; }

    public override void Parse(string[] data) => N = uint.Parse(data[0]);

    public override string ToString() => N.ToString();
}
