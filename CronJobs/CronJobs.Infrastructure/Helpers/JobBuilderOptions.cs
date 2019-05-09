using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using System;
using System.Collections.Generic;

namespace CronJobs.Infrastructure
{
    public class JobBuilderOptions
    {
        private IServiceCollection services;
        private List<JobDescriptor> jobList;
        public IReadOnlyCollection<JobDescriptor> GetJobs()
        {
            return jobList.AsReadOnly();
        }
        public JobBuilderOptions(IServiceCollection services)
        {
            jobList = new List<JobDescriptor>();
            this.services = services;
        }

        public void Register<T>(string expression) where T : class, ICronJob
        {
            var cron = CrontabSchedule.TryParse(expression);
            if (cron == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(expression)} is not valid!");
            }
            services.AddTransient<T, T>();
            jobList.Add(new JobDescriptor(cron, typeof(T)));
        }
    }
}
