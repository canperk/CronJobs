using NCrontab;
using System;

namespace CronJobs.Infrastructure
{
    public class JobDescriptor
    {
        public Guid Id { get; }
        public CrontabSchedule Cron { get; }
        public Type Type { get; }

        public JobDescriptor(CrontabSchedule cron, Type type)
        {
            Id = Guid.NewGuid();
            Cron = cron ?? throw new ArgumentNullException(nameof(cron));
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}