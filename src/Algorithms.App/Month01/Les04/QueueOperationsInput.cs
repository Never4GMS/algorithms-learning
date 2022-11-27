using Algorithms.Month01.Les04.Structures;

namespace Algorithms.Month01.Les04
{
    public class QueueOperationsInput : BaseProblemInput<int[]>
    {
        private readonly List<Action<IQueue<int>>> _operations = new();
        public IEnumerable<Action<IQueue<int>>> Operations => _operations;

        public override void Parse(string[] data)
        {
            foreach (var line in data.Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                var parts = line.Split(' ');
                switch (parts[0])
                {
                    case nameof(IQueue<int>.Enqueue):
                        _operations.Add(a => a.Enqueue(int.Parse(parts[1]), int.Parse(parts[2])));

                        break;
                }
            }
        }

        public override string ToString() => $"{_operations.Count} operations";
    }
}
