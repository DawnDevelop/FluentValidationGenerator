# FluentValidationGenerator

![Nuget](https://img.shields.io/nuget/v/FluentValidationGenerator.svg?style=plastic)


A Code Generator for automatically generating [FluentValidation](https://github.com/FluentValidation/FluentValidation) Classes for .NET 7+ with predefined Rules.

The Generator uses [MediatR](https://github.com/jbogard/MediatR) Commands which inherit from the `IRequest<>` interface to automatically Generate Fluent Validator Classes.

[Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) is the recommended Solution Architecture.

## Plans

:white_check_mark: Create Fluent Validators based on MediatR commands which follow the [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture)

:x: Tests

:x: Create Fluent Validators for ASP.NET Core API's based on an [OpenAPI specification](https://github.com/OAI/OpenAPI-Specification/)


## Usage

**For Usage please refer to the [Sample Project](/Samples/SampleNET7/)**

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

The Generator should generate a File looking similar to the following Code, depending on the amount of Parameters
```cs
using FluentValidation;

namespace SampleNET7.Application.Messages.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
  public CreateWeatherForecastCommandValidator()
  {
        
	RuleFor(t => t.Summaries).NotEmpty().WithMessage("Summaries Can not be Empty"); 

	RuleFor(t => t.TemperatureC).NotEmpty().WithMessage("TemperatureC Can not be Empty"); 

	RuleFor(t => t.TestString).NotEmpty().WithMessage("TestString Can not be Empty"); 

  }
}

```

> The Generator will **NOT** Generate a Rule for Nullable Properties


