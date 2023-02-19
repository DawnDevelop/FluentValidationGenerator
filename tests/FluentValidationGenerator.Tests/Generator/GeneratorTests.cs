using FluentAssertions;
using FluentValidationGenerator.Tests.Commands;
using Moq;
using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace FluentValidationGenerator.Tests.Generator;

[TestFixture]
public class GeneratorTests : BaseTest
{
    public static string GeneratorTestsDirectory => Directory.GetCurrentDirectory() + "\\Generator";
    public static string fileName => $"{GeneratorTestsDirectory}\\{nameof(GeneratorTestCommand)}Validator.cs";



    [Test]
    public void Generator_Should_Create_One_ValidationClass()
    {
        var generator = new FluentValidationGenerator.Generator(CurrentAssembly, GeneratorTestsDirectory);

        generator.GenerateValidators(GeneratorTestsDirectory).Should().BeTrue();

        File.Exists(fileName).Should().BeTrue();

        var fileContent = File.ReadAllText(fileName);
        fileContent.Should().NotBeNullOrEmpty();
        fileContent.Should().Contain($"RuleFor(t => t.{nameof(GeneratorTestCommand.NullableString)})");
        fileContent.Should().Contain($"RuleFor(t => t.{nameof(GeneratorTestCommand.TestInteger)})");
        fileContent.Should().Contain($"RuleFor(t => t.{nameof(GeneratorTestCommand.NotNullableString)}).NotEmpty()");

    }

    [TearDown]
    public void TearDown()
    {
        //Delete Created Validators
        foreach (var item in 
            Directory.EnumerateFiles(GeneratorTestsDirectory, "*Validator.cs", SearchOption.AllDirectories))
        {
            File.Delete(item);
        }

    }
}
