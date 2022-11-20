namespace Algorithms.Month01.Les04
{
    public class ArrayStateOutput : BaseProblemOutput<int[]>
    {
        public int Size { get; private set; }

        public override bool Equals(int[]? other) =>
            other != null &&
            Size == other.Length &&
            Value.Length == other.Length &&
            Value.SequenceEqual(other);

        public override void Parse(string[] data)
        {
            Size = int.Parse(data[0]);
            Value = data[1].Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        protected override string Describe(int[] value) =>
            value != null ? $"[{value.Length}]: {string.Join(',', value.Take(5))}..{string.Join(',', value.TakeLast(5))}" : "empty or null";
    }
}
