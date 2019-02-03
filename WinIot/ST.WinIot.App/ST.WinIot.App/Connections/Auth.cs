using IdentityModel.OidcClient;
using ST.WinIot.App.Connections.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace ST.WinIot.App.Connections
{
	public class Auth
	{
		HttpClient _client;

		async Task<LoginActionResult> login() {
			var r = new LoginActionResult();
			var options = new OidcClientOptions
			{
				Authority = ST.Web.Config.Urls.OAuthUrl,
				ClientId = ST.Web.Config.App.ClientId,
				Scope = "openid profile " + ST.Web.Config.General.SmartHomeApiScope_Id,
				RedirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().AbsoluteUri,

				Browser = new WabBrowser(enableWindowsAuthentication: false)
			};

			var client = new OidcClient(options);
			var result = await client.LoginAsync(new LoginRequest());
			r.LoginResult = result;

			if (!string.IsNullOrEmpty(result.Error))
			{
				//ResultTextBox.Text = result.Error;
				r.ErrorMessage = result.Error;
				r.Succes = false;
				return r;
			}

			//var sb = new StringBuilder(128);

			//foreach (var claim in result.User.Claims)
			//{
			//	sb.AppendLine($"{claim.Type}: {claim.Value}");
			//}

			//sb.AppendLine($"refresh token: {result.RefreshToken}");
			//sb.AppendLine($"access token: {result.AccessToken}");

			r.Succes = true;

			_client = new HttpClient(result.RefreshTokenHandler);
			_client.BaseAddress = new Uri("https://demo.identityserver.io/");

			return r;
		}
		public class LoginActionResult {
			public bool Succes { get; set; }
			public string ErrorMessage { get; set; }
			public LoginResult LoginResult { get; set; }

		}
	}
}
