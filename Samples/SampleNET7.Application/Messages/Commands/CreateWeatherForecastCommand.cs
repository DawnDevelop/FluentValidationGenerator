﻿using MediatR;
using SampleNET7.Application.Common.Models;

namespace SampleNET7.Application.Messages.Commands;

public record CreateWeatherForecastCommand : IRequest<IEnumerable<WeatherForecast>>
{
	public required string[] Summaries { get; set; }

	public required int TemperatureC { get; set; }

	public required string TestString { get; set; }

}


public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, IEnumerable<WeatherForecast>>
{
	public async Task<IEnumerable<WeatherForecast>> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
	{
		return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = DateTime.Now,
			TemperatureC = request.TemperatureC,
			Summary = request.Summaries[Random.Shared.Next(request.Summaries.Length)]
		})
		.AsEnumerable();
	}
}
