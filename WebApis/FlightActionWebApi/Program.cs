using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Unity.Microsoft.DependencyInjection;

namespace FlightActionWebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider()
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
