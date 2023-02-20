using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
  public CreateWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries can not be Empty");

	RuleFor(t => t.TemperatureC);

	RuleFor(t => t.NullableString);

	RuleFor(t => t.NotNullableString).NotEmpty().WithMessage("NotNullableString can not be Empty");

  }
}