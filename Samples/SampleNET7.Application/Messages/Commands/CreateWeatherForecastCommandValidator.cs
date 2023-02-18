using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
  public CreateWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries Can not be Empty");

	RuleFor(t => t.TemperatureC).NotEmpty().WithMessage("TemperatureC Can not be Empty");

	RuleFor(t => t.NullableString);

  }
}