using MediatR;
using SampleNET7.Application.Common.Models;

namespace SampleNET7.Application.Messages.Commands;

public record DeleteWeatherForecastCommand : IRequest<Unit>
{
	public required string[] Summaries { get; set; }

	public required int TemperatureC { get; set; }

	public required string TestString { get; set; }

}


public class DeleteWeatherForecastCommandHandler : IRequestHandler<DeleteWeatherForecastCommand, Unit>
{
    public async Task<Unit> Handle(DeleteWeatherForecastCommand request, CancellationToken cancellationToken)
	{
		return Unit.Value;
	}
}
