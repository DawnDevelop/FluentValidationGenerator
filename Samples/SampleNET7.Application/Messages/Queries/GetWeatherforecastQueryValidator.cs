using FluentValidation;

namespace SampleNET7.Application.Messages.Queries;

public class GetWeatherforecastQueryValidator : AbstractValidator<GetWeatherforecastQuery>
{
  public GetWeatherforecastQueryValidator()
  {
        
	RuleFor(t => t.TemperatureC).NotEmpty().WithMessage("TemperatureC Can not be Empty");

  }
}