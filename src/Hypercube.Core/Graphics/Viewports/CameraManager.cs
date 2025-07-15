using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics.Viewports;

[UsedImplicitly]
public class CameraManager : ICameraManager, IPostInject
{
    [Dependency] private readonly IWindowManager _windowManager = default!;

    // Just for test
    public ICamera MainCamera { get; } = Camera.Default;
    
    public void PostInject()
    {
        // TODO: Implement window scale affect to all camera projections...
        // Need to add cache created windows in IWindowManager & IWindowingApi 

        _windowManager.OnMainWindowResized += OnMainWindowResized;
    }

    private void OnMainWindowResized(Vector2i size)
    {
        MainCamera.Size = size;
    }
}