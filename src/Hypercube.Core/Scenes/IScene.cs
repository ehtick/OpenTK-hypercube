namespace Hypercube.Core.Scenes;

public interface IScene : IDisposable
{
    SceneContainer Container { get; }
    
    void Startup();
    void Shutdown();
}