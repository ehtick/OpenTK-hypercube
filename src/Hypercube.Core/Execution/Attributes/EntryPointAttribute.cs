using Hypercube.Core.Execution.Enums;

namespace Hypercube.Core.Execution.Attributes;

[AttributeUsage(AttributeTargets.Method), MeansImplicitUse]
public class EntryPointAttribute : Attribute
{
    public readonly EntryPointStage Stage;

    public EntryPointAttribute(EntryPointStage stage)
    {
        Stage = stage;
    }
}