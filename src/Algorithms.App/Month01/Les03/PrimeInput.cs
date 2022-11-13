namespace Algorithms.Month01.Les03;

public class PrimeInput : BaseProblemInput<ulong>
{
    public ulong N { get; set; }

    public override void Parse(string[] data) => N = ulong.Parse(data[0]);

    public override string ToString() => N.ToString();
}
