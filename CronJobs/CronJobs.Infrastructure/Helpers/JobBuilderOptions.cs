using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using System;
using System.Collections.Generic;

namespace CronJobs.Infrastructure
{
    public class JobBuilderOptions
    {
        private IServiceCollection _services;
        internal List<JobDescriptor> JobList { get; }
        public IReadOnlyCollection<JobDescriptor> GetJobs()
        {
            return JobList.AsReadOnly();
        }
        public JobBuilderOptions(IServiceCollection services)
        {
            JobList = new List<JobDescriptor>();
            _services = services;
        }

        public void Register<T>(string expression) where T : class, ICronJob
        {
            var cron = CrontabSchedule.TryParse(expression);
            if (cron == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(expression)} is not valid!");
            }
            _services.AddTransient<T, T>();
            JobList.Add(new JobDescriptor(cron, typeof(T)));
        }
    }
}
