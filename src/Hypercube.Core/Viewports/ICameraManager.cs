namespace Hypercube.Core.Viewports;

public interface ICameraManager
{
    event Action? OnMainCameraResized;
    
    ICamera MainCamera { get; }
}
