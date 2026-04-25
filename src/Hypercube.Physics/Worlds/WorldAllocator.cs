using System.Diagnostics;

namespace Hypercube.Physics.Worlds;

public static class WorldAllocator
{
    private static readonly World?[] Worlds = AllocateWorlds(Constants.MaxWorlds, Constants.WorldsAllocation);

    public static int Length => Worlds.Length;
    
    public static WorldId CreateWorldId()
    {
        for (var i = 0; i < Length; i++)
        {
            var world = Worlds[i];

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (world is null)
                return i;

            if (!world.Used)
                return i;
        }

        return WorldId.Null;
    }
    
    public static World AllocationGet(int index)
    {
        var world = Worlds[index];
        if (world is not null)
            return world;
        
        return Worlds[index] = new World();
    }

    private static World[] AllocateWorlds(int max, int allocate)
    {
        Debug.Assert(max > 0);
        Debug.Assert(max < ushort.MaxValue);
        Debug.Assert(allocate > 0);
        Debug.Assert(allocate <= max);

        var worlds = new World[max];
        for (var i = 0; i < max; i++)
        {
            if (i < allocate)
            {
                worlds[i] = new World();
                continue;
            }

            worlds[i] = null!;
        }

        return worlds;
    }
}
