internal class Executor : IExecutor
{
    private readonly ILogger<Executor> logger;
    private readonly IServiceScopeFactory scopeFactory;

    public Executor(ILogger<Executor> logger, IServiceScopeFactory scopeFactory)
    {
        this.logger = logger;
        this.scopeFactory = scopeFactory;
    }

    public async Task RunAsync()
    {
        using IServiceScope? scope = scopeFactory.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ISubExecutor>().RunAsync();
        logger.LogInformation("Running");
    }
}