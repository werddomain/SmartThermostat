using System;

namespace ST.WinIot.App.Web.Config
{
    public class Urls
    {
        public const string Host = "dev.kazo.ca";
        public const string HttpSheme = "https";

        public const string ApiUrl = HttpSheme + "://" + Host + "/API";
        public const string UiUrl = HttpSheme + "://" + Host;
        public const string OAuthUrl = HttpSheme + "://" + Host + "/Auth";
        public const string SignalRUrl = HttpSheme + "://" + ApiUrl + "/Signalr";
    }
}
