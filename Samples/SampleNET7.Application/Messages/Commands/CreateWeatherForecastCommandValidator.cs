using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CreateWeatherForecastCommandValidator"/> class,
  /// setting up validation rules for various properties of the CreateWeatherForecastCommand.
  /// It ensures that certain fields such as Summaries and NotNullableString are not empty.
  /// </summary>
  /// <example>
  /// var validator = new CreateWeatherForecastCommandValidator();
  /// var result = validator.Validate(createWeatherForecastCommand);
  /// if (result.IsValid)
  /// {
  ///     // Process the valid command
  /// }
  /// else
  /// {
  ///     // Handle validation failures
  /// }
  /// </example>
  public CreateWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries can not be Empty");

	RuleFor(t => t.TemperatureC);

	RuleFor(t => t.NullableString);

	RuleFor(t => t.NotNullableString).NotEmpty().WithMessage("NotNullableString can not be Empty");

  }
}