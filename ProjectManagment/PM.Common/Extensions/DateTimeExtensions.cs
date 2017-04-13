using System;

namespace PM.Common.Extensions
{
    /// <summary>
    /// DateTime extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Formats the DateTime to pretty string: [11:25, yesterday, 4 days ago]
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Formated DateTime.</returns>
        public static string ToPrettyDateTimeString(this DateTime date)
        {
            var dateNow = DateTime.UtcNow;
            // today
            if (date.Year == dateNow.Year && date.Month == dateNow.Month && date.Day == dateNow.Day)
                return date.ToShortTimeString();

            // yesterday
            if (date.Year == dateNow.Year && date.Month == dateNow.Month && date.Day == dateNow.Day - 1)
                return "yesterday";

            // longer than yesterday.
            return String.Format("{0} days ago", (int)dateNow.Subtract(date).TotalDays);
        }
    }
}
