using Feedback.Api.Database;
using Feedback.Api.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

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
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
[ApiController]
[Route("/api/[controller]")]
public class TopicController : ControllerBase
{
    private readonly FeedbackContext _context;

    public TopicController(FeedbackContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Topics.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Topic? topic = _context.Topics.Find(id);

        if (topic is not null)
            return Ok(topic);

        ProblemDetails problem = new()
        {
            Status = 404,
            Detail = "No topic exist"
        };

        return NotFound(problem);
    }
}