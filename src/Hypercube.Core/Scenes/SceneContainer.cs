using Hypercube.Ecs;
using Hypercube.Ecs.System.Collections;

namespace Hypercube.Core.Scenes;

public readonly struct SceneContainer
{
    public readonly IWorld World;
    
    // Fun fact we cant store other collections in collection
    // That mean we can store anything we want here, like
    // parallel collections in future?
    public readonly SystemSequence Systems; 
    
    // TODO: UI Root
    
    public SceneContainer(IWorld world, SystemSequence systems)
    {
        World = world;
        Systems = systems;
    }
}