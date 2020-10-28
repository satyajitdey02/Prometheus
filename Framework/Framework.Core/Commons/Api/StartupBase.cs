using System.Diagnostics;
using System.IO;
using Framework.Core.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Serilog;
using Unity;

namespace Framework.Core.Commons.Api
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

            ConfigureUnityContainer();
        }

        protected IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(Configuration)
                  .Enrich.FromLogContext()
                  .WriteTo.File($@"{Directory.GetCurrentDirectory()}\log\log.txt", rollingInterval: RollingInterval.Day)
                  .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                  .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            services.AddControllers();
            services.BuildServiceProvider();
            services.AddSingleton(Log.Logger);

            services.AddOcelot()
                .AddCacheManager(x =>
                {
                    x.WithDictionaryHandle();
                });
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

        private void ConfigureUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            _dependencyProvider.RegisterDependencies(container);
        }
    }
}