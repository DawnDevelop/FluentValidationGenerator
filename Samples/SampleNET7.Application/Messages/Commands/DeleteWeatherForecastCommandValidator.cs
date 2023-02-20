using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class DeleteWeatherForecastCommandValidator : AbstractValidator<DeleteWeatherForecastCommand>
{
  public DeleteWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries can not be Empty");

	RuleFor(t => t.TemperatureC).NotEmpty().WithMessage("TemperatureC can not be Empty");

	RuleFor(t => t.TestString).NotEmpty().WithMessage("TestString can not be Empty");

  }
}