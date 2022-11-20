using Algorithms.Month01.Les04.Structures;

namespace Algorithms.Month01.Les04
{
    [Problem(1, 4, nameof(ArraysRemove))]
    [TestColumn]
    public class ArraysRemove : BaseProblemBenchmark<ArrayOperationsInput, ArrayStateOutput, int[]>
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Cases))]
        public int[] RemoveWrappedArray(ArrayOperationsInput input, ArrayStateOutput output) =>
            Run(input, output, i =>
            {
                var array = new WrappedArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return array.ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] RemoveSingleArray(ArrayOperationsInput input, ArrayStateOutput output) =>
            Run(input, output, i =>
            {
                var array = new SingleArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return array.ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] RemoveVectorArray(ArrayOperationsInput input, ArrayStateOutput output) =>
            Run(input, output, i =>
            {
                var array = new VectorArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return array.ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] RemoveFactorArray(ArrayOperationsInput input, ArrayStateOutput output) =>
            Run(input, output, i =>
            {
                var array = new FactorArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return array.ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] RemoveMatrixArray(ArrayOperationsInput input, ArrayStateOutput output) =>
            Run(input, output, i =>
            {
                var array = new MatrixArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return array.ToArray();
            });
    }
}
