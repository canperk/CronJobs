# CronJobs

You can use this project to create scheduled jobs in your ASP.NET Core web projects. Scheduled jobs are designed like Linux based Cron Jobs with star ( * ) template. For example if you wanna run a schedule job you should define you schedule template like * * * * or you can run a task on every start of hours by using 0 1 * * * 

These templates are defined in functions to use immediately like CronJob.EveryMinute()


Dependencies:

.NET Core
