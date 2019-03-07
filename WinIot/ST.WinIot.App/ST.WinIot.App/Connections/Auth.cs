using IdentityModel.OidcClient;
using ST.WinIot.App.Connections.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace ST.WinIot.App.Connections
{
	public class Auth : INotifyPropertyChanged
	{
		HttpClient _client;
		OidcClient _oidcClient;
		Tokens _token;

		IdentityModel.OidcClient.Results.UserInfoResult _userInfo;
		public delegate void UserInfoChangedDelegate(Auth sender, IdentityModel.OidcClient.Results.UserInfoResult UserInfo);
		public event UserInfoChangedDelegate UserInfoChanged;
		public IdentityModel.OidcClient.Results.UserInfoResult UserInfo
		{
			get => _userInfo;
			private set
			{
				_userInfo = value;
				OnPropertyChanged();
				UserInfoChanged?.Invoke(this, value);

			}
		}



		public Tokens Token { get => _token; }
		public HttpClient Client { get => _client; }
		public async Task<AuthResult> LoginOrReconnect()
		{
			var r = await reconnect();
			if (!r.Succes)
				r = await login();
			

			return new AuthResult
			{
				Succes = r.Succes,
				ErrorMessage = r.ErrorMessage
			};
		}
		public async Task LogOut()
		{
			if (_oidcClient != null)
				await _oidcClient.LogoutAsync(new LogoutRequest());
			_oidcClient = null;
			UserInfo = null;
			_token = null;

		}

		OidcClientOptions GetOptions() =>
			new OidcClientOptions
			{
				Authority = ST.Web.Config.Urls.OAuthUrl,
				ClientId = ST.Web.Config.App.ClientId,
				Scope = "openid profile " + ST.Web.Config.General.SmartHomeApiScope_Id,
				RedirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().AbsoluteUri,

				Browser = new WabBrowser(enableWindowsAuthentication: false)
			};

		async Task<LoginActionResult> reconnect()
		{
			var r = new LoginActionResult();


			var client = new OidcClient(GetOptions());
			var result = await client.RefreshTokenAsync(Helpers.Settings.AuthInfos.RefreshToken);
			if (!string.IsNullOrEmpty(result.Error))
			{
				r.Succes = false;
				r.ErrorMessage = result.Error;
				return r;
			}
			_oidcClient = client;
			UserInfo = await client.GetUserInfoAsync(result.AccessToken);



			r.LoginResult = new Tokens
			{
				AccesToken = result.AccessToken,
				ExpireIn = result.AccessTokenExpiration,
				CreatedAt = DateTime.Now,
				RefreshToken = result.RefreshToken
			};
			_token = r.LoginResult;
			Helpers.Settings.AuthInfos = r.LoginResult;

			return r;
		}
		async Task<LoginActionResult> login()
		{
			var r = new LoginActionResult();


			var client = new OidcClient(GetOptions());
			var result = await client.LoginAsync(new LoginRequest());
			r.LoginResult = new Tokens
			{
				AccesToken = result.AccessToken,
				ExpireIn = result.AccessTokenExpiration,
				CreatedAt = DateTime.Now,
				RefreshToken = result.RefreshToken
			};

			if (!string.IsNullOrEmpty(result.Error))
			{
				//ResultTextBox.Text = result.Error;
				r.ErrorMessage = result.Error;
				r.Succes = false;
				return r;
			}

			_token = r.LoginResult;
			_oidcClient = client;
			UserInfo = await client.GetUserInfoAsync(result.AccessToken);

			//var sb = new StringBuilder(128);

			//foreach (var claim in result.User.Claims)
			//{
			//	sb.AppendLine($"{claim.Type}: {claim.Value}");
			//}

			//sb.AppendLine($"refresh token: {result.RefreshToken}");
			//sb.AppendLine($"access token: {result.AccessToken}");
			Helpers.Settings.AuthInfos = r.LoginResult;
			r.Succes = true;

			_client = new HttpClient(result.RefreshTokenHandler);
			_client.BaseAddress = new Uri("https://demo.identityserver.io/");

			return r;
		}
		//INotifyPropertyChanged Implementation
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		protected void RaisePropertyChange(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		class LoginActionResult
		{
			public bool Succes { get; set; }
			public string ErrorMessage { get; set; }
			public Tokens LoginResult { get; set; }

		}
		public class AuthResult
		{
			public bool Succes { get; set; }
			public string ErrorMessage { get; set; }
		}
	}
}
