using Algorithms.Month01.Les04.Structures;

namespace Algorithms.Month01.Les04
{
    public class ArrayOperationsInput : BaseProblemInput<int[]>
    {
        private readonly List<Action<IArray<int>>> _operations = new();
        public IEnumerable<Action<IArray<int>>> Operations => _operations;
        public int[] Value { get; set; } = Array.Empty<int>();

        public List<object> Outputs { get; set; } = new List<object>();

        public override void Parse(string[] data)
        {
            Value = data[0].Split(' ').Select(s => int.Parse(s)).ToArray();
            foreach (var line in data.Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                var parts = line.Split(' ');
                switch (parts[0])
                {
                    case nameof(IArray<int>.Add):
                        if (parts.Length > 2)
                        {
                            _operations.Add(a => a.Add(int.Parse(parts[1]), int.Parse(parts[2])));
                        }
                        else
                        {
                            _operations.Add(a => a.Add(int.Parse(parts[1])));
                        }

                        break;

                    case nameof(IArray<int>.Remove):
                        _operations.Add(a => a.Remove(int.Parse(parts[1])));
                        break;

                    case nameof(IArray<int>.Get):
                        _operations.Add(a => Outputs.Add(a.Get(int.Parse(parts[1]))));
                        break;
                }
            }
        }

        public override string ToString() => $"[{Value.Length}]: {string.Join(',', Value)}";
    }
}
