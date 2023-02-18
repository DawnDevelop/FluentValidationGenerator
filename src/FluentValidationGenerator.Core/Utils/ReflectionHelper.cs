using FluentValidationGenerator.Core.Models;
using MediatR;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FluentValidationGenerator.Core.Utils;

public static class ReflectionHelper
{
    public static Type[] FindAllCommandsInAssembly(Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(t => IsCommand(t) && t.GetProperties().Any())
            .ToArray();
    }

    public static IEnumerable<ValidationTemplateModel> CreateModelsFromTypes(Type[] types)
    {
        foreach (var type in types)
        {
            var properties = type.GetProperties();

            yield return new ValidationTemplateModel()
            {
                ClassName = type.Name,
                NameSpace = type.Namespace ?? throw new ArgumentNullException(nameof(type.Namespace)),
                Properties = properties.Select(p => new PropertyModel()
                {
                    Name = p.Name,
                    //Required = IsRequired(p), TODO Check if needed
                    Nullable = IsNullable(p)
                }).ToList()
            };
        }
    }

    private static bool IsNullable(PropertyInfo property)
    {
        return property.PropertyType.IsGenericType
            && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
    private static bool IsRequired(PropertyInfo property)
    {
        return property.GetCustomAttribute<RequiredMemberAttribute>() is not null;
    }

    private static bool IsCommand(Type type)
    {
        return type.GetInterfaces().Where(t => t.Name.Contains(nameof(IRequest))).Any();
    }
}
