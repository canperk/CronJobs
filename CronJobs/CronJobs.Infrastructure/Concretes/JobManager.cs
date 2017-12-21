using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
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
            return Task.Factory.StartNew(() => {
                while (true)
                {
                    _options.JobList.ForEach((job) => {
                        var j = (ICronJob)_app.ApplicationServices.GetService(job.Type);
                        j.Invoke();
                    });
                }
            });
        }
    }
}
