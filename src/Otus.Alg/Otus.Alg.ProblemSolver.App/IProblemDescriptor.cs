namespace Otus.Alg.ProblemSolver.App
{
    public interface IProblemDescriptor
    {
        string Name { get; }
        ushort Month { get; }
        ushort Lesson { get; }
    }
}
