using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Connections.Identity
{
	class Tokens
	{
		public string AccesToken { get; set; }
		public string RefreshToken { get; set; }
		public DateTime? ExpireIn { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
