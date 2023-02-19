using MediatR;

namespace FluentValidationGenerator.Tests.Utils.Commands;

public class ReflectionTestCommand : IRequest
{
    public string? PropertyName { get; set; }

    public int TestInteger { get; set; }
}
