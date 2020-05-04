using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.Configure<KestrelServerOptions>(
                context.Configuration.GetSection("Kestrel"));
        })
        //.ConfigureAppConfiguration((_, config) => config.AddJsonFile("appsettings.json"))
        .ConfigureWebHostDefaults(webBuilder =>
        {
            //webBuilder.UseKestrel();
            //webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
            //webBuilder.UseIISIntegration();
            webBuilder.UseStartup<Startup>();
            //webBuilder.UseKestrel(options => { options.Listen(IPAddress.Loopback, 44555); });

        });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder().UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureLogging(factory =>
            {
                factory.AddConsole()
                .AddDebug();
            })
            //.ConfigureAppConfiguration((_, config) => config.AddJsonFile("appsettings.json"))
            .UseIISIntegration()
            .UseKestrel()
            .UseStartup<Startup>();

    }
}
