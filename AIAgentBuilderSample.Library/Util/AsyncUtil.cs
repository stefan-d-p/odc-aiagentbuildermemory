namespace Without.Systems.AIAgentBuilderSample.Util;

public static class AsyncUtil
{
    private static readonly TaskFactory taskFactory = new TaskFactory(
        CancellationToken.None,
        TaskCreationOptions.None,
        TaskContinuationOptions.None,
        TaskScheduler.Default);

    public static TResult RunSync<TResult>(Func<Task<TResult>> task) =>
        taskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();

    public static void RunSync(Func<Task> task) =>
        taskFactory.StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
}