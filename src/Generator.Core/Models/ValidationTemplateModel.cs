using DotLiquid;

namespace Generator.Core.Models;

public class ValidationTemplateModel : Drop
{
    public required string ClassName { get; set; }

    public required string NameSpace { get; set; }

    public required List<PropertyModel> Properties { get; set; }

}

public class PropertyModel : Drop
{
    public string? Name { get; set; }
    public bool Required { get; set; } = true;
    public bool Nullable { get; set; } = false;
}