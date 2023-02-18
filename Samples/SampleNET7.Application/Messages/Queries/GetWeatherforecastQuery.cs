using MediatR;
using SampleNET7.Application.Common.Models;

namespace SampleNET7.Application.Messages.Queries;

public record GetWeatherforecastQuery(int TemperatureC) : IRequest<WeatherForecast>;


public class GetWeatherforecastQueryHandler : IRequestHandler<GetWeatherforecastQuery, WeatherForecast>
{
	private static readonly string[] Summaries = new[]
	{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public async Task<WeatherForecast> Handle(GetWeatherforecastQuery request, CancellationToken cancellationToken)
	{
		return new WeatherForecast
		{
			Date = DateTime.Now,
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		};
	}
}