namespace Hypercube.Core.Configuration;

[AttributeUsage(AttributeTargets.Class)]
public class ConfigAttribute : Attribute
{
    public readonly string ConfigFileName;

    public ConfigAttribute(string configFileName)
    {
        ConfigFileName = configFileName;
    }
}