
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Text;


namespace ST.WinIot.App.Web.Service
{
    public static class RouteDictionaryExtensuibs
    {
        public static string ToQueryString(this RouteValueDictionary dict)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dict)
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value);
                sb.Append("&");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        public static string ToAttributsString(this RouteValueDictionary dict)
        {
            string customAttr = "";
            foreach (var item in dict)
            {
                if (item.Value != null && item.Value.ToString() != "")
                {
                    if (item.Key.Contains("data_"))
                        customAttr += item.Key.Replace("data_", "data-") + "=\"" + item.Value.ToString() + "\" ";
                    else
                        customAttr += item.Key + "=\"" + item.Value.ToString() + "\" ";
                }
            }
            return customAttr.Trim();
        }
        public static void AddOrAppend(this RouteValueDictionary dict, string key, string value, string spacer = " ")
        {
            if (dict.ContainsKey(key))
            {
                var oValue = dict[key];
                oValue += spacer + value;
                dict[key] = oValue;
            }
            else
                dict.Add(key, value);
        }
        public static RouteValueDictionary Clone
   (this RouteValueDictionary original) 
        {
            RouteValueDictionary ret = new RouteValueDictionary();
            foreach (var entry in original)
            {
                ret.Add(entry.Key, entry.Value);
            }
            return ret;
        }
        public static RouteValueDictionary FixUnderScore(this RouteValueDictionary dict)
        {
            RouteValueDictionary ret = new RouteValueDictionary();
            foreach (var entry in dict)
            {
                ret.Add(entry.Key.Replace("_", "-"), entry.Value);
            }
            return ret;
        }
    }
}