using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Jala.Custom.Middleware.API.Controllers;

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

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<WeatherForecast> Get([FromQuery] int? index)
    {
        if (index != null)
        {
            try
            {
                var summary = Summaries.ElementAt((int)index);
                return Ok(summary);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();

        return Ok(list);
    }
}