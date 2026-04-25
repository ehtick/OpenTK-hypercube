using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hypercube.Physics.Worlds;

[StructLayout(LayoutKind.Sequential), Serializable]
public readonly struct WorldId : IEquatable<WorldId>
{
    public static readonly WorldId Null = new(-1);
    
    public readonly int Value;

    public WorldId(int value)
    {
        Value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(WorldId other) => Value == other.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is WorldId other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => Value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(WorldId left, WorldId right) => !(left == right);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator int(WorldId id) => id.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WorldId(int value) => new(value);
}
