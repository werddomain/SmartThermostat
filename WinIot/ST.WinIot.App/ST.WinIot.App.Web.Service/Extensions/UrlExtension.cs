using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ST.WinIot.App.Web.Service
{
    public static class UrlExtension
    {
        // e.g. https
        public static string Protocol(this Uri Url)
        {
            return Url.Scheme;
        }

       

        // e.g. https://pavey.azurewebsites.net/debug/?x=1&y=2
        public static string UrlHttps(this Uri Url)
        {
            
            return string.Format("https://{0}{1}", Url.Host, Url.PathAndQuery);
        }

        // e.g. http://pavey.azurewebsites.net/debug/?x=1&y=2
        public static string UrlHttp(this Uri Url)
        {
            return string.Format("https://{0}{1}", Url.Host, Url.PathAndQuery);
        }

        // e.g. true if value is formatted as a valid IPv4 address
        public static bool IsValidIPAddress(this string Value)
        {
            return Regex.Match(Value, "\\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\b").Success;
        }

        // e.g. true if testing using an IP address instead of a fully qualified host name
        public static bool IsIPAddress(this Uri Url)
        {
            return Url.Host.IsValidIPAddress();
        }

        // e.g. true if testing using localhost
        public static bool IsLocalHost(this Uri Url)
        {
            return Url.Host.ToLower().Equals("localhost");
        }

        // e.g. dev.www
        public static List<string> SubDomains(this Uri Url)
        {
            // variables
            string[] MyArray = Url.Host.Split(".".ToCharArray());
            List<string> MySubDomains = new List<string>();

            // make sure this is not an ip address
            if (Url.IsIPAddress())
            {
                return MySubDomains;
            }

            // make sure we have all the parts necessary
            if (MyArray == null)
            {
                return MySubDomains;
            }

            // last part is the tld (e.g. .com)
            // second to last part is the domain (e.g. mydomain)
            // the remaining parts are the sub-domain(s)
            if (MyArray.Length > 2)
            {
                for (int i = 0; i <= MyArray.Length - 3; i++)
                {
                    MySubDomains.Add(MyArray[i]);
                }
            }

            // return
            return MySubDomains;
        }
        /// <summary>
        /// This will give all posible subdomain+domain list. Exemple of www.subdomain.domain.com: {www.subdomain.domain.com,subdomain.domain.com, domain.com}
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static List<string> ListAllSubDomain(this Uri Url)
        {
            var host = Url.Host;
            List<string> MySubDomains = new List<string>();
            MySubDomains.Add(host);
            var parts = host.DirectSplit(".");
            for (int i = 0; i < parts.Length - 2; i++)
            {
                host = host.Replace(parts[i] + ".", "");
                MySubDomains.Add(host);
            }
            return MySubDomains;
        }
        // e.g. www
        public static string SubDomain(this Uri Url)
        {
            if (Url.SubDomains().Count > 0)
            {
                // handle cases where multiple sub-domains (e.g. dev.www)
                return Url.SubDomains().Last();
            }
            else
            {
                // handle cases where no sub-domains
                return string.Empty;
            }
        }

        // e.g. azurewebsites.net
        public static string Domain(this Uri Url)
        {
            // variables
            string[] MyArray = Url.Host.Split(".".ToCharArray());

            // make sure this is not an ip address
            if (Url.IsIPAddress())
            {
                return string.Empty;
            }

            // special case for localhost
            if (Url.IsLocalHost())
            {
                return Url.Host.ToLower();
            }

            // make sure we have all the parts necessary
            if (MyArray == null)
            {
                return string.Empty;
            }

            // make sure we have all the parts necessary
            if (MyArray.Length > 1)
            {
                return string.Format("{0}.{1}", MyArray[MyArray.Length - 2], MyArray[MyArray.Length - 1]);
            }

            // return empty string
            return string.Empty;
        }

        // e.g. https://pavey.azurewebsites.net/
        //public static string BaseUrl(this Uri Url)
        //{
        //    // variables
        //    string Authority = Url.GetLeftPart(UriPartial.Authority).TrimStart('/').TrimEnd('/');
        //    string ApplicationPath = ApplicationPath.TrimStart('/').TrimEnd('/');

        //    // add trailing slashes if necessary
        //    if (Authority.Length > 0)
        //    {
        //        Authority += "/";
        //    }

        //    if (ApplicationPath.Length > 0)
        //    {
        //        ApplicationPath += "/";
        //    }

        //    // return
        //    return string.Format("{0}{1}", Authority, ApplicationPath);
        //}

        // e.g. default, default.aspx
        public static string PageName(this Uri Url, bool IncludeExtension = false, bool IncludeQueryString = false)
        {
            // variables
            string AbsolutePath = Url.AbsolutePath;
            string PageName = Path.GetFileName(AbsolutePath);
            string Extension = Path.GetExtension(AbsolutePath);
            string QueryString = Url.Query;

            // remove extension
            if (!IncludeExtension && !IncludeQueryString && PageName.HasValue())
            {
                PageName = PageName.Replace(Extension, string.Empty);
            }

            // include querystring
            if (IncludeQueryString && PageName.HasValue() && QueryString.HasValue())
            {
                PageName = string.Format("{0}?{1}", PageName, QueryString);
            }

            // return
            return PageName;
        }
    }
}
