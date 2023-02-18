using System.Reflection;

namespace Generator.Core;

public class Generator
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

        var test = parsedTemplates.First().Value;
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

