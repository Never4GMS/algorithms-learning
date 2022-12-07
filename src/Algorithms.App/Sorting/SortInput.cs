namespace Algorithms.Sorting
{
    public class SortInput : BaseProblemInput<int[]>
    {
        public int[] Values { get; set; }

        public override void Parse(string[] data)
        {
            Values = new int[int.Parse(data[1])];

            switch (Enum.Parse<InputType>(data[0]))
            {
                case InputType.Random:
                    Values.SetRandom();
                    break;
                case InputType.Desc:
                    Array.Sort(Values);
                    Array.Reverse(Values);
                    break;
                case InputType.Asc:
                    Array.Sort(Values);
                    break;
            }
        }

        public override string ToString() => $"{Values.Take(3)}...{Values.TakeLast(3)} [{Values.Length}]";
    }

    public enum InputType
    {
        Random,
        Desc,
        Asc
    }
}
