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
    public static string GeneratorTestsDirectory => ProjectDirectory + "\\Generator";
    public static string fileName => $"{GeneratorTestsDirectory}\\Commands\\{nameof(GeneratorTestCommand)}Validator.cs";

    
    //TODO

    //[Test]
    //public void Generator_Should_Create_One_ValidationClass()
    //{
    //    var generator = new FluentValidationGenerator.Generator(CurrentAssembly, GeneratorTestsDirectory);

    //    generator.GenerateValidators().Should().BeTrue();

    //    File.Exists(fileName).Should().BeTrue();

    //    var fileContent = File.ReadAllText(fileName);
    //    fileContent.Should().NotBeNullOrEmpty();
    //    fileContent.Should().Contain($"RuleFor(t => t.{nameof(GeneratorTestCommand.PropertyName)})");
    //    fileContent.Should().Contain($"RuleFor(t => t.{nameof(GeneratorTestCommand.TestInteger)}).NotEmpty()");
    //}

    //[TearDown]
    //public void TearDown()
    //{
    //    //Delete Created Validators
    //    foreach (var item in Directory.EnumerateFiles(GeneratorTestsDirectory, "*.cs", SearchOption.AllDirectories)
    //        .Where(file => file.Contains($"Validator.cs")))
    //    {
    //        File.Delete(item);
    //    }
        
    //}
}
