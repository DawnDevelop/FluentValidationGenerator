# FluentValidationGenerator

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/FluentValidationGenerator?logo=NuGet)](https://www.nuget.org/packages/FluentValidationGenerator/)
[![Nuget Downloads](https://img.shields.io/nuget/dt/FluentValidationGenerator?label=Nuget%20Downloads&logo=NuGet)](https://www.nuget.org/packages/FluentValidationGenerator/)
![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/DawnDevelop/FluentValidationGenerator/CI.yml?logo=GitHub)

[![Maintainability](https://api.codeclimate.com/v1/badges/67fe51f496ce62eea4a8/maintainability)](https://codeclimate.com/github/DawnDevelop/FluentValidationGenerator/maintainability)
[![codecov](https://codecov.io/gh/DawnDevelop/FluentValidationGenerator/branch/main/graph/badge.svg?token=C2BAZP1HAY)](https://codecov.io/gh/DawnDevelop/FluentValidationGenerator)

A Code Generator for automatically generating [FluentValidation](https://github.com/FluentValidation/FluentValidation) Classes for .NET 7+ with predefined Rules.

The Generator uses [MediatR](https://github.com/jbogard/MediatR) Commands which inherit from the `IRequest<>` interface to automatically Generate Fluent Validator Classes.

[Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) is the recommended Solution Architecture.

## Plans

:white_check_mark: Create Fluent Validators based on MediatR commands which follow the [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture)

:x: Tests

:x: Create Fluent Validators for ASP.NET Core API's based on an [OpenAPI specification](https://github.com/OAI/OpenAPI-Specification/)


## Usage

**For Usage please refer to the [Sample Project](/Samples/)**

`FluentValidationGenerator.Generator` takes the Assembly which contains the Commands and the Solution Folder as Parameters.

The easiest way to get your Solution Folder should be:

`Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))`

This should result in:
```cs
var generator = new FluentValidationGenerator.Generator(
	typeof(CreateWeatherForecastCommand).Assembly,
	Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))!);

generator.GenerateValidators();
```

Having defined Commands or Queries like the following:
```cs
public record CreateWeatherForecastCommand : IRequest<IEnumerable<WeatherForecast>>
{
    public required string[] Summaries { get; set; }

    public int TemperatureC { get; set; }

    public string? NullableString { get; set; }

    public required string NotNullableString { get; set; }

}
```

Should generate a File looking similar to the following Code, depending on the amount of Parameters

```cs
using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
  public CreateWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries Can not be Empty");

	RuleFor(t => t.TemperatureC);

	RuleFor(t => t.NullableString);

	RuleFor(t => t.NotNullableString).NotEmpty().WithMessage("NotNullableString Can not be Empty");

  }
}

```

> The Generator will Generate an **empty** Rule for Nullable Properties or Value Types

<br>

[Medium publication](https://medium.com/@denizjoecks/automatically-generate-fluent-validation-classes-for-your-net-projects-based-on-mediatr-commands-94c3b3ec19d3)

<a href="https://www.buymeacoffee.com/DawnDevelop"><img src="https://img.buymeacoffee.com/button-api/?text=Coffee :)&emoji=???&slug=DawnDevelop&button_colour=17a4d3&font_colour=000000&font_family=Inter&outline_colour=000000&coffee_colour=FFDD00" /></a>

