using Hypercube.Graphics.Windowing.Manager;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Viewports;

public class CameraManager : ICameraManager, IPostInject
{
    [Dependency] private readonly IWindowManager _windowManager = default!;

    public void PostInject()
    {
        // TODO: Implement window scale affect to all camera projections...
        // Need to add cache created windows in IWindowManager & IWindowingApi 
    }

    // Just for test
    public ICamera MainCamera { get; } = new Camera(Camera.DefaultSize, Camera.DefaultZNear, Camera.DefaultZFar);
}