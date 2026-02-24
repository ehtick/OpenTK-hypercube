namespace Hypercube.Core.Scenes.Manager;

[UsedImplicitly]
public sealed class SceneManager : ISceneManager
{
    public IScene Active { get; }

    public void Update(float deltaTime)
    {
    }
}