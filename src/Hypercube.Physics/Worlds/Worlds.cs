namespace Hypercube.Physics.Worlds;

public static class Worlds
{
    private static WorldId CreateWorld(in WorldMeta meta)
    {
        var id = WorldAllocator.CreateWorldId();
        if (id == WorldId.Null)
            return WorldId.Null;

        var world = WorldAllocator.AllocationGet(id);
        world.Clear();
        
        return id;
    }

    public static World GetWorld(WorldId id) => WorldAllocator.AllocationGet(id);
}