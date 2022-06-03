using TaskManagement.Core.Common;
using System;

namespace TaskManagement.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToLocalDateTime(this DateTime date, int timezone)
        {
            return date.AddMinutes(-timezone);
        }
      

        public static DateTime ToLocalDateTime(this DateTime? date, int timezone)
        {
            return date.Value.AddMinutes(-timezone);
        }

        public static string GetTime(this DateTime dateTime)
        {
            return dateTime.ToString(Constants.DateTimeFormat.Hour);
        }

    }
}
