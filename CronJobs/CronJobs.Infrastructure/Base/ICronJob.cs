using System;
using System.Threading.Tasks;

namespace CronJobs.Infrastructure
{
    public interface ICronJob
    {
        Guid Key { get; set; }
        Task Invoke();
    }
}
