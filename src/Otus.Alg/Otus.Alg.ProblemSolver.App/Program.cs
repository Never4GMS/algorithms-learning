var rootPath = args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) ? args[0] : "data";
const int indent = 2;

if (!Path.IsPathRooted(rootPath))
{
    rootPath = Path.Combine(Environment.CurrentDirectory, rootPath);
}

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Добро пожаловать в решения для курса \"Алгоритмы и структуры данных\"");
Console.ResetColor();

var container = new ServiceCollection()
    .Scan(scan => scan.FromAssemblyOf<IProblemSolver>()
        .AddClasses(classes => classes.AssignableTo<IProblemSolver>()
        .WithAttribute<ProblemAttribute>())
        .AsSelf()
        .WithTransientLifetime())
    .BuildServiceProvider();
var index = Problems.BuildIndexFromAssembleOf<IProblemSolver>();

try
{
    var provider = new ProblemsProvider(rootPath);
    var problems = provider.ReadProblems();

    var action = AppAction.None;
    Problem problem = null;
    do
    {
        action = ReadAction();

        switch (action)
        {
            case AppAction.Index:
                DisplayIndex(problems);
                break;

            case AppAction.Problem:
                problem = Select(problems);
                goto case AppAction.Solve;

            case AppAction.Search:
                problem = Search(problems);
                goto case AppAction.Solve;

            case AppAction.Solve:
                if (problem != null)
                {
                    Display(problem);
                    var cases = provider.ReadCases(problem);
                    Solve(cases, problem);
                    SpaceToContinue();
                }
                break;

            case AppAction.Exit:
                Console.WriteLine("До скорых встреч!");
                break;
        }
    }
    while (action != AppAction.Exit);
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Ошибка: {ex.Message}");
    Console.ResetColor();
}

void Solve(IReadOnlyCollection<(string[] input, string[] output)> cases, Problem problem)
{
    if (index.TryGetValue(Problems.CreateKey(problem), out var type) &&
        container.GetRequiredService(type) is IProblemSolver solver)
    {
        var watch = new Stopwatch();
        var i = 0;

        foreach (var (input, output) in cases)
        {
            watch.Restart();
            var result = solver.SolveProblem(input);
            watch.Stop();

            var isOk = Problems.IsSolvedCorrect(result, output, out var index);

            Console.ForegroundColor = isOk ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"[{isOk}]".ToUpper());
            Console.ResetColor();
            Console.WriteLine($"{i++}: [input:{input.Length}, output:{output.Length}] => {watch.Elapsed}");
            if (!isOk)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ошибка на позиции {index}.");
                Console.WriteLine($"Ввод: {input[index]}");
                Console.WriteLine($"Результат: {result[index]}");
                Console.WriteLine($"Ожидания: {output[index]}");
                Console.ResetColor();
            }
        }

        return;
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Не найден код решения для проблемы: {problem}");
    Console.ResetColor();
}

Problem Search(IReadOnlyCollection<Problem> problems)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"Поиск: ");
        Console.ResetColor();

        var namePart = Console.ReadLine();

        if (!string.IsNullOrEmpty(namePart))
        {
            var results = problems
                .Where(p => p.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

            if (results.Length > 1)
            {
                Console.WriteLine($"Найдено {results.Length} проблемы:");

                foreach (var result in results) Console.WriteLine(result.Name);

                Console.WriteLine("Уточните запрос...");

                continue;
            }

            if (results.Length == 1) return results[0];
        }
    }
}

void Display(Problem problem)
{
    Console.WriteLine($"Проблема \"{problem.Name}\"");
    Console.WriteLine(problem.Description);
}

Problem Select(IReadOnlyCollection<Problem> problems)
{
    Problem? problem = null;

    do
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"Месяц: ");
        Console.ResetColor();

        if (ushort.TryParse(Console.ReadLine(), out var month))
        {
            var count = problems.Where(p => p.Month == month).Count();
            Console.WriteLine($"Найдено {count} проблем...");
            if (count == 0) continue;
        }
        else
        {
            continue;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"Урок: ");
        Console.ResetColor();

        if (ushort.TryParse(Console.ReadLine(), out var lesson))
        {
            var count = problems.Where(p => p.Month == month && p.Lesson == lesson).Count();
            Console.WriteLine($"Найдено {count} проблем...");
            if (count == 0) continue;
        }
        else
        {
            continue;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"Задача: ");
        Console.ResetColor();

        var namePart = Console.ReadLine();

        if (!string.IsNullOrEmpty(namePart))
        {
            problem = problems
                .Where(p => p.Month == month
                    && p.Lesson == lesson
                    && p.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();
        }

        if (problem == null) Console.WriteLine("Найдено 0 проблем...");
    }
    while (problem == null);

    return problem;
}

static void SpaceToContinue()
{
    Console.WriteLine("Нажмите [пробел] для продолжения...");
    while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
}

static void DisplayIndex(IReadOnlyCollection<Problem> problems)
{
    var orderedProblems = problems.OrderBy(p => p.Month).ThenBy(p => p.Lesson);

    ushort currentMonth = 0;
    ushort currentLesson = 0;

    foreach (var problem in orderedProblems)
    {
        if (problem.Month != currentMonth)
        {
            currentMonth = problem.Month;
            Console.WriteLine($"Месяц #{currentMonth}");
        }

        if (problem.Lesson != currentLesson)
        {
            currentLesson = problem.Lesson;
            Console.WriteLine($"{new string(' ', indent)}|-Урок #{currentLesson}");
        }

        Console.WriteLine($"{new string(' ', indent * 2)}|-{problem.Name}");
    }
}

static AppAction ReadAction()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Что хотите сделать?");
        Console.WriteLine($"{new string(' ', indent)}[1] Вывести индекс");
        Console.WriteLine($"{new string(' ', indent)}[2] Выбор решения проблемы");
        Console.WriteLine($"{new string(' ', indent)}[3] Поиск решения");
        Console.WriteLine($"{new string(' ', indent)}[4] Выход");
        Console.ResetColor();

        var input = Console.ReadKey(true);
        switch (input.Key)
        {
            case ConsoleKey.D1:
                return AppAction.Index;

            case ConsoleKey.D2:
                return AppAction.Problem;

            case ConsoleKey.D3:
                return AppAction.Search;

            case ConsoleKey.Escape:
            case ConsoleKey.D4:
                return AppAction.Exit;
        }
    }
}
