using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWheelOfFateInfrastructure.Extensions
{
    public static class DatetimeExtensions
    {
        public static IEnumerable<DateTime> GetNextWorkingDays(this DateTime start, int numberOfDays)
        {
            start = SkipWeekend(start);

            DateTime yieldedDate = start;
            for(int i = 0; i < numberOfDays; i++)
            {
                yield return yieldedDate;
                yieldedDate = yieldedDate.AddDays(1);
                yieldedDate = SkipWeekend(yieldedDate);
            }
        }

        private static DateTime SkipWeekend(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday)
            {
                return dateTime.AddDays(2);
            }

            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return dateTime.AddDays(1);
            }

            return dateTime;
        }
    }
}
