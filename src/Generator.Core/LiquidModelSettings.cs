namespace Generator.Core;

public class LiquidModelSettings
{
    public required string ClassName { get; set; }

    public required string NameSpace { get; set; }

    public required List<PropertySettings> Properties { get; set; }

}

public class PropertySettings
{
    public string? Name { get; set; }
}