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
            return String.Format("{0} days ago", (Math.Ceiling(dateNow.Subtract(date).TotalDays)));
        }

        /// <summary>
        /// Returns formated datetime string. Performs null check and returns value.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="toLocal">The toLocal datetime flag.</param>
        /// <param name="format">The format.</param>
        /// <param name="nullReturn">The null return.</param>
        /// <returns>Formated datetime string. Performs null check and returns value.</returns>
        public static string ToNullableDateTimeString(this DateTime? date, bool toLocal = true, string format = "dd/MM/yyyy", string nullReturn = "")
        {
            if (date.HasValue)
            {
                if (string.IsNullOrEmpty(format))
                    return toLocal ? date.Value.ToLocalTime().ToShortDateString() : date.Value.ToShortDateString();
                else
                    return toLocal ?  date.Value.ToLocalTime().ToString(format) : date.Value.ToString(format);
            }

            return String.IsNullOrEmpty(nullReturn) ? "" : nullReturn;
        }

        /// <summary>
        /// Returns a specified label based on due date expireing. 
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="warningDays">Days before due date to recive warning.</param>
        /// <param name="warningLabel">The warning label.</param>
        /// <param name="expireLabel">The expire label.</param>
        /// <returns>The specified label based on due date expireing. </returns>
        public static string ToDueDateWarningString(this DateTime? date, int warningDays = 2, string warningLabel = "warning", string expireLabel = "alert")
        {
            if (date.HasValue)
            {
                if (date.Value <= DateTime.UtcNow)
                    return expireLabel ?? "alert";

                if (date.Value.AddDays(warningDays) >= DateTime.UtcNow)
                    return warningLabel ?? "warning";
            }

            return null;
        }
    }
}
