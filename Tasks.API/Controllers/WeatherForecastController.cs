﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Task.Queries;

namespace Tasks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger ,
         IMediator mediator

        )
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpGet]
    private async Task<IResult> GetTask( int id)
    {
        var getPerson = new GetTaskById { Id = id };
        var person = await _mediator.Send(getPerson);

        return TypedResults.Ok(person);
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

