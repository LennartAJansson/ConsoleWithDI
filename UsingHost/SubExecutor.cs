internal class SubExecutor : ISubExecutor
{
    private readonly ILogger<SubExecutor> logger;

    public SubExecutor(ILogger<SubExecutor> logger) => this.logger = logger;

    public Task RunAsync()
    {
        logger.LogInformation("Running");
        return Task.CompletedTask;
    }
}