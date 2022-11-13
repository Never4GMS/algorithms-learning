using System.Text.RegularExpressions;

namespace Algorithms.Data;

public class ProblemsProvider
{
    private readonly string _rootPath;
    private static readonly Regex s_monthRx = new(@"month(?<month>\d+)", RegexOptions.Compiled);
    private static readonly Regex s_lessonRx = new(@"lesson(?<lesson>\d+)", RegexOptions.Compiled);
    private static readonly Regex s_testRx = new(@"test\.(?<test>\d+)\.", RegexOptions.Compiled);

    public ProblemsProvider(string rootFolder)
    {
        if (string.IsNullOrEmpty(rootFolder)) throw new ArgumentNullException(nameof(rootFolder));

        _rootPath = Path.IsPathRooted(rootFolder)
            ? rootFolder
            : Path.Combine(Environment.CurrentDirectory, rootFolder);
    }

    public IReadOnlyCollection<Problem> ReadProblems()
    {
        var problemPaths = Directory.GetFiles(_rootPath, "*.txt", SearchOption.AllDirectories);

        var problems = new Problem[problemPaths.Length];

        for (var i = 0; i < problemPaths.Length; i++)
        {
            var path = problemPaths[i];
            var dirPath = Path.GetDirectoryName(path);

            problems[i] = ReadProblem(path, dirPath);
        }

        return problems;
    }

    public Problem ReadProblem(IProblemDescriptor descriptor)
    {
        var path = Path.Combine(_rootPath,
                $"month{descriptor.Month:00}",
                $"lesson{descriptor.Lesson:00}",
                descriptor.Name,
                "problem.txt");
        var dirPath = Path.GetDirectoryName(path);
        return ReadProblem(path, dirPath);
    }

    private Problem ReadProblem(string path, string? dirPath)
    {
        return new Problem
        {
            Name = dirPath.Split(Path.DirectorySeparatorChar).Last(),
            Description = File.ReadAllText(path),
            RelativePath = Path.GetRelativePath(_rootPath, dirPath),
            Lesson = ushort.TryParse(s_lessonRx.Match(path).Groups["lesson"].Value, out var lesson) ? lesson : ushort.MinValue,
            Month = ushort.TryParse(s_monthRx.Match(path).Groups["month"].Value, out var month) ? month : ushort.MinValue,
        };
    }

    public IReadOnlyCollection<(string[] input, string[] output)> ReadCases(Problem problem, int? limit = null)
    {
        var folder = Path.Combine(_rootPath, problem.RelativePath);
        var inputs = Read(folder, Input, limit);
        var outputs = Read(folder, Output, limit);

        var size = Math.Min(inputs.Length, outputs.Length);
        var cases = new (string[] input, string[] output)[size];

        for (var i = 0; i < size; i++)
        {
            cases[i] = (inputs[i], outputs[i]);
        }

        return cases;
    }

    private const string Input = "*.in";
    private const string Output = "*.out";

    private static string[][] Read(string probleDirectory, string pattern, int? limit = null)
    {
        var files = Directory.GetFiles(probleDirectory, pattern)
            .OrderBy(path => ushort.Parse(s_testRx.Match(path).Groups["test"].Value))
            .AsEnumerable();

        if (limit.HasValue)
        {
            files = files.Take(limit.Value);
        }

        return files.Select(path => File.ReadAllLines(path)).ToArray();
    }
}
