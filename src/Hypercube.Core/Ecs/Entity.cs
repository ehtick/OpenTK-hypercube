using System.Runtime.InteropServices;

namespace Hypercube.Core.Ecs;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Entity : IEquatable<Entity>
{
    private const int NullVersion = -1;
    private const int NullId = -1;
    
    public readonly int Version;
    public readonly int WorldId;
    public readonly int Id;

    public Entity(int worldId)
    {
        WorldId = worldId;
        Version = NullVersion;
        Id = NullId;
    }

    public Entity(int worldId, int id)
    {
        WorldId = worldId;
        Id = id;
        Version = WorldManager.Worlds[WorldId].EntityData[id].Version;
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