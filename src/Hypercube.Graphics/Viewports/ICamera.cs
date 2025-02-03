using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Quaternions;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Viewports;

public interface ICamera
{
    Matrix4x4 Projection { get; }
    Matrix4x4 View { get; }

    Vector2i Size { get; set; }

    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
    Vector3 Scale { get; set; }

    float ZFar { get; }
    float ZNear { get; }
}