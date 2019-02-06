using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ST.WinIot.App.Connections
{
	public class API
	{
		Auth _auth;
		public API(Auth auth)
		{
			_auth = auth;
		}
		public Task<ApiResponse<T>> Get<T>(System.Threading.CancellationToken ct, string url, Dictionary<string, string> param)
		{
			return request<T>(ct, HttpMethod.GET, url, param);
		}
		public Task<ApiResponse<T>> Get<T>(System.Threading.CancellationToken ct, string url, object param)
		{
			return request<T>(ct, HttpMethod.GET, url, param);
		}

		public Task<ApiResponse<T>> Post<T>(System.Threading.CancellationToken ct, string url, Dictionary<string, string> param)
		{
			return request<T>(ct, HttpMethod.POST, url, param);
		}
		public Task<ApiResponse<T>> Post<T>(System.Threading.CancellationToken ct, string url, object param)
		{
			return request<T>(ct, HttpMethod.POST, url, param);
		}

		public Task<ApiResponse<T>> Put<T>(System.Threading.CancellationToken ct, string url, Dictionary<string, string> param)
		{
			return request<T>(ct, HttpMethod.PUT, url, param);
		}
		public Task<ApiResponse<T>> Put<T>(System.Threading.CancellationToken ct, string url, object param)
		{
			return request<T>(ct, HttpMethod.PUT, url, param);
		}

		public Task<ApiResponse<T>> Delete<T>(System.Threading.CancellationToken ct, string url, string Id)
		{
			if (!string.IsNullOrEmpty(Id))
				if (url.Contains('?'))
					url = url + "&id=" + HttpUtility.UrlEncode(Id);
				else
					url = url + "?id=" + HttpUtility.UrlEncode(Id);

			return request<T>(ct, HttpMethod.DELETE, url);
		}


		Task<ApiResponse<T>> request<T>(System.Threading.CancellationToken ct, HttpMethod method, string url, Dictionary<string, string> param)
		{
			return request<T>(ct, method, url, (object)param);
		}
		async Task<ApiResponse<T>> request<T>(System.Threading.CancellationToken ct, HttpMethod method, string url, object param = null)
		{
			var client = _auth.Client;
			var r = new ApiResponse<T>();
			if (client == null)
			{
				r.Success = false;
				r.Result = default(T);
				return r;
			}
			Dictionary<string, string> values;

			if (param != null)
			{
				switch (method)
				{
					case HttpMethod.DELETE:
					case HttpMethod.GET:
						if (param is Dictionary<string, string>)
							url = GetQueryString(url, param as Dictionary<string, string>);
						else
							url = GetQueryString(url, param);
						values = null;
						break;

					default:
					case HttpMethod.POST:
					case HttpMethod.PUT:

						if (param != null)
						{
							if (param is Dictionary<string, string>)
								values = param as Dictionary<string, string>;
							else
								values = GetDict(param);
						}
						else
							values = new Dictionary<string, string>();

						break;
				}

			}
			else
				values = null;

			HttpResponseMessage result;
			switch (method)
			{
				default:
				case HttpMethod.GET:
					result = await client.GetAsync(url, ct);
					break;
				case HttpMethod.POST:
					var content = new FormUrlEncodedContent(values);


					result = await client.PostAsync(url, content, ct);
					break;
				case HttpMethod.PUT:
					var cont = new FormUrlEncodedContent(values);
					result = await client.PutAsync(url, cont, ct);
					break;
				case HttpMethod.DELETE:
					result = await client.DeleteAsync(url, ct);
					break;


			}


			r.HttpStatusCode = result.StatusCode;

			if (result.IsSuccessStatusCode)
			{
				var response = await result.Content.ReadAsStringAsync();
				r.Success = true;
				r.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
				return r;
			}
			else
			{
				r.Success = false;
				r.ErrorMessage = result.ReasonPhrase;
				r.Result = default(T);
				return r;
			}

		}


		string GetQueryString(string url, Dictionary<string, string> obj)
		{
			var properties = from p in obj
							 select p.Key + "=" + HttpUtility.UrlEncode(p.Value);

			return url + (url.Contains('?') ? "&" : "?") + String.Join("&", properties.ToArray());
		}
		Dictionary<string, string> GetDict(object obj)
		{
			if (obj == null)
				return null;

			var properties = from p in obj.GetType().GetProperties()
							 where p.GetValue(obj, null) != null
							 select new KeyValuePair<string, string>(p.Name, p.GetValue(obj, null).ToString());
			if (properties != null)
				return properties.ToDictionary(o => o.Key, o => o.Value);
			return null;
		}
		string GetQueryString(string url, object obj)
		{
			var dict = GetDict(obj);
			return GetQueryString(url, dict);
		}
		public enum HttpMethod
		{
			GET,
			POST,
			PUT,
			DELETE
		}
		public class ApiResponse<T>
		{
			public T Result { get; set; }
			public bool Success { get; set; }
			public string ErrorMessage { get; set; }
			public HttpStatusCode HttpStatusCode { get; set; }
		}

	}
}
