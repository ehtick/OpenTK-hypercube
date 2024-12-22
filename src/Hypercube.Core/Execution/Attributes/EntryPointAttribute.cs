using Hypercube.Core.Execution.Enums;

namespace Hypercube.Core.Execution.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class EntryPointAttribute : Attribute
{
    public readonly EntryPointLevel Level;

    public EntryPointAttribute(EntryPointLevel level)
    {
        Level = level;
    }
}