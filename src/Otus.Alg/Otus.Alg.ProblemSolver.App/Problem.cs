namespace Otus.Alg.ProblemSolver.App
{
    public class Problem : IProblemDescriptor
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public ushort Month { get; init; }
        public ushort Lesson { get; init; }
        public string RelativePath { get; init; }

        public override string ToString()
        {
            return $"{Name} [m:{Month},l:{Lesson}]";
        }
    }
}
