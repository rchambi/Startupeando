using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Startupeando.Services;

namespace Startupeando.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class httpContextController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGreetingService _service;

        public httpContextController(ILogger<WeatherForecastController> logger,IGreetingService service)
        {
            _logger = logger;
            _service= service;
        }


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("1- Ready to start");

                await Task.Delay(TimeSpan.FromSeconds(5), token);
                ///llamando al servicio con el httpContext                                
                return Ok(_service.Greeting());

            }
            catch (TaskCanceledException)
            {
                _logger.LogInformation("Task was cancelled");
                return BadRequest();
            }

        }

    }
}
