﻿using CronJobs.Infrastructure;
using System;
using System.IO;
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
            using (var writer = new StreamWriter($"{nameof(SimpleJob)}.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString());
            }
            return Task.CompletedTask;
        }
    }
}
