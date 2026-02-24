namespace Hypercube.Core.Scenes;

public abstract class Scene : IScene
{
    public SceneContainer Container { get; }
    
    public abstract void Startup();
    public abstract void Shutdown();

    public void Dispose()
    {
    }
}