using System;
using System.Diagnostics;
using System.IO;
using Framework.Core.IoC;
using Framework.Core.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Unity;
using Unity.Lifetime;
using Log = Serilog.Log;

namespace Framework.Core.Base.Api
{
    public abstract class StartupBase
    {
        private readonly IDependencyProvider _dependencyProvider;
        private readonly string _apiTitle;

        protected StartupBase(IConfiguration configuration, IDependencyProvider dependencyProvider, string apiTitle)
        {
            _dependencyProvider = dependencyProvider;
            _apiTitle = apiTitle;

            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();
            services.BuildServiceProvider();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.File($@"{Directory.GetCurrentDirectory()}\log\log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            services.AddSingleton(Log.Logger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // ReSharper disable once UnusedMember.Global
        // Called on run time
        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterFactory<IConfiguration>(m =>
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppSettings.json", false, true)
                    .AddJsonFile($"AppSettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                    .AddEnvironmentVariables()
                    .Build();

                return configuration;
            }, new SingletonLifetimeManager());

            container.RegisterType<IProLogger, ProLogger>();

            _dependencyProvider.RegisterDependencies(container);
        }
    }
}