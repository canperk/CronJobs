using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CronJobs.Infrastructure
{
    internal class JobManager
    {
        private JobBuilderOptions _options;
        private IApplicationBuilder _app;
        public JobManager(JobBuilderOptions options, IApplicationBuilder app)
        {
            _options = options;
            _app = app;
        }
        internal async Task Start()
        {
            _options.JobList.ForEach((job) =>
            {
                Task.Factory.StartNew(async () =>
                {
                    while (true)
                    {
                        var j = (ICronJob)_app.ApplicationServices.GetService(job.Type);
                        await j.Invoke();
                        var currentTime = DateTime.Now.AddSeconds(-DateTime.Now.Second);
                        DateTime nextTime = DateTime.Now;
                        var nextJobTimes = job.Cron.GetNextOccurrences(currentTime, DateTime.MaxValue);
                        foreach (var next in nextJobTimes)
                        {
                            nextTime = next;
                            break;
                        }
                        var waitTime = nextTime - currentTime;
                        await Task.Delay(waitTime);
                    }
                });
            });
            await Task.CompletedTask;
        }
    }
}
