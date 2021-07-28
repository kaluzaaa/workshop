using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace net_core_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var enumerator = Environment.GetEnvironmentVariables().GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"{enumerator.Key}: {enumerator.Value}");
            }
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}
