

using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;

namespace ST.WinIot.App.Web.Service
{
    public class TimeZoneHelper
    {

        public static string TimeZoneIdToResourceName(string Id)
        {
            return Id.Replace(" ", "_").Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace("+", "");
        }
        public static string GetLocalisedTimeZoneName(string TimeZoneId)
        {
            return TimeZones.ResourceManager.GetString(TimeZoneIdToResourceName(TimeZoneId));
        }
        public static IEnumerable<KeyValuePair<string, string>> GetTimeZones()
        {
            return from e in TimeZoneInfo.GetSystemTimeZones()
                   select new KeyValuePair<string, string> ( e.Id, GetLocalisedTimeZoneName(e.Id));

        }
        public static TimeZoneInfo GetTimeZoneInfo(string Id)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(Id);
        }

        public static DateTime ConvertToTimeZone(string TimeZoneId, DateTime UtcDateTime)
        {
            var tz = GetTimeZoneInfo(TimeZoneId);
            var result = TimeZoneInfo.ConvertTimeFromUtc(UtcDateTime, tz);
            return result;
        }

        //public static DateTime GetUtcFromShopTime(Shop shop, DateTime ShopTime)
        //{
        //    return TimeZoneInfo.ConvertTimeToUtc(ShopTime, Helper.TimeZoneHelper.GetTimeZoneInfo(shop.TimeZoneId));
        //}
        public static DateTime GetUtcFromUserTime(DateTime dt, double timeZoneOffset)
        {
            
            return DateTime.SpecifyKind(dt.ToOffset(TimeSpan.FromMinutes(-timeZoneOffset)), DateTimeKind.Utc);
            //return TimeZoneInfo.ConvertTimeToUtc(UserTime, Helper.TimeZoneHelper.GetTimeZoneInfo(shop.TimeZoneId));
        }
        //public static DateTime GetShopTimeFromUTC(Shop shop, DateTime UTCTime)
        //{
        //    return ConvertToTimeZone(shop.TimeZoneId, UTCTime);
        //}
        //public static DateTime GetTimeFromUTC(CompanyShop.Interfaces.ITimeZoneId TimeZoneId, DateTime UTCTime)
        //{
        //    return ConvertToTimeZone(TimeZoneId.TimeZoneId, UTCTime);
        //}
        

        public static string LocalisedDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Friday:
                    return DayOfWeekTranslation.Friday;
                case DayOfWeek.Monday:
                    return DayOfWeekTranslation.Monday;
                case DayOfWeek.Saturday:
                 return DayOfWeekTranslation.Saturday;
                case DayOfWeek.Sunday:
                 return DayOfWeekTranslation.Sunday;
                case DayOfWeek.Thursday:
                 return DayOfWeekTranslation.Thursday;
                case DayOfWeek.Tuesday:
                    return DayOfWeekTranslation.Tuesday;
                case DayOfWeek.Wednesday:
                    return DayOfWeekTranslation.Wednesday;
                default:
                    return "";
            }
        }
        static IEnumerable<KeyValuePair<string, int>> GetEnumValues<Tenum>(ResourceManager resourceManager,bool tryNameInRessource = false)
        {
            var r = new List<KeyValuePair<string, int>>();
            Array values = Enum.GetValues(typeof(Tenum));

            foreach (var val in values)
            {
                var name = Enum.GetName(typeof(Tenum), val);
                var value = (int)val;
                if (tryNameInRessource)
                {
                    var res = resourceManager.GetString(name);
                    if (res.HasValue())
                        name = res;
                }
                r.Add(new KeyValuePair<string, int>(name, value));
                //Console.WriteLine(String.Format("{0}: {1}", Enum.GetName(typeof(Tenum), val), val));
            }
            return r;
        }

        //public static IEnumerable<SelectBootStrapItem> DayOfWeekSelect() {
        //    var lst = new List<SelectBootStrapItem>();
        //    foreach (var item in GetEnumValues<DayOfWeek>())
        //    {
        //        var value = (DayOfWeek)item.Value;
        //        lst.Add(new SelectBootStrapItem { Text = LocalisedDayOfWeek(value), Value = item.Value.ToString() });
        //    }
        //    return lst.OrderBy(o => o.Value);
        //}
    }
}