using Fluid;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Core;

public static class LiquidParser
{
	const string TemplateFolder = "./Templates";
	const string Template = "validationTemplate.liquid";


	public static Dictionary<string, string> ParseLiquidTemplate(Assembly assembly)
	{
		var parser = new FluidParser();

		var source = GetEmbeddedTemplate();
		var types = ReflectionHelper.FindAllCommandsInAssembly(assembly);
		var models = ReflectionHelper.CreateSettingsFromTypes(types);
		var result = new Dictionary<string, string>();

		var options = new TemplateOptions();
		options.MemberAccessStrategy.Register<PropertySettings>();
		
		foreach (var model in models)
		{
			if (parser.TryParse(source, out var template, out var error))
			{
				result.Add(model.ClassName, template.Render(new TemplateContext(model, options)));
			}
			else
			{
				Console.WriteLine(error);
			}
		}
		
		return result;
	}

	private static string GetEmbeddedTemplate()
	{
		var assembly = typeof(Generator).Assembly;
		var resourceName = $"{assembly.GetName().Name}.Templates.{Template}";
		using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
		if (stream != null)
		{
			using StreamReader reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
		return null!;
	}
}
