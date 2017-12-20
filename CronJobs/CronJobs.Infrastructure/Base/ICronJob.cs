using System;
using System.Threading.Tasks;

namespace CronJobs.Infrastructure.Base
{
    public interface ICronJob
    {
        Guid Key { get; set; }
        Task Invoke();
    }
}
