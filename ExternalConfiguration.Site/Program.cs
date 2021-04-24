using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExternalConfiguration.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    // var env = hostContext.HostingEnvironment;
                    // var contentRoot = env.ContentRootPath;
                    string jsonFileName = "site.json";
                    // string exterSettingFullName = System.IO.Path.Combine(contentRoot, jsonFileName);

                    // ref https://stackoverflow.com/questions/60532104/net-core-3-1-adding-additional-config-json-file-to-configuration-argument-in-st
                    config.AddJsonFile(jsonFileName, optional: true, reloadOnChange: true)
                        // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        ;
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}