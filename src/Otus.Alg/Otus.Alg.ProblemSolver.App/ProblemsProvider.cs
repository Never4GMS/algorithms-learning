using System.Text.RegularExpressions;

namespace Otus.Alg.ProblemSolver.App
{
    public class ProblemsProvider
    {
        private readonly string _rootPath;
        private static readonly Regex s_monthRx = new(@"month(?<month>\d+)", RegexOptions.Compiled);
        private static readonly Regex s_lessonRx = new(@"lesson(?<lesson>\d+)", RegexOptions.Compiled);

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

                problems[i] = new Problem
                {
                    Name = dirPath.Split(Path.DirectorySeparatorChar).Last(),
                    Description = File.ReadAllText(path),
                    RelativePath = Path.GetRelativePath(_rootPath, dirPath),
                    Lesson = ushort.TryParse(s_lessonRx.Match(path).Groups["lesson"].Value, out var lesson) ? lesson : ushort.MinValue,
                    Month = ushort.TryParse(s_monthRx.Match(path).Groups["month"].Value, out var month) ? month : ushort.MinValue,
                };
            }

            return problems;
        }

        public IReadOnlyCollection<(string[] input, string[] output)> ReadCases(Problem problem)
        {
            var folder = Path.Combine(_rootPath, problem.RelativePath);
            var inputs = ReadInputs(folder);
            var outputs = ReadOutputs(folder);

            var size = Math.Min(inputs.Length, outputs.Length);
            var cases = new (string[] input, string[] output)[size];

            for (var i = 0; i < size; i++)
            {
                cases[i] = (inputs[i], outputs[i]);
            }

            return cases;
        }

        private static string[][] ReadInputs(string probleDirectory) =>
            Directory.GetFiles(probleDirectory, "*.in").Select(path => File.ReadAllLines(path)).ToArray();

        private static string[][] ReadOutputs(string probleDirectory) =>
            Directory.GetFiles(probleDirectory, "*.out").Select(path => File.ReadAllLines(path)).ToArray();
    }
}
