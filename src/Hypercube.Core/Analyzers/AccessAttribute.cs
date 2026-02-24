using System.Collections.Immutable;
using Hypercube.Utilities;

namespace Hypercube.Core.Analyzers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
public sealed class AccessAttribute : Attribute
{
    public ImmutableArray<Type> Friends { get; }
    
    public bool AllowFriendInheritance { get; init; }
    public bool AllowSameAssembly { get; init; }

    public Permissions Self { get; init; } = Permissions.ReadWriteExecute;
    public Permissions Friend { get; init; } = Permissions.ReadWriteExecute;
    public Permissions Other { get; init; } = Permissions.Read;

    public AccessAttribute(params Type[] friends)
    {
        Friends = friends is { Length: > 0 }
            ? [..friends]
            : ImmutableArray<Type>.Empty;
    }
}