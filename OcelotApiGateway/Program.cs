using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Unity.Microsoft.DependencyInjection;

namespace OcelotApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((host, config) => { config.AddJsonFile(Path.Combine("configuration", "configuration.json")); })
                .UseUnityServiceProvider()
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
