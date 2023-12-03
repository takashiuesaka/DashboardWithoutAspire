using System.Runtime.CompilerServices;
using Aspire.Dashboard;
using Aspire.Dashboard.Model;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();

var _loggerFactory = new LoggerFactory();

var dashboardLogger = _loggerFactory.CreateLogger<DashboardWebApplication>();

var app = new DashboardWebApplication(dashboardLogger, services =>
{
    services.AddSingleton<IDashboardViewModelService, DashboardViewModelService>();
});

await app.StartAsync(default);

var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
Console.CancelKeyPress += (sender, e) =>
{
    tcs.TrySetResult();
    e.Cancel = true;
};

await tcs.Task;

await app.StopAsync(default);

class DashboardViewModelService : IDashboardViewModelService
{
    public string ApplicationName => "My Application";

    public ValueTask<List<ContainerViewModel>> GetContainersAsync()
    {
        List<ContainerViewModel> containers = [];
        return ValueTask.FromResult(containers);
    }

    public ValueTask<List<ExecutableViewModel>> GetExecutablesAsync()
    {
        List<ExecutableViewModel> containers = [];
        return ValueTask.FromResult(containers);
    }

    public ValueTask<List<ProjectViewModel>> GetProjectsAsync()
    {
        List<ProjectViewModel> containers = [];
        return ValueTask.FromResult(containers);
    }

    public async IAsyncEnumerable<ResourceChanged<ContainerViewModel>> WatchContainersAsync(IEnumerable<NamespacedName>? existingContainers = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Task.Delay(-1, cancellationToken);

        yield break;
    }

    public async IAsyncEnumerable<ResourceChanged<ExecutableViewModel>> WatchExecutablesAsync(IEnumerable<NamespacedName>? existingExecutables = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Task.Delay(-1, cancellationToken);

        yield break;
    }

    public async IAsyncEnumerable<ResourceChanged<ProjectViewModel>> WatchProjectsAsync(IEnumerable<NamespacedName>? existingProjects = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Task.Delay(-1, cancellationToken);

        yield break;
    }

}