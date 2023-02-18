using FluentValidationGenerator.Models;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FluentValidationGenerator.Utils;

public static class ReflectionHelper
{
    /// <summary>
    /// Finds all Commands the the Assembly
    /// </summary>
    /// <param name="assembly">Assembly containing the Commands</param>
    /// <returns>All Command classes / records as a Type Array</returns>
    public static Type[] FindAllCommandsInAssembly(Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(t => IsCommand(t) && t.GetProperties().Any())
            .ToArray();
    }

    /// <summary>
    /// Creates a List of Validation Template Models which is needed to fill the liquid Template
    /// </summary>
    /// <param name="types">Type Array containing all the Commands inside the Assembly</param>
    /// <returns>
    /// Returns a list of <see cref="ValidationTemplateModel"/> which can be used to Parse the liquid Templates
    /// </returns>
    /// <exception cref="ArgumentNullException">Namespace cant be NULL (yet)</exception>
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
                    Nullable = IsNullable(p)
                }).ToList()
            };
        }
    }

    /// <summary>
    /// Check whether or not the Property is declared Nullable
    /// </summary>
    private static bool IsNullable(PropertyInfo property)
    {
        var _nullabilityContext = new NullabilityInfoContext();
        var nullabilityInfo = _nullabilityContext.Create(property);
        
        return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }

    /// <summary>
    /// Check whether or not the Property is declared Reuquired
    /// </summary>
    private static bool IsRequired(PropertyInfo property)
    {
        return property.GetCustomAttribute<RequiredMemberAttribute>() is not null;
    }

    /// <summary>
    /// Check whether or not the Type is a Command and inherits from <see cref="IRequest"/>
    /// </summary>
    private static bool IsCommand(Type type)
    {
        const string MediatrRequestInterfaceName = "MediatR.IRequest";

        return type.GetInterfaces()
            .Where(i => i.FullName is not null)
            .Any(i => i.FullName!.Contains(MediatrRequestInterfaceName));
    }
}
