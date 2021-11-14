using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Startupeando
{
    public class Program
    {
        // se peude hacer async el metoto
        public static async Task Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var builer= CreateHostBuilder(args);
            var host= builer.Build();

            //////se podria hacer el migration desde aqui justo despues de ejecutar ConfigureServices()        
            
            //Si hay migration se puede descomentar esto 

            // using var scope= host.Services.CreateScope();      
            // var appDbContext= scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // appDbContext.Database.Migrate();    //tiene q tener EF ya deberia estar toda la configuracion del EF en starup o startupDevelopment

            ///

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var startupAssembly = typeof(Startup).Assembly.FullName; //Modificado 
                    webBuilder.UseStartup(startupAssembly); //Modificado 
                });
    }
}
