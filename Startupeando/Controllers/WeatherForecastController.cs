using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Startupeando.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // ============================ uso de  CancellationToken=======//
        [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        public async Task<IActionResult> Get(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("1- Ready to start");

                await Task.Delay(TimeSpan.FromSeconds(5), token);

                _logger.LogInformation("2- Half of the work done");

                await Task.Delay(TimeSpan.FromSeconds(10), token);

                _logger.LogInformation("3- We finished!!!");

                return Ok();
            //////////Si fuera una transaccion seria maso asi
            //using (var transaction = await _dbContext.Database.BeginTransactionAsync(token))
            // {
            //     // Modifying operations here
            
            //     // Commit if successful
            //     await transaction.CommitAsync(token);
            //     // Rollback otherwise
            //     await transaction.RollbackAsync(token);
            // }

            }
            catch (TaskCanceledException)
            {
                _logger.LogInformation("Task was cancelled");
                return BadRequest();
            }

        }

    }
}
