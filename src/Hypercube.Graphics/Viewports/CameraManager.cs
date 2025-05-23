using Hypercube.Graphics.Windowing.Manager;
using Hypercube.Utilities.Dependencies;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Viewports;

[UsedImplicitly]
public class CameraManager : ICameraManager, IPostInject
{
    [Dependency] private readonly IWindowManager _windowManager = default!;

    public void PostInject()
    {
        // TODO: Implement window scale affect to all camera projections...
        // Need to add cache created windows in IWindowManager & IWindowingApi 
    }
    
    // Just for test
    public ICamera MainCamera { get; } = Camera.Default;
}