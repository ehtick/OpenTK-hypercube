using Hypercube.Core.Systems.Map;
using Hypercube.Mathematics.Quaternions;

namespace Hypercube.Core.Transform;

[PublicAPI]
public struct MapTransformation()
{
    public MapId Map = MapId.Invalid;
    public SpaceTransformation Space = new();
    
    public Vector3 Position
    {
        get => Space.Position;
        set => Space.Position = value;
    }
    
    public Quaternion Rotation
    {
        get => Space.Rotation;
        set => Space.Rotation = value;
    }
    
    public Vector3 Scale
    {
        get => Space.Scale;
        set => Space.Scale = value;
    }
}
