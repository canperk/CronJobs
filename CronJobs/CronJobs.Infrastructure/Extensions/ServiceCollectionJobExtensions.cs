using Microsoft.Extensions.DependencyInjection;
using System;

namespace CronJobs.Infrastructure.Extensions
{
    public static class ServiceCollectionJobExtensions
    {
        public static IServiceCollection AddJobServer(this IServiceCollection services, Action<JobBuilderOptions> setup)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setup == null)
            {
                throw new ArgumentNullException(nameof(setup));
            }

            var opts = new JobBuilderOptions(services);
            setup?.Invoke(opts);
            services.AddSingleton(opts);

            return services;
        }
    }
}
