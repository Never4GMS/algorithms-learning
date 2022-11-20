using Algorithms.Month01.Les04.Structures;

namespace Algorithms.Month01.Les04
{
    [Problem(1, 4, nameof(ArraysGet))]
    [TestColumn]
    public class ArraysGet : BaseProblemBenchmark<ArrayOperationsInput, ArrayOperationsOutput, int[]>
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Cases))]
        public int[] GetWrappedArray(ArrayOperationsInput input, ArrayOperationsOutput output) =>
            Run(input, output, i =>
            {
                var array = new WrappedArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return i.Outputs.Cast<int>().ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] GetSingleArray(ArrayOperationsInput input, ArrayOperationsOutput output) =>
            Run(input, output, i =>
            {
                var array = new SingleArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return i.Outputs.Cast<int>().ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] GetVectorArray(ArrayOperationsInput input, ArrayOperationsOutput output) =>
            Run(input, output, i =>
            {
                var array = new VectorArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return i.Outputs.Cast<int>().ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] GetFactorArray(ArrayOperationsInput input, ArrayOperationsOutput output) =>
            Run(input, output, i =>
            {
                var array = new FactorArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return i.Outputs.Cast<int>().ToArray();
            });

        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] GetMatrixArray(ArrayOperationsInput input, ArrayOperationsOutput output) =>
            Run(input, output, i =>
            {
                var array = new MatrixArray<int>(i.Value);
                foreach (var operation in i.Operations)
                {
                    operation(array);
                }

                return i.Outputs.Cast<int>().ToArray();
            });
    }
}
