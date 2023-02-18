using System.Reflection;
using FluentValidationGenerator.Core.Interfaces;
using FluentValidationGenerator.Core.Parser;

namespace FluentValidationGenerator.Core;

public class Generator : IGenerator
{

    public Assembly Assembly { get; }
    public DirectoryInfo SourceFolder { get; set; }

    public Generator(Assembly assembly, string sourceFolder)
    {
        Assembly = assembly;

        SourceFolder = new DirectoryInfo(sourceFolder);
    }

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

