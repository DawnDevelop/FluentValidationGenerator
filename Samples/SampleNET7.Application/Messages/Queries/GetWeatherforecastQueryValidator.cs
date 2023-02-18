using FluentValidation;

namespace SampleNET7.Application.Messages.Queries;

public class GetWeatherforecastQueryValidator : AbstractValidator<GetWeatherforecastQuery>
{
  public GetWeatherforecastQueryValidator()
  {

    
    RuleFor(x => x.TemperatureC).NotEmpty().WithMessage("TemperatureC Can not be Empty");
    
  }
}