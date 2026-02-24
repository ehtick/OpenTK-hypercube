namespace Hypercube.Core.Scenes.Manager;

public interface ISceneManager
{
    IScene Active { get; }
    
    void Update(float deltaTime);
}
