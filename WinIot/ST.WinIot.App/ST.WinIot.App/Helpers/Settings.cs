using ST.WinIot.App.Connections.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Helpers
{
	class Settings
	{

		public static Tokens AuthInfos
		{
			get
			{
				return GetSetting<Tokens>();
			}
			set
			{
				SetSetting<Tokens>(value);
			}
		}

		static void SetSetting<T>(T Value, [CallerMemberName] string Name = "") {
			if (typeof(T).IsGenericType)
				Windows.Storage.ApplicationData.Current.LocalSettings.Values[Name] = Value;
			else
			{
				var json = Newtonsoft.Json.JsonConvert.SerializeObject(Value);
				Windows.Storage.ApplicationData.Current.LocalSettings.Values[Name] = json;
			}
		}
		static T GetSetting<T>([CallerMemberName] string Name = "") {
			if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey(Name) == false)
				return default(T);

			if (typeof(T).IsGenericType)
				return (T)Windows.Storage.ApplicationData.Current.LocalSettings.Values[Name];
			var json = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values[Name];
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
		}
		
	}
}
