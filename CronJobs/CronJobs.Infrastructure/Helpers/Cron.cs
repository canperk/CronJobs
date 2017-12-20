using System;

namespace CronJobs.Infrastructure
{
    public static class Cron
    {
        #region Every {Time}
        public static string EveryMinute()
        {
            return "* * * * *";
        }
        public static string EveryHour()
        {
            return Hourly(minute: 0);
        }
        public static string EveryDay()
        {
            return Daily(hour: 0);
        }
        public static string EveryWeek()
        {
            return Weekly(DayOfWeek.Monday);
        }
        public static string EveryMonth()
        {
            return Monthly(day: 1);
        }
        public static string EveryYear()
        {
            return Yearly(month: 1);
        }
        #endregion

        #region Time Overloads
        public static string Hourly(int minute)
        {
            return $"{minute} * * * *";
        }
        public static string Daily(int hour)
        {
            return Daily(hour, minute: 0);
        }
        public static string Daily(int hour, int minute)
        {
            return $"{minute} {hour} * * *";
        }
        public static string Weekly(DayOfWeek dayOfWeek)
        {
            return Weekly(dayOfWeek, hour: 0);
        }
        public static string Weekly(DayOfWeek dayOfWeek, int hour)
        {
            return Weekly(dayOfWeek, hour, minute: 0);
        }
        public static string Weekly(DayOfWeek dayOfWeek, int hour, int minute)
        {
            return $"{minute} {hour} * * {(int)dayOfWeek}";
        }
        public static string Monthly(int day)
        {
            return Monthly(day, hour: 0);
        }
        public static string Monthly(int day, int hour)
        {
            return Monthly(day, hour, minute: 0);
        }
        public static string Monthly(int day, int hour, int minute)
        {
            return $"{minute} {hour} {day} * *";
        }
        public static string Yearly(int month)
        {
            return Yearly(month, day: 1);
        }
        public static string Yearly(int month, int day)
        {
            return Yearly(month, day, hour: 0);
        }
        public static string Yearly(int month, int day, int hour)
        {
            return Yearly(month, day, hour, minute: 0);
        }
        public static string Yearly(int month, int day, int hour, int minute)
        {
            return $"{minute} {hour} {day} {month} *";
        }
        public static string MinuteInterval(int interval)
        {
            return $"*/{interval} * * * *";
        }
        public static string HourInterval(int interval)
        {
            return $"0 */{interval} * * *";
        }
        public static string DayInterval(int interval)
        {
            return $"0 0 */{interval} * *";
        }
        public static string MonthInterval(int interval)
        {
            return $"0 0 1 */{interval} *";
        } 
        #endregion
    }
}
