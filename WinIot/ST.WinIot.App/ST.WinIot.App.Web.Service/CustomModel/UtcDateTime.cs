
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST.Web.Service.CustomModel
{
    [ModelBinder(BinderType = typeof(UtcDateTimeModelBinder))]
    public class UtcDateTime
    {
        public UtcDateTime() { }
        public UtcDateTime(DateTime UtcDate)
        {
            Date = UtcDate;
        }
        public UtcDateTime(string UtcDate) {
            if (UtcDate.EndsWith("Z") == false)
                UtcDate = string.Concat(UtcDate, "Z");
            var date = DateTime.Parse(UtcDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
            Date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }
        public DateTime Date { get; private set; }

        public static UtcDateTime FromLocalTime(DateTime localDate) {
            return new UtcDateTime(localDate.ToUniversalTime());
        }
        public static UtcDateTime FromUtcTime(DateTime utcTime) {
            return new UtcDateTime(DateTime.SpecifyKind(utcTime, DateTimeKind.Utc));
        }

        /// <summary>
        /// Return the formated ISO 8601 string (yyyy-MM-ddTHH:mm:ssZ)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Date.ToString("o");
        }
    }
}
