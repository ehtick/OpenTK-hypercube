using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Viewports;

public class CameraManager : ICameraManager
{
    public ICamera MainCamera { get; } = new Camera(new Vector2i(640, 320), Camera.DefaultZNear, Camera.DefaultZFar);
}