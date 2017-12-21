using NCrontab;
using System;
using System.Collections.Generic;

namespace CronJobs.Infrastructure
{
    public class JobBuilderOptions
    {
        internal List<JobDescriptor> JobList { get; }
        public IReadOnlyCollection<JobDescriptor> GetJobs()
        {
            return JobList.AsReadOnly();
        }
        public JobBuilderOptions()
        {
            JobList = new List<JobDescriptor>();
        }

        public void Register<T>(string expression) where T : ICronJob
        {
            var cron = CrontabSchedule.TryParse(expression);
            if (cron == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(expression)} is not valid!");
            }



            JobList.Add(new JobDescriptor(cron, typeof(T)));
        }
    }
}
