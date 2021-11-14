using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Startupeando
{
    public class Startup
    {
        // public Startup(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }

        // public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



        // //-----------configuracion por ambiente ex ConfigureDevelopmentServices-> sino existe va a ConfigureServices -----
        // public void ConfigureDevelopmentServices(IServiceCollection services)
        // {
        //     services.AddControllers();
        // }


        // //---------------configuracion por ambiente ex ConfigureDevelopment-------------------

        // public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        // {

        //     ApplyMigration();
        //     app.UseDeveloperExceptionPage();

        //     app.UseHttpsRedirection();

        //     app.UseRouting();

        //     app.UseAuthorization();

        //     app.UseEndpoints(endpoints =>
        //     {
        //         endpoints.MapControllers();
        //     });
        // }
        // private void ApplyMigration()
        // {
        //     //Aqui estaria la migracion EF
        //     throw new NotImplementedException();
        // }
    }
}
