using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.Dynamic;
using System.Net.Sockets;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Html;
using System.Web;
using System.Threading.Tasks;
using System.Resources;
using System.Security.Cryptography;

namespace System
{
    public partial class CS
    {
        public static string GetPlainTextFromHtml(string html)
        {
            if (html.IsNullOrEmpty())
                return "";
            html = WebUtility.HtmlDecode(html);
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            var tagToDelete = from node in document.DocumentNode.DescendantsAndSelf()
                              where node.Name.ToLower() == "style" || node.Name.ToLower() == "script"
                              select node;
            if (tagToDelete.HasValue())
            {
                var toDelete = tagToDelete.ToList();
                foreach (var node in toDelete)
                    node.Remove();
            }

            return document.DocumentNode.InnerText;
        }
        //public class Url : Helper.baseCSUrl { }
       
        public class PropertyMapper<T>
        {
            public virtual PropertyInfo PropertyInfo<U>(Expression<Func<T, U>> expression)
            {
                var member = expression.Body as MemberExpression;
                if (member != null && member.Member is PropertyInfo)
                    return member.Member as PropertyInfo;

                throw new ArgumentException("Expression is not a Property", "expression");
            }

            public virtual string PropertyName<U>(Expression<Func<T, U>> expression)
            {
                return PropertyInfo<U>(expression).Name;
            }

            public virtual Type PropertyType<U>(Expression<Func<T, U>> expression)
            {
                return PropertyInfo<U>(expression).PropertyType;
            }
        }
        public class ClaimsTypes
        {
            public const string isSocialLogin = "IsSocialLogin";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";

            public const string FacebookAccessToken = "FacebookAccessToken";
            public const string FacebookUserId = "FacebookUserId";

            public const string GoogleAccessToken = "GoogleAccessToken";
            public const string GoogleUserId = "GoogleUserId";



            public const string PaypalUserId = "PaypalUserId";
            public const string PaypalAccessToken = "PaypalAccessToken";

            public const string Address_Country = "Address_Country";
            public const string Address_City = "Address_City";
            public const string Address_PostalCode = "Address_PostalCode";
            public const string Address_State = "Address_State";
            public const string Address_StreetAddress = "Address_StreetAddress";
            public const string Email = "Email";
            public const string Phone = "Phone";

        }
        public static long GetJavascriptTimestamp(System.DateTime input)
        {
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = input.Subtract(span);
            return (long)(time.Ticks / 10000);
        }

        public static string AssemblyVersion(bool usePoint = true, bool FullVersion = true)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (!FullVersion)
            {
                var v = version.LastIndexOf(".");
                version = version.Substring(0, v);
            }
            if (usePoint)
                return version;
            else
                return version.Replace('.', '_');
        }
        public static string AssemblyVersionChangeSet(bool usePoint = true)
        {
            var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var version = v.Major.ToString() + "." + v.Minor.ToString() + "." + v.Build.ToString()  + " Build " + v.Revision.ToString();
            if (usePoint)
                return version;
            else
                return version.Replace('.', '_').Replace(" Build ", "_B");
        }

        public class Dynamic
        {
            public static bool Has(object obj, string propertyName)
            {
                var dynamic = obj as DynamicObject;
                if (dynamic == null) return false;
                return dynamic.GetDynamicMemberNames().Contains(propertyName);
            }
            public static bool Has(DynamicObject obj, string propertyName)
            {

                if (obj == null) return false;
                return obj.GetDynamicMemberNames().Contains(propertyName);
            }
        }
        public class Request
        {
            /// <summary>
            /// A class to lookup whois information.
            /// </summary>
            public class Whois
            {
                public enum RecordType { domain, nameserver, registrar };

                /// <summary>
                /// retrieves whois information
                /// </summary>
                /// <param name="domainname">The registrar or domain or name server whose whois information to be retrieved</param>
                /// <param name="recordType">The type of record i.e a domain, nameserver or a registrar</param>
                /// <returns>The string containg the whois information</returns>
                public static string lookup(string domainname, RecordType recordType)
                {
                    List<string> res = lookup(domainname, recordType, "whois.internic.net");
                    string result = "";
                    foreach (string st in res)
                    {
                        result += st + "\n";
                    }
                    return result;
                }        /// <summary>
                         /// retrieves whois information
                         /// </summary>
                         /// <param name="domainname">The registrar or domain or name server whose whois information to be retrieved</param>
                         /// <param name="recordType">The type of record i.e a domain, nameserver or a registrar</param>
                         /// <param name="returnlist">use "whois.internic.net" if you dont know whoisservers</param>
                         /// <returns>The string list containg the whois information</returns>
                public static List<string> lookup(string domainname, RecordType recordType, string whois_server_address)
                {
                    if (whois_server_address == "")
                        whois_server_address = "whois.internic.net";
                    TcpClient tcp = new TcpClient();
                    tcp.Connect(whois_server_address, 43);
                    string strDomain = recordType.ToString() + " " + domainname + "\r\n";
                    byte[] bytDomain = Encoding.ASCII.GetBytes(strDomain.ToCharArray());
                    Stream s = tcp.GetStream();
                    s.Write(bytDomain, 0, strDomain.Length);
                    StreamReader sr = new StreamReader(tcp.GetStream(), Encoding.ASCII);
                    string strLine = "";
                    List<string> result = new List<string>();
                    while (null != (strLine = sr.ReadLine()))
                    {
                        result.Add(strLine);
                    }
                    tcp.Close();
                    return result;
                }
            }
            //public static System.Web.HttpRequestBase GetBase(System.Web.HttpRequest Request)
            //{
            //    if (Request == null)
            //        return null;
            //    return (new HttpRequestWrapper(Request).RequestContext.HttpContext.Request);
            //}

            //public static bool IsBot(System.Web.HttpRequest Request)
            //{
            //    return IsBot(new HttpRequestWrapper(Request));
            //}
            //public static bool IsBot(System.Web.HttpRequestBase Request)
            //{
            //    if (Request.Browser.Crawler) return true;

            //    var myUserAgent = Request.UserAgent != null ? Request.UserAgent.ToLower() : "";


            //    return IsBot(myUserAgent);


            //}
            public static bool IsBot(string myUserAgent)
            {

                myUserAgent = myUserAgent.ToLower();


                var myArray = new String[] {"bingbot","adidxbot", "bingpreview", "yahoo","yahooseeker", "java/", "teoma", "alexa", "froogle", "gigabot",
   "inktomi", "looksmart", "url_spider_sql", "firefly", "nationaldirectory",
   "ask jeeves", "tecnoseek", "infoseek", "webfindbot", "girafabot",  "crawler",
   "www.galaxy.com", "googlebot", "scooter", "slurp", "msnbot", "appie", "fast",
   "webbug", "spade", "zyborg", "rabaz", "baiduspider", "feedfetcher-google",
   "technoratisnoop", "rankivabot", "mediapartners-google", "sogou web spider",
   "webalta crawler", "facebookexternalhit"};
                foreach (var item in myArray)
                {
                    if (myUserAgent.Contains(item)) return true;
                }

                return false;
            }
            

            
            }
            

           
           

            //public static string GetBody(HttpRequest Request)
            //{

            //    string msg = "";
            //    try
            //    {


            //        using (StreamReader reader = new StreamReader(Request.Body.InputStream))
            //        {
            //            try
            //            {
            //                Request.InputStream.Position = 0;
            //                msg = reader.ReadToEnd();


            //            }
            //            catch (Exception ex)
            //            {

            //                //log errors
            //            }
            //            finally
            //            {
            //                Request.InputStream.Position = 0;
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {


            //    }
            //    return msg;

            //}
            public static string GetForm(HttpRequest Request)
            {
                string msg = "";

                try
                {
                    if (Request.Form.Count > 0)
                        foreach (var item in Request.Form.Keys)
                        {
                            msg += item + "=" + Request.Form[item] + Environment.NewLine;
                        }


                }
                catch (Exception)
                {

                    //log errors
                }
                finally
                {

                }

                return msg;

            }
            //public static string GetRequestInfo(System.Web.HttpRequest Request)
            //{ return GetRequestInfo(GetBase(Request)); }
            //public static string GetRequestInfo(System.Web.HttpRequestBase Request)
            //{
            //    if (Request == null)
            //        return "";
            //    var sb = new StringBuilder();
            //    if (Request != null)
            //    {
            //        sb.Append("[Headers] :" + Environment.NewLine + GetHeaders(Request) + Environment.NewLine);
            //        sb.Append("[UserAgent] :" + Environment.NewLine + (Request.UserAgent.IsNullOfEmpty() ? "{NULL}" : Request.UserAgent) + Environment.NewLine);
            //        sb.Append("[IP] :" + Environment.NewLine + CS.GetClientIpAddress(Request) + Environment.NewLine);
            //        sb.Append("[BODY] : " + Environment.NewLine + GetBody(Request) + Environment.NewLine);
            //        sb.Append("[FORM] : " + Environment.NewLine + GetForm(Request));
            //    }
            //    return sb.ToString();
            //}


        //}
        public static bool Success = true;
        public static bool GetResolvedConnecionIPAddress(string serverNameOrURL, out IPAddress resolvedIPAddress)
        {
            bool isResolved = false;
            IPHostEntry hostEntry = null;
            IPAddress resolvIP = null;
            try
            {
                if (!IPAddress.TryParse(serverNameOrURL, out resolvIP))
                {
                    hostEntry = Dns.GetHostEntry(serverNameOrURL);

                    if (hostEntry != null && hostEntry.AddressList != null && hostEntry.AddressList.Length > 0)
                    {
                        if (hostEntry.AddressList.Length == 1)
                        {
                            resolvIP = hostEntry.AddressList[0];
                            isResolved = true;
                        }
                        else
                        {
                            foreach (IPAddress var in hostEntry.AddressList)
                            {
                                if (var.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    resolvIP = var;
                                    isResolved = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    isResolved = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                resolvedIPAddress = resolvIP;
            }

            return isResolved;
        }
        
        public static string JqGridActionBtnCls(string GridId)
        { return "actionBtn" + GridId; }
        public static string ToAbsoluteUrl(HttpContext httpContext, string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            if (httpContext == null)
                return relativeUrl;

            if (relativeUrl.StartsWith("/"))
                relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/"))
                relativeUrl = relativeUrl.Insert(0, "~/");

            var url = httpContext.Request.Uri();
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

            return String.Format("{0}://{1}{2}{3}",
                url.Scheme, url.Host, port, relativeUrl.Replace("~/", "/"));
        }
        public static string RemoveQueryString(string url)
        {
            if (url.IsNullOrEmpty())
                return "";
            var s = url.DirectSplit("?", StringSplitOptions.RemoveEmptyEntries);
            return s[0];
        }
        public static IDisposable SetInterval(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };

            timer.Enabled = true;
            timer.Start();

            // Returns a stop handle which can be used for stopping
            // the timer, if required
            return timer as IDisposable;
        }

     

        public static IDisposable SetTimeout(Action method, int delayInMilliseconds)
        {
            System.Timers.Timer timer = new System.Timers.Timer(delayInMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };

            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();

            // Returns a stop handle which can be used for stopping
            // the timer, if required
            return timer as IDisposable;
        }
        public static string ValidId(string OriginalId)
        {
            return Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.CreateSanitizedId(OriginalId, "_");
        }
        public static HtmlString JShtmlString(string str) { return HttpUtility.JavaScriptStringEncode(str).ToMvcHtmlString(); }
        public static string JSstring(string str) { return HttpUtility.JavaScriptStringEncode(str); }
        public static string JSdateFormat(string cSharpDateFormat)
        {
            return cSharpDateFormat.Replace("yy", "y").Replace("YY", "Y").Replace('M', 'm');
        }
        
             public static string GoogleDayOfWeek(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Friday:
                    return "Fr";

                case DayOfWeek.Monday:
                    return "Mo";

                case DayOfWeek.Saturday:
                    return "Sa";

                case DayOfWeek.Sunday:
                    return "Su";

                case DayOfWeek.Thursday:
                    return "Th";

                case DayOfWeek.Tuesday:
                    return "Tu";

                case DayOfWeek.Wednesday:
                    return "We";
                default:
                    break;
            }
            return "";
        }
        //public static string CreateGoogleOpenHoursJson(IEnumerable<Services.Models.ShopOpenHour> h, IEnumerable<Services.Models.ShopOpenHourException> ex)
        //{
        //    var openingHours = "";
        //    var OpeningHoursSpecification = "";
        //    if (h.HasValue())
        //    {
        //        var times = new List<String>();
        //        foreach (var hour in h.OrderBy(o => o.DayOfWeek))
        //        {
        //            if (hour.ClosedForLunch && hour.LunchTime.HasValue && hour.LunchDuration.HasValue)
        //            {

        //                var startTime = GoogleDayOfWeek((DayOfWeek)hour.DayOfWeek) + " " + DisplayTime(hour.OpenTime, "en") + "-" + DisplayTime(hour.LunchTime.Value, "en");
        //                var endTime = GoogleDayOfWeek((DayOfWeek)hour.DayOfWeek) + " " +
        //                    DisplayTime(hour.LunchTime.Value.Add(new TimeSpan(0, hour.LunchDuration.Value, 0)), "en") + "-" + DisplayTime(hour.CloseTime, "en");
        //                times.Add("\"" + startTime + "\"");
        //                times.Add("\"" + endTime + "\"");
        //                //var end = DisplayTime(lunchTime.Add(new TimeSpan(0, lunchDuration, 0)), LangId) + " " + to + " " + DisplayTime(endHour, LangId);
        //                //return new string[] { start, end };
        //            }
        //            else
        //            {
        //                var time = GoogleDayOfWeek((DayOfWeek)hour.DayOfWeek) + " " + DisplayTime(hour.OpenTime, "en") + "-" + DisplayTime(hour.CloseTime, "en");
        //                times.Add("\"" + time + "\"");
        //            }
        //        }
        //        openingHours = ",\"openingHours\":[" + string.Join(",", times) + "]";
        //    }
        //    if (ex.HasValue())
        //    {
        //        var exs = new List<string>();
        //        foreach (var item in ex)
        //        {
        //            var date = item.Date.Value.Year + "-" + item.Date.Value.Month + "-" + item.Date.Value.Month;
        //            var str = "{\"@type\": \"OpeningHoursSpecification\",";
        //            str += "\"validFrom\": \"" + date + "\",\"validThrough\": \"" + date + "\"";
        //            if (!item.Closed && item.OpenHour.HasValue && item.CloseHour.HasValue)
        //            {
        //                str += ",\"opens\": \"" + CS.DisplayTime(item.OpenHour.Value, "en") + "\",";
        //                str += "\"closes\": \"" + CS.DisplayTime(item.CloseHour.Value, "en") + "\"";

        //            }

        //            str += "}";
        //            exs.Add(str);
        //        }
        //        if (exs.Count > 1)
        //            OpeningHoursSpecification = ",\"openingHoursSpecification\":[" + string.Join(",", exs) + "]";
        //        else
        //            OpeningHoursSpecification = ",\"openingHoursSpecification\":" + exs.First();
        //    }
        //    return openingHours + OpeningHoursSpecification;
        //}

    

        //public static string GetClientIpAddress(HttpRequestBase request)
        //{
        //    try
        //    {
        //        var userHostAddress = request.UserHostAddress;

        //        // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
        //        // Could use TryParse instead, but I wanted to catch all exceptions
        //        IPAddress.Parse(userHostAddress);

        //        var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

        //        if (string.IsNullOrEmpty(xForwardedFor))
        //            return GetIP4Address(request);

        //        // Get a list of public ip addresses in the X_FORWARDED_FOR variable
        //        var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

        //        // If we found any, return the last one, otherwise return the user host address
        //        return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
        //    }
        //    catch (Exception)
        //    {
        //        // Always return all zeroes for any failure (my calling code expects it)
        //        return "0.0.0.0";
        //    }
        //}
        //public static string GetClientIpAddress(HttpContext httpContext)
        //{
        //    try
        //    {
        //        HttpRequest request = httpContext.Request;

        //        var userHostAddress = httpContext.Features.Get<Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature>()?.RemoteIpAddress.MapToIPv4().ToString();
                
        //        // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
        //        // Could use TryParse instead, but I wanted to catch all exceptions
                

        //        var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

        //        if (string.IsNullOrEmpty(xForwardedFor))
        //            return GetIP4Address(CS.Request.GetBase(request));

        //        // Get a list of public ip addresses in the X_FORWARDED_FOR variable
        //        var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

        //        // If we found any, return the last one, otherwise return the user host address
        //        return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
        //    }
        //    catch (Exception)
        //    {
        //        // Always return all zeroes for any failure (my calling code expects it)
        //        return "0.0.0.0";
        //    }
        //}

        public static string GetIP4Address(HttpContext httpContext)
        {
            string IP4Address = String.Empty;
            
            foreach (IPAddress IPA in Dns.GetHostAddresses(httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        private static bool IsPrivateIpAddress(string ipAddress)
        {
            // http://en.wikipedia.org/wiki/Private_network
            // Private IP Addresses are: 
            //  24-bit block: 10.0.0.0 through 10.255.255.255
            //  20-bit block: 172.16.0.0 through 172.31.255.255
            //  16-bit block: 192.168.0.0 through 192.168.255.255
            //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }
        public static string ReverseDNS(String IP)
        {
            System.Net.IPAddress adresseIP = System.Net.IPAddress.Parse(IP);

            try
            {
                System.Net.IPHostEntry GetIpHOST = System.Net.Dns.GetHostEntry(adresseIP);
                return GetIpHOST.HostName;
            }
            catch
            {
                //Si ca marche pas, on retourne l'adresse IP
                return adresseIP.ToString();
            }
        }
        public static async Task<string> ReverseDNSAsync(String IP)
        {
            System.Net.IPAddress adresseIP = System.Net.IPAddress.Parse(IP);

            try
            {
                System.Net.IPHostEntry GetIpHOST = await System.Net.Dns.GetHostEntryAsync(adresseIP);
                return GetIpHOST.HostName;
            }
            catch
            {
                //Si ca marche pas, on retourne l'adresse IP
                return adresseIP.ToString();
            }
        }
        public static string DisplayTime(TimeSpan time, string LangId)
        {
            if (LangId == "fr")
            {
                return time.Hours.ToString() + "h" + (time.Minutes > 0 ? time.Minutes.ToString("D2") : "");
            }
            return time.Hours.ToString() + ":" + time.Minutes.ToString("D2");
        }
        public static string[] LunchTime(TimeSpan openHour, TimeSpan endHour, TimeSpan lunchTime, int lunchDuration, string LangId)
        {
            var to = LangId == "fr" ? "à" : "to";
            var start = DisplayTime(openHour, LangId) + " " + to + " " + DisplayTime(lunchTime, LangId);
            var end = DisplayTime(lunchTime.Add(new TimeSpan(0, lunchDuration, 0)), LangId) + " " + to + " " + DisplayTime(endHour, LangId);
            return new string[] { start, end };
        }

        public static IEnumerable<KeyValuePair<string, int>> GetEnumValues<Tenum>(bool tryNameInRessource = false, ResourceManager resourceManager = null)
        {
            var r = new List<KeyValuePair<string, int>>();
            Array values = Enum.GetValues(typeof(Tenum));

            foreach (var val in values)
            {
                var name = Enum.GetName(typeof(Tenum), val);
                var value = (int)val;
                if (tryNameInRessource && resourceManager != null)
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
        public static IEnumerable<KeyValuePair<string, long>> GetEnumLongValues<Tenum>(bool tryNameInRessource = false, ResourceManager resourceManager = null)
        {
            var r = new List<KeyValuePair<string, long>>();
            Array values = Enum.GetValues(typeof(Tenum));

            foreach (var val in values)
            {
                var name = Enum.GetName(typeof(Tenum), val);
                var value = (long)val;
                if (tryNameInRessource && resourceManager != null)
                {
                    var res = resourceManager.GetString(name);
                    if (res.HasValue())
                        name = res;
                }
                r.Add(new KeyValuePair<string, long>(name, value));
                //Console.WriteLine(String.Format("{0}: {1}", Enum.GetName(typeof(Tenum), val), val));
            }
            return r;
        }
        public class GetEnumDetailledValuesResult<Tenum>
        {
            /// <summary>
            /// The int value of the enum
            /// </summary>
            public int NumericValue { get; set; }
            /// <summary>
            /// The Name of the enum. Ex. for DayOfWeek.Monday it will return "DayOfWeek"
            /// </summary>
            public string EnumTypeName { get; set; }
            /// <summary>
            /// The Name of the enum value. Ex. for DayOfWeek.Monday it will return "Monday"
            /// </summary>
            public string EnumValueName { get; set; }
            /// <summary>
            /// The raw value of the enum
            /// </summary>
            public Tenum EnumValue { get; set; }
            
        }
        public static IEnumerable<GetEnumDetailledValuesResult<Tenum>> GetEnumDetailledValues<Tenum>()
        {
            var r = new List<GetEnumDetailledValuesResult<Tenum>>();
            Array values = Enum.GetValues(typeof(Tenum));

            foreach (var val in values)
            {
                var name = Enum.GetName(typeof(Tenum), val);
                var value = (int)val;

                r.Add(new GetEnumDetailledValuesResult<Tenum>
                {
                    EnumTypeName = typeof(Tenum).Name,
                    EnumValueName = name,
                    NumericValue = value,
                    EnumValue = (Tenum)val
                });
                //Console.WriteLine(String.Format("{0}: {1}", Enum.GetName(typeof(Tenum), val), val));
            }
            return r;
        }
     
        public static string GetReturnUrl(HttpRequest Request)
        {
            return Request.RawUrl();
        }

        public static string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.Unicode.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.ASCIIEncoding.Unicode.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static DateTime GetLastSousContractantPaye()
        {
            var n = DateTime.Now;
            DateTime T;
            if (n.Day > 15)
                T = new DateTime(n.Year, n.Month, 15, 0, 0, 0);
            else
                T = new DateTime(n.Year, n.Month, 1, 0, 0, 0);
            return T.ToUniversalTime();
        }

        static Random rnd = new Random();
        public class Cryptography
        {
            static readonly char[] AvailableLetters = {
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            static readonly char[] AvailableSymbols = {
    '|', '!', '"', '/', '$', '%', '?', '&', '*', '(', ')', '-', '_',
    '=', '+', '[', ']', '{', '}', ';', ':', '\\'};
            static readonly char[] AvailableNumbers = {
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            static readonly char[] AvailableCharacters = {
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_', '.',
    '~', '@', '*','$'

  };
            static readonly char[] AvailableUrlCharacters = {
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
                                                             };
            public static string GenerateIdentifier(int length, bool ForUrl = false)
            {
                char[] identifier = new char[length];
                byte[] randomData = new byte[length];
                var availableCharacters = ForUrl ? AvailableUrlCharacters : AvailableCharacters;
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(randomData);
                }

                for (int idx = 0; idx < identifier.Length; idx++)
                {
                    int pos = randomData[idx] % availableCharacters.Length;
                    identifier[idx] = availableCharacters[pos];
                }

                return new string(identifier);
            }
            public static string GeneratePassword(int minLength)
            {
                var ret = GenerateIdentifier(minLength);
                var lsts = new List<char>();
                lsts.Add(AvailableLetters[rnd.Next(AvailableLetters.Length)]);
                lsts.Add(AvailableLetters[rnd.Next(AvailableLetters.Length)].ToString().ToLower().ToCharArray()[0]);
                lsts.Add(AvailableNumbers[rnd.Next(AvailableNumbers.Length)]);
                lsts.Add(AvailableSymbols[rnd.Next(AvailableSymbols.Length)]);
                lsts.Add(AvailableLetters[rnd.Next(AvailableLetters.Length)]);

                lsts.Add(AvailableLetters[rnd.Next(AvailableLetters.Length)].ToString().ToLower().ToCharArray()[0]);
                lsts.Add(AvailableNumbers[rnd.Next(AvailableNumbers.Length)]);
                lsts.Add(AvailableSymbols[rnd.Next(AvailableSymbols.Length)]);
                lsts.Shuffle_List();
                ret += new string(lsts.ToArray());

                lsts.Clear();

                lsts.AddRange(ret.ToCharArray());
                lsts.Shuffle_List();

                return new string(lsts.ToArray());

            }
        }

        //public class CustomActionResult
        //{
        //    public static ActionResult MissingParameter(BaseController controller, string RedirectUrlIfNotBot = null)
        //    {
        //        if (Request.IsBot(controller.Request))
        //            return new HttpStatusCodeResult(422);
        //        if (RedirectUrlIfNotBot.IsNullOfEmpty())
        //            return new HttpStatusCodeResult(404);
        //        return controller.RedirectToLocal(RedirectUrlIfNotBot);
        //    }
        //}
    }
}
