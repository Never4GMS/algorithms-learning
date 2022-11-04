using System.Reflection;

public static class Problems
{
    public static Dictionary<string, Type> BuildIndexFromAssembleOf<T>()
    {
        var index = new Dictionary<string, Type>();
        var types = typeof(T).Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IProblemSolver)) && t.IsClass);

        foreach (var type in types)
        {
            var problem = type.GetCustomAttributes<ProblemAttribute>().FirstOrDefault();
            if (problem != null)
            {
                index[CreateKey(problem)] = type;
            }
        }

        return index;
    }

    public static string CreateKey(IProblemDescriptor problem) =>
        CreateKey(problem.Month, problem.Lesson, problem.Name);

    public static string CreateKey(ushort month, ushort lesson, string name) =>
        $"{month}_{lesson}_{name}";

    public static bool IsSolvedCorrect(string[] result, string[] output, out int index)
    {
        var size = Math.Min(result.Length, output.Length);

        for (index = 0; index < size; index++)
        {
            if (result[index] != output[index]) return false;
        }

        return size == output.Length;
    }
}
