using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class DeleteWeatherForecastCommandValidator : AbstractValidator<DeleteWeatherForecastCommand>
{
  public DeleteWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries Can not be Empty");

	RuleFor(t => t.TemperatureC).NotEmpty().WithMessage("TemperatureC Can not be Empty");

	RuleFor(t => t.TestString).NotEmpty().WithMessage("TestString Can not be Empty");

  }
}