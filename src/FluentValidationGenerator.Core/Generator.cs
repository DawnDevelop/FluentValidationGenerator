using System.Reflection;
using FluentValidationGenerator.Core.Interfaces;
using FluentValidationGenerator.Core.Parser;

namespace FluentValidationGenerator.Core;

public class Generator : IGenerator
{

    public Assembly Assembly { get; }
    public DirectoryInfo SourceFolder { get; set; }

    /// <summary>
    /// Generator Class used to Generate the Validators for the Commands
    /// </summary>
    /// <param name="assembly">Assembly Containing the MediatR Commands</param>
    /// <param name="sourceFolder">Solution Folder. Should be able to get it with: 
    /// Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))</param>
    public Generator(Assembly assembly, string sourceFolder)
    {
        Assembly = assembly;

        SourceFolder = new DirectoryInfo(sourceFolder);
    }

    /// <summary>
    /// Generates the Boilerplate Code for Fluent Validators from Commands inside your Assembly
    /// </summary>
    /// <returns>
    /// Success
    /// </returns>
    public bool GenerateValidators()
    {
        var parsedTemplates = LiquidParser.ParseLiquidTemplate(Assembly);

        foreach (var item in parsedTemplates)
        {
            foreach (var file in
                Directory.EnumerateFiles(SourceFolder.FullName, "*.cs", SearchOption.AllDirectories)
                .Where(file => file.EndsWith($"{item.Key}.cs")))
            {
                var newName = file.Replace($"{item.Key}.cs", $"{item.Key}Validator.cs");
                File.WriteAllText(newName, item.Value);
            }
        }

        return true;
    }

}

