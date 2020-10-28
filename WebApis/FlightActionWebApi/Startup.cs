using FlightActionWebApi.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightActionWebApi
{
    public class Startup : Framework.Core.Commons.Api.StartupBase
    {
        private static string ApiTitle => "Flight Action Web Api";

        public Startup(IConfiguration configuration) : base(configuration, new UnityDependencyProvider(), ApiTitle)
        {

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ApiTitle,
                    Version = "v1",
                    Description = $"Api list for {ApiTitle}"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("../swagger/v1/swagger.json", $"{ApiTitle} - Services"));
        }
    }
}
