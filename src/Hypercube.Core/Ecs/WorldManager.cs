namespace Hypercube.Core.Ecs;

public class WorldManager
{
    public static IReadOnlyList<World> Worlds => _worlds;
    
    private static readonly List<World> _worlds = [];
}