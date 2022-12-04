namespace Algorithms.Month01.Les07
{
    public class Sorting
    {
        private int[] _array;

        [Params(100, 1_000, 10_000, 100_000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var rand = new Random(12345);
            _array = new int[Size];

            var span = _array.AsSpan();
            for (var i = 0; i < span.Length; i++)
            {
                span[i] = rand.Next(0, Size);
            }
        }

        [Benchmark(Baseline = true)]
        public void ArraySortDotnet() => Array.Sort(_array);

        [Benchmark]
        public void SelectSort() => _array.SelectSort();

        [Benchmark]
        public void HeapSort() => _array.HeapSort();
    }
}
