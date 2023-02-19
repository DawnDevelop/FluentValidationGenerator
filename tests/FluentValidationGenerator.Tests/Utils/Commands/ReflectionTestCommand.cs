using MediatR;

namespace FluentValidationGenerator.Tests.Utils.Commands;

public class ReflectionTestCommand : IRequest
{
    public string? NullableString { get; set; }

    public int TestInteger { get; set; }

    public TestEnum TestEnum { get; set; }

    public required string NotNullableString { get; set; }
    
}


public enum TestEnum
{
    test1,
    test2
}