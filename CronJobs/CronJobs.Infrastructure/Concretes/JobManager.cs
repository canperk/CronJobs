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
        internal Task Start()
        {
            _options.JobList.ForEach((job) =>
            {
                Task.Factory.StartNew(async () =>
                {
                    var firstCheck = true;
                    while (true)
                    {
                        #region One Time Check
                        if (firstCheck)
                        {
                            var firstnow = DateTime.Now;
                            var firstRunTime = job.Cron.GetNextOccurrence(firstnow);
                            var diff = firstRunTime - firstnow;
                            await Task.Delay(diff);
                            firstCheck = false;
                        } 
                        #endregion

                        var j = (ICronJob)_app.ApplicationServices.GetService(job.Type);
                        await j.Invoke();

                        var now = DateTime.Now;

                        var currentTime = now.AddSeconds(-now.Second).AddMilliseconds(-now.Millisecond);
                        DateTime nextTime = DateTime.MinValue;

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
            return Task.CompletedTask;
        }
    }
}
