using DotLiquid;
using DotLiquid.FileSystems;
using Generator.Core.Models;
using Generator.Core.Utils;
using System.Reflection;

namespace Generator.Core.Parse;

public static class LiquidParser
{
    const string TemplateFolder = "Templates";
    const string TemplateFile = "Validation.Class.liquid";


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
