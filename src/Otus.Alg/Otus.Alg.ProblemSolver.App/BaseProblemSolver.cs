namespace Otus.Alg.ProblemSolver.App
{
    public abstract class BaseProblemSolver
    {
        protected string[] SingleResult<T>(T result) => new string[] { result.ToString() };

        protected string[] Empty => Array.Empty<string>();

        protected bool IsEmpty(string[] input) => input == null || input.Length == 0;
    }
}
