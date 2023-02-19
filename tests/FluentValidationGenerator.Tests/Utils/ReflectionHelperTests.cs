using FluentAssertions;
using FluentValidationGenerator.Tests.Utils.Commands;
using FluentValidationGenerator.Utils;

namespace FluentValidationGenerator.Tests.Utils;

[TestFixture]
public class ReflectionHelperTests : BaseTest
{

    [Test]
    public void FindAllCommandsInAssemblyTest()
    {
        ReflectionHelper.FindAllCommandsInAssembly(CurrentAssembly).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void CreateModelsFromType_TestCommand()
    {
        var commandClasses = ReflectionHelper.FindAllCommandsInAssembly(CurrentAssembly);
        var filteredClasses = commandClasses.Where(x => x.Name == nameof(ReflectionTestCommand)).First();

        Type[] arr = { filteredClasses };
        var models = ReflectionHelper.CreateModelsFromTypes(arr);
        
        models.Should().NotBeNullOrEmpty();
        models.First().ClassName.Should().Be(nameof(ReflectionTestCommand));
        models.First().NameSpace.Should().Be(typeof(ReflectionTestCommand).Namespace);
        models.First().Properties.Should().NotBeNullOrEmpty();
        models.First().Properties.Where(x => x.Name == nameof(ReflectionTestCommand.NullableString)).First().Nullable.Should().BeTrue();
        models.First().Properties.Where(x => x.Name == nameof(ReflectionTestCommand.NotNullableString)).First().Nullable.Should().BeFalse();

        models.First().Properties.Where(x => x.Name == nameof(ReflectionTestCommand.TestInteger)).First().Nullable.Should().BeTrue();
        models.First().Properties.Where(x => x.Name == nameof(ReflectionTestCommand.TestEnum)).First().Nullable.Should().BeTrue();

    }
}
