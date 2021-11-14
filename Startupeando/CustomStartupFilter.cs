using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Startupeando
{
    public class CustomStartupFilter :IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>{
                // //caso migration
                // ApplyMigration(app);
                next(app);
                //que se ejecuta despues del configure
            };
        }

        private void ApplyMigration(IApplicationBuilder app)
        {
            using var scope= app.ApplicationServices.CreateScope();      
            var appDbContext= scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // appDbContext.Database.Migrate();    //tiene q tener EF ya deberia estar toda la configuracion del EF en starup o startupDevelopment
        }
    }
    
    public class AppDbContext{}
}
