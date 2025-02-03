namespace Hypercube.Core.Ecs;

public sealed class World : IDisposable
{
    public readonly EntityData[] EntityData = [];
    
    public int MaxEntities { get; }

    public World(int maxEntities = int.MaxValue)
    {
        if (maxEntities < 0)
            throw new ArgumentException();
        
        MaxEntities = maxEntities;
    }

    public Entity SpawnEntity()
    {
        throw new NotImplementedException();
    }

    public void RegisterSystem(Type type)
    {
        
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }
}