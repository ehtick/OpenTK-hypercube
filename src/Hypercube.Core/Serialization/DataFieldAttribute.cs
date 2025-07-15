namespace Hypercube.Core.Serialization;

[AttributeUsage(AttributeTargets.Field), MeansImplicitUse]
public class DataFieldAttribute : Attribute
{
    public readonly string? Name;

    public DataFieldAttribute(string? name = null)
    {
        Name = name;
    }
}