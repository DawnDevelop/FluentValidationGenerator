using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleNET7.Application.Common.Models;
using SampleNET7.Application.Messages.Commands;
using SampleNET7.Application.Messages.Queries;

namespace SampleNET7.Controllers
{
	[AllowAnonymous]
	public class WeatherForecastController : ApiControllerBase
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

		[HttpGet("{id}")]
		public async Task<ActionResult<WeatherForecast>> Get(int id)
		{
			return Ok(await Mediator.Send(new GetWeatherforecastQuery(id)));
		}

		[HttpPost()]
		[HttpPut()]
		public async Task<ActionResult<IEnumerable<WeatherForecast>>> Create(CreateWeatherForecastCommand command)
		{
			command.Summaries ??= Summaries;
			
			return Ok(await Mediator.Send(command));
			
		}
	}
}