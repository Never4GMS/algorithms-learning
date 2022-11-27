namespace Algorithms.Month01.Les04
{
    [Problem(1, 4, nameof(Queue))]
    [TestColumn]
    public class Queue : BaseProblemBenchmark<QueueOperationsInput, ArrayStateOutput, int[]>
    {
        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public int[] EndqueDequePriorityQueue(QueueOperationsInput input, ArrayStateOutput output) =>
            Run(input, output, i =>
            {
                var queue = new Structures.PriorityQueue<int>();

                foreach (var operation in i.Operations)
                {
                    operation(queue);
                }

                var results = new int[queue.Count];
                for (var j = 0; j < results.Length; j++)
                {
                    results[j] = queue.Dequeue();
                }

                return results;
            });
    }
}
