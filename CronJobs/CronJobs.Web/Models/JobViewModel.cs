using System.Collections.Generic;

namespace CronJobs.Web
{
    public class JobViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cron { get; set; }
        public List<string> ScheduledTimes { get; set; }
    }
}
