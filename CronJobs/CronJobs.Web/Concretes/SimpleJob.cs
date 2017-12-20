using CronJobs.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CronJobs.Web.Concretes
{
    public class SimpleJob : ICronJob
    {
        public SimpleJob()
        {
            Key = Guid.NewGuid();
        }
        public Guid Key { get; set; }

        public Task Invoke()
        {
            return Task.CompletedTask;
        }
    }
}
