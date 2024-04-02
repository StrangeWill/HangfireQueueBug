using Hangfire;

namespace HangfireQueueBug;

public class HangfireJob
{
    public async Task DoWork()
    {

    }

    [Queue("priority")]
    public async Task DoWorkButAttribute()
    {

    }
}