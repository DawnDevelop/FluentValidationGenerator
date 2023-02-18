using MediatR;

namespace SampleNET7.Application.Messages.Commands;

public record DeleteWeatherForecastCommand : IRequest
{
	public required string[] Summaries { get; set; }

	public required int TemperatureC { get; set; }

	public required string TestString { get; set; }

}


public class DeleteWeatherForecastCommandHandler : IRequestHandler<DeleteWeatherForecastCommand>
{
    public Task Handle(DeleteWeatherForecastCommand request, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
