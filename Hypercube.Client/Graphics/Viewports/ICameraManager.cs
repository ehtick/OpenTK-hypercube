using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Client.Graphics.Viewports;

public interface ICameraManager
{
    ICamera? MainCamera { get; }
    
    Matrix4x4 Projection { get; }
    Matrix4x4 View { get; }
    
    
    void SetMainCamera(ICamera camera);
    ICamera CreateCamera2D(Vector2i size);
    void UpdateInput(ICamera? camera, float delta);
}