using ST.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.Angular
{
    [ApiModel]
    public class MyAngularConfig
    {
        public string ClientId { get => Program.Configuration["AngularConfig:AuthClientId"]; }
        public string AuthServer { get => Config.Urls.OAuthUrl; }
        public string Scope { get { return $"openid profile {Config.General.SmartHomeApiScope_Id}"; } }
        public string ApiServer { get => Config.Urls.ApiUrl; }

    }
}
