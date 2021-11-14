using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Startupeando.Services;

namespace Startupeando
{
    public class StartupDevelopment
    {
        // public StartupDevelopment(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }

        // public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, CustomStartupFilter>();
            services.AddTransient<IGreetingService, GreetingService>();
            services.AddHostedService<CustomHostedService>();
            services.AddControllers();
            ////cuando se usa httpcontext -tema3
            services.AddHttpContextAccessor();
        }

        //agregacioon de IHostApplicationLifetime
         public void Configure(IApplicationBuilder app /*, IHostApplicationLifetime lifetime*/)
        {          
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
