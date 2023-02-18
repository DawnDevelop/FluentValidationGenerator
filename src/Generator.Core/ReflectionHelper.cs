using MediatR;
using System.Reflection;

namespace Generator.Core;

public static class ReflectionHelper
{
	public static Type[] FindAllCommandsInAssembly(Assembly assembly)
	{
		return assembly.GetTypes()
			.Where(t => t.GetInterfaces().Where(t => t.Name.Contains(nameof(IRequest))).Any()
			&& t.GetProperties().Any())
			.ToArray();
	}

	public static List<LiquidModelSettings> CreateSettingsFromTypes(Type[] types)
	{
		var settings = new List<LiquidModelSettings>();

		foreach (var type in  types)
		{
			var properties = type.GetProperties();

			settings.Add(new LiquidModelSettings()
			{
				ClassName = type.Name,
				NameSpace = type.Namespace!,
				Properties = properties.Select(p => new PropertySettings() { 
					Name = p.Name 
				}).ToList()
			});
		}

		return settings;
	}
}
