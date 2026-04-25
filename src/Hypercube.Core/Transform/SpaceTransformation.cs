using Hypercube.Mathematics.Quaternions;

namespace Hypercube.Core.Transform;

public struct SpaceTransformation
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public SpaceTransformation()
    {
        Position = Vector3.Zero;
        Rotation = Quaternion.Identity;
        Scale = Vector3.One;
    }
    
    public SpaceTransformation(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }
}
