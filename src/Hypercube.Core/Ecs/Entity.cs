using System.Runtime.InteropServices;

namespace Hypercube.Core.Ecs;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Entity : IDisposable, IEquatable<Entity>
{
    public readonly int Id;
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public bool Equals(Entity other)
    {
        return Id == other.Id;
    }

    public override string ToString()
    {
        return $"Entity {Id}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !left.Equals(right);
    }
}