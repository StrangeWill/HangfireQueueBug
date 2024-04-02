namespace HangfireQueueBug;

using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Hosting;

public class HangfireHostedService : IHostedService
{
    protected IBackgroundJobClient BackgroundJobClient { get; }

    public HangfireHostedService(IBackgroundJobClient backgroundJobClient)
    {
        BackgroundJobClient = backgroundJobClient;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        BackgroundJobClient.Enqueue<HangfireJob>("priority", h => h.DoWork());
        BackgroundJobClient.Enqueue<HangfireJob>("default", h => h.DoWorkButAttribute());
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
