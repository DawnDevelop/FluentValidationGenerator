using MediatR;

namespace FluentValidationGenerator.Tests.Commands;

public class GeneratorTestCommand : IRequest
{
    public string? PropertyName { get; set; }
    public int TestInteger { get; set; }

}
