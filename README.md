# Startupeando
mejor uso de los Startup en Net core

configuracion por ambiente 
Múltiples Startups
IStartupFilter 
IHostedService

crear clases de Startups x ambiente y sacar los if de Startup x ambiente
configurar progam.cs -->CreateHostBuilder
crear clase 
    CustomStartupFilter
injectar en startupDevelopment 
    services.AddTransient<IStartupFilter, CustomStartupFilter>();
    services.AddHostedService<CustomHostedService>();
agregar CustomHostedService,
modificaiones en program


backgroundService implementa IHostedService
variables de entorno-- si no tiene toma desde las variables de entorno
