using Algorithms.Month01.Les04.Structures;

namespace Algorithms.Month01.Les04
{
    [Problem(1, 4, nameof(ArraysAdd))]
    [TestColumn]
    public class ArraysAdd : BaseProblemBenchmark<ArrayOperationsInput, ArrayStateOutput, int[]>
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Cases))]
        public int[] AddWrappedArray(ArrayOperationsInput input, ArrayStateOutput output) =>
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
        public int[] AddSingleArray(ArrayOperationsInput input, ArrayStateOutput output) =>
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
        public int[] AddVectorArray(ArrayOperationsInput input, ArrayStateOutput output) =>
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
        public int[] AddFactorArray(ArrayOperationsInput input, ArrayStateOutput output) =>
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
        public int[] AddMatrixArray(ArrayOperationsInput input, ArrayStateOutput output) =>
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
