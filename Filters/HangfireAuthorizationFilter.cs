namespace HangfireQueueBug;

using Hangfire.Dashboard;
public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public HangfireAuthorizationFilter()
    {
    }

    public bool Authorize(DashboardContext context) => true;

}