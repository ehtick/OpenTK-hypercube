using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hypercube.Physics.Shapes;

[StructLayout(LayoutKind.Sequential), Serializable]
public readonly struct ShapeId : IEquatable<ShapeId>
{
    public readonly int Value;

    public ShapeId(int value)
    {
        Value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(ShapeId other) => Value == other.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj) => obj is ShapeId other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => Value.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ShapeId left, ShapeId right) => left.Equals(right);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ShapeId left, ShapeId right) => !(left == right);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator int(ShapeId id) => id.Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ShapeId(int value) => new(value);
}
