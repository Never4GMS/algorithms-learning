namespace Algorithms.Month01.Les05
{
    public class ChessFigurePositionInput : BaseProblemInput<ulong[]>
    {
        public ushort Position { get; private set; }

        public override void Parse(string[] data) => Position = ushort.Parse(data[0]);

        public override string ToString() => $"Pos: {Position}";
    }
}
