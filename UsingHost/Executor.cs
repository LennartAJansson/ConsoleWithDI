using Microsoft.Extensions.Logging;

internal class Executor : IExecutor
{
    private readonly ILogger<Executor> logger;

    public Executor(ILogger<Executor> logger) => this.logger = logger;
    public Task RunAsync()
    {
        logger.LogInformation("Running");
        return Task.CompletedTask;
    }
}