using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ST.Web.Angular
{
  public class Program
  {
    internal static IConfiguration Configuration { get; private set; }
    public static void SetStaticConfig(IConfiguration config) {
      Configuration = config;
    }
    public static void Main(string[] args)
    {
      var builder = CreateWebHostBuilder(args).Build();
      
      builder.Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseIISIntegration()
            .UseStartup<Startup>();
  }
}
