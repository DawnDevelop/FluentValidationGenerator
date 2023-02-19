using MediatR;

namespace FluentValidationGenerator.Tests.Commands;

public class GeneratorTestCommand : IRequest
{
    public string? NullableString { get; set; }
    public int TestInteger { get; set; }

    public required string NotNullableString { get; set; }
    
}
