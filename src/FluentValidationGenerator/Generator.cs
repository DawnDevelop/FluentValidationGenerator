using System.IO;
using System.Reflection;
using FluentValidationGenerator.Interfaces;
using FluentValidationGenerator.Parser;

namespace FluentValidationGenerator;

/// <summary>
/// Generator Class used to Generate the Validators for the Commands
/// </summary>
public class Generator : IGenerator
{

    public Assembly Assembly { get; }
    public DirectoryInfo SourceFolder { get; }

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
    /// Generates the Validators for the Commands and Queries in the Assembly
    /// </summary>
    /// <param name="overWriteOutputFolderPath"> 
    /// Custom folder to output the Validators. 
    /// If blank, the Validators are attempted to be generated inside the same folder as the Commands and Queries
    /// </param>
    /// <returns>Success</returns>
    public bool GenerateValidators(string? overWriteOutputFolderPath = null)
    {
        try
        {
            var parsedTemplates = LiquidParser.ParseAllTemplatesFromAssembly(Assembly);

            if (!string.IsNullOrWhiteSpace(overWriteOutputFolderPath))
                OutputInCustomFolder(parsedTemplates, overWriteOutputFolderPath);
            else
                OutputInValidationFolder(parsedTemplates);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: {0}", ex.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Outputs all Classes in a single folder
    /// </summary>
    private static void OutputInCustomFolder(
        Dictionary<string, string> parsedTemplates, string overWriteOutputFolderPath)
    {
        Directory.CreateDirectory(overWriteOutputFolderPath);
        foreach (var item in parsedTemplates)
        {
            File.WriteAllText(overWriteOutputFolderPath + "\\" + item.Key + "Validator.cs", item.Value);
        }

    }

    /// <summary>
    /// Outputs all Classes inside the corresponding Command or Query Folders
    /// </summary>
    private void OutputInValidationFolder(Dictionary<string, string> parsedTemplates)
    {
        foreach (var item in parsedTemplates)
        {
            foreach (var file in
                Directory.EnumerateFiles(SourceFolder.FullName, "*.cs", SearchOption.AllDirectories)
                .Where(file => file.EndsWith($"{item.Key}.cs")))
            {
                string newName = file.Replace($"{item.Key}.cs", $"{item.Key}Validator.cs");
                File.WriteAllText(newName, item.Value);
            }
        }
    }

}

