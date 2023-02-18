namespace FluentValidationGenerator.Core.Interfaces;

public interface IGenerator
{
    /// <summary>
    /// Generates the Validators for the Commands in the Assembly
    /// </summary>
    /// <returns>Success</returns>
    bool GenerateValidators();
}