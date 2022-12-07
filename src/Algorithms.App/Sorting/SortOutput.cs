namespace Algorithms.Sorting
{
    public class SortOutput : BaseProblemOutput<int[]>
    {
        public override bool Equals(int[]? other) =>
            other != null && SortedCopy(other).SequenceEqual(other);

        private static int[] SortedCopy(int[] other)
        {
            var output = new int[other.Length];
            Array.Copy(other, output, other.Length);
            Array.Sort(output);
            return output;
        }

        public override void Parse(string[] data) { Value = Array.Empty<int>(); }

        protected override string Describe(int[] value) => $"{value.Take(3)}...{value.TakeLast(3)} [{value.Length}]";
    }
}
