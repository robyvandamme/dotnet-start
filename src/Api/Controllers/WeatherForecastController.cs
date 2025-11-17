using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class WeatherForecastController : ControllerBase
    {
        private static readonly string[] s_summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
#pragma warning disable CA1848
            _logger.LogInformation("Get Started");
#pragma warning restore CA1848
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
#pragma warning disable CA5394
                    TemperatureC = rng.Next(-20, 55),
                    Summary = s_summaries[rng.Next(s_summaries.Length)],
#pragma warning restore CA5394
                })
                .ToArray();
        }
    }
}
