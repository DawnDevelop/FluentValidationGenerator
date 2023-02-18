using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public CreateWeatherForecastCommandValidator()
    {


        RuleFor(x => x.Summaries).NotEmpty().WithMessage("Summaries Can not be Empty");

        RuleFor(x => x.TemperatureC).NotEmpty().WithMessage("TemperatureC Can not be Empty");

        RuleFor(x => x.TestString).NotEmpty().WithMessage("TestString Can not be Empty");

    }
}