
using System.Text;


namespace System
{
    public static class DateExtension
    {
        public static DateTime GetSundayBefore(this DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                return DateTime.MinValue;
            }
            switch (value.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return value.AddDays(-5);
                case DayOfWeek.Monday:
                    return value.AddDays(-1);
                case DayOfWeek.Saturday:
                    return value.AddDays(-6);
                case DayOfWeek.Sunday:
                    return value;
                case DayOfWeek.Thursday:
                    return value.AddDays(-4);
                case DayOfWeek.Tuesday:
                    return value.AddDays(-2);
                case DayOfWeek.Wednesday:
                    return value.AddDays(-3);
                default:
                    return value;
            }
        }
        public static DateTime GetSundayAfter(this DateTime value)
        {
            
            return value.GetSundayBefore().AddDays(7);
        }

        public static DateTime GetFirstSundayOfMonth(this DateTime value)
        {
            return value.GetFirstDayOfMonth().GetSundayBefore();
        }
        public static DateTime GetFirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }
        public static DateTime GetLastDayOfMonth(this DateTime value)
        {
            return value.GetFirstDayOfMonth().AddMonths(1).AddDays(-1);
        }
        public static bool InSameWeek(this DateTime value, DateTime compareTo)
        {
            if (value.GetSundayBefore() == compareTo.GetSundayBefore())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool InSameMonth(this DateTime value, DateTime compareTo)
        {
            if (value.GetFirstDayOfMonth() == compareTo.GetFirstDayOfMonth())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsBusinessDay(this DateTime date)
        {
            return
                date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday;
        }
        public static int BusinessDaysTo(this DateTime fromDate, DateTime toDate,
                                         int maxAllowed = 0)
        {
            int ret = 0;
            DateTime dt = fromDate;
            while (dt < toDate)
            {
                if (dt.IsBusinessDay()) ret++;
                if (maxAllowed > 0 && ret == maxAllowed) return ret;
                dt = dt.AddDays(1);
            }
            return ret;
        }

        public static DateTime AddBusinessDays(this DateTime instance, int days)
        {
            var newDate = instance;
            while (days > 0)
            {
                newDate = newDate.AddDays(1);
                if (newDate.IsBusinessDay())
                    --days;
            }
            return newDate;
        }

        /// <summary>
        /// Converts the value of the current DateTime object to the date and time specified by an offset value.
        /// </summary>
        /// <param name="dt" />DateTime value.</param>
        /// <param name="offset" />The offset to convert the DateTime value to.</param>
        /// <returns>DateTime value that is local to an offset.</returns>
        public static DateTime ToOffset(this DateTime dt, TimeSpan offset)
        {
            try
            {
return dt.Add(offset);
            }
            catch (Exception)
            {
                return dt; 
               
            }
            
           
        }
       
       
        public static string ToMonthName(this DateTime dateTime)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }

        
        //CS.GetJavascriptTimestamp
        public static long ToJavascriptTimestamp(this DateTime input)
        {
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = input.Subtract(span);
            return (long)(time.Ticks / 10000);
        }
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static double GetMomentJsTicks(this DateTime dateTime)
        {
            return dateTime.Subtract(Epoch).TotalMilliseconds;
        }



    }
}
