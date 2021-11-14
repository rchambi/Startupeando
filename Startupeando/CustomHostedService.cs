using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Startupeando
{
    public class CustomHostedService : IHostedService
    {
        //si lo necesito lo uso sino lo borro
        private readonly IHostApplicationLifetime _lifetime;
        public CustomHostedService(IHostApplicationLifetime lifetime)
        {
            this._lifetime= lifetime;
            lifetime.ApplicationStarted.Register(()=> Console.WriteLine("Started"));
            lifetime.ApplicationStopping.Register(()=> Console.WriteLine("Stoppingd"));
            lifetime.ApplicationStopped.Register(()=> Console.WriteLine("Stopped"));
        }

        public Task StartAsync(CancellationToken cancellationToken1)
        {
            
            Console.WriteLine("StartAsync");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StopAsync");
            return Task.CompletedTask;
        }
        
    }
}