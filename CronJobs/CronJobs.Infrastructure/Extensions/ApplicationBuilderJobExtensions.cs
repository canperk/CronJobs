using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CronJobs.Infrastructure.Extensions
{
    public static class ApplicationBuilderJobExtensions
    {
        public static void UseJobServer(this IApplicationBuilder builder)
        {
            var options = builder.ApplicationServices.GetService<JobBuilderOptions>();
            var jobServer = new JobManager(options, builder);
            jobServer.Start();
        }
    }
}
