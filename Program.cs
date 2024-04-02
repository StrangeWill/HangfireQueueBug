
using Hangfire;
using Hangfire.Redis.StackExchange;
using HangfireQueueBug;

var builder = WebApplication.CreateBuilder(args);
void addQueue(string queue, int? count = null)
{
    builder!.Services.AddHangfireServer(o =>
    {
        o.Queues = new[] { queue };
        if (count.HasValue)
        {
            o.WorkerCount = count.Value;
        }
    });
}

addQueue("default");
addQueue("priority");
builder.Services
    .AddHangfire(o => o
        .UseRedisStorage("127.0.0.1:6379,password=testing", new RedisStorageOptions { InvisibilityTimeout = TimeSpan.FromHours(12) })
        .WithJobExpirationTimeout(TimeSpan.FromHours(24))
    )
    .AddHostedService<HangfireHostedService>();

var app = builder.Build();
app.UseHttpsRedirection()
    .UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        Authorization = new[] { new HangfireAuthorizationFilter() },
        DisplayStorageConnectionString = false
    });
await app.RunAsync();