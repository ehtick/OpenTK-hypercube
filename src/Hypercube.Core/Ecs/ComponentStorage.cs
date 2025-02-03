using System.Runtime.CompilerServices;

namespace Hypercube.Core.Ecs;

public readonly ref struct ComponentStorage<T>
{
    private readonly int[] _mapping;
    private readonly T[] _components;

    public ref T this[Entity entity]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref _components[_mapping[entity.Id]];
    }
    
    public ComponentStorage(int[] mapping, T[] components)
    {
        _mapping = mapping;
        _components = components;
    }
}