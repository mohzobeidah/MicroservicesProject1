using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;

namespace PlateformService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
private IPlateformRepo  _plateformRepo;
    public WeatherForecastController(ILogger<WeatherForecastController> logger,IPlateformRepo  plateformRepo)
    {
        _logger = logger;
        _plateformRepo=plateformRepo;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {

       var x =  _plateformRepo.GetAllPlateforms();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
