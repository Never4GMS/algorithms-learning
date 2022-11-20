BenchmarkSwitcher
    .FromAssembly(typeof(Program).Assembly)
    .Run(args, GetGlobalConfig());

static IConfig GetGlobalConfig() =>
    (IsDebug() ? new DebugBuildConfig() : DefaultConfig.Instance)
        .AddJob(Job.Dry
            .RunOncePerIteration()
            .WithWarmupCount(0)
            .WithIterationTime(Perfolizer.Horology.TimeInterval.Millisecond * 500)
            .WithToolchain(InProcessEmitToolchain.Instance)
            .WithId("InProcess")
            .AsDefault());

static bool IsDebug()
{
#if DEBUG
    return true;
#else
    return false;
#endif
}
