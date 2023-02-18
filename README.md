# FluentValidationGenerator

![Nuget](https://img.shields.io/nuget/v/FluentValidationGenerator.Core.svg?style=plastic)


A Code Generator for automatically generating ![FluentValidation](https://github.com/FluentValidation/FluentValidation) Classes for .NET 7+ with predefined Rules.

The Generator uses ![MediatR](https://github.com/jbogard/MediatR) Commands which inherit from the `IRequest<>` interface to automatically Generate Fluent Validator Classes.

![Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) is the recommended Solution Architecture.

## Plans

:white_check_mark: Create Fluent Validators based on MediatR commands which follow the ![Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture)

:x: Create Fluent Validators for ASP.NET Core API's based on an ![OpenAPI specification](https://github.com/OAI/OpenAPI-Specification/)


## Usage

**For Usage please refer to the ![Sample Project](/Samples/SampleNET7/)**

`FluentValidationGenerator.Core.Generator` takes the Assembly which contains the Commands and the Solution Folder as Parameters.

The easiest way to get your Solution Folder should be:

`Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))`

This should result in:
```csharp
var generator = new FluentValidationGenerator.Core.Generator(
	typeof(CreateWeatherForecastCommand).Assembly,
	Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))!);

generator.GenerateValidators();
```

