using DotLiquid;
using DotLiquid.FileSystems;
using FluentValidationGenerator.Utils;
using System.Reflection;

namespace FluentValidationGenerator.Parser;

public static class LiquidParser
{
    const string TemplateFolder = "Templates";
    const string TemplateFile = "Validation.Class.liquid";


    /// <summary>
    /// Parses the Liquid Template
    /// </summary>
    /// <param name="assembly">Assembly Containing the MediatR Commands</param>
    /// <returns>Dictionary which contains the Command Name as a key and the Rendered Template</returns>
    public static Dictionary<string, string> ParseLiquidTemplate(Assembly assembly)
    {

        var source = GetEmbeddedTemplate();
        var types = ReflectionHelper.FindAllCommandsInAssembly(assembly);
        var models = ReflectionHelper.CreateModelsFromTypes(types);
        var result = new Dictionary<string, string>();

        foreach (var model in models)
        {
            try
            {
                var template = Template.Parse(source);
                result.Add(model.ClassName, template.Render(Hash.FromAnonymousObject(model)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        return result;
    }

    /// <summary>
    /// Gets the Embedded Main Template (Validation.Class.liquid) from the Embedded resources.
    /// </summary>
    /// <returns>Returns the raw string of the template</returns>
    private static string GetEmbeddedTemplate()
    {
        var assembly = typeof(LiquidParser).Assembly;
        var root = $"{assembly.GetName().Name}.{TemplateFolder}";

        Template.FileSystem = new EmbeddedFileSystem(assembly, root);

        using Stream stream = assembly.GetManifestResourceStream($"{root}.{TemplateFile}")!;

        if (stream != null)
        {
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        return null!;
    }
}
