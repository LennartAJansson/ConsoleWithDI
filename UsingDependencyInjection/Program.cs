IServiceProvider serviceProvider = CreateServiceProvider(args);

using IServiceScope? scope = serviceProvider.CreateScope();

await scope.ServiceProvider.GetRequiredService<IExecutor>().RunAsync();


//Internal methods:
static IServiceProvider CreateServiceProvider(string[] args) =>
    new ServiceCollection()
        .AddSingleton<IConfiguration>(services => CreateConfiguration(args))
        .AddLogging(builder => builder.AddConsole().AddConfiguration())
        .AddTransient<IExecutor, Executor>()
        .BuildServiceProvider();

static IConfiguration CreateConfiguration(string[] args) =>
    new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();
