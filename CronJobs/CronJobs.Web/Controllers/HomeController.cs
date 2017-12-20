using CronJobs.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CronJobs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobBuilderOptions _options;

        public HomeController(JobBuilderOptions options)
        {
            _options = options;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jobs()
        {
            var jobs = _options.GetJobs();
            var vm = new List<JobViewModel>();
            foreach (var item in jobs)
            {
                vm.Add(new JobViewModel
                {
                    Id = item.Id.ToString(),
                    Cron = item.Cron.ToString(),
                    Name = item.Type.FullName,
                    ScheduledTimes = item.Cron.GetNextOccurrences(DateTime.Now, DateTime.Now.AddDays(1)).Select(i => i.ToString("dd/MM/yyyy HH:mm")).Take(10).ToList()
                });
            }
            return View(vm);
        }
    }
}
