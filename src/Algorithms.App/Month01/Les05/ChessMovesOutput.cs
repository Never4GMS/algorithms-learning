namespace Algorithms.Month01.Les05
{
    public class ChessMovesOutput : BaseProblemOutput<ulong[]>
    {
        public override bool Equals(ulong[]? other) => other != null && Value.SequenceEqual(other);

        public override void Parse(string[] data) => Value = data.Select(x => ulong.Parse(x)).ToArray();

        protected override string Describe(ulong[] value) => $"{value[0]} [{value[1]}]";
    }
}
