IHost host = CreateHostBuilder(args).Build();

await host.StartAsync(); //Behövs egentligen inte eftersom vi inte använder hosten i detta fallet

using IServiceScope? scope = host.Services.CreateScope();

await scope.ServiceProvider.GetRequiredService<IExecutor>().RunAsync();

await host.StopAsync(); //Behövs egentligen inte eftersom vi inte använder hosten i detta fallet


//Internal methods:
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices(services => services
            .AddTransient<IExecutor, Executor>()
            .AddTransient<ISubExecutor, SubExecutor>());
