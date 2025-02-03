using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Quaternions;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Viewports;

public class Camera : ICamera
{
    public static readonly Vector2i DefaultSize = new(640, 320);
    public const float DefaultZNear = 0.1f;
    public const float DefaultZFar = 100f;
    
    public Matrix4x4 Projection { get; private set; }
    public Matrix4x4 View { get; private set; }

    public Vector2i Size
    {
        get => _size;
        set
        {
            _size = value;
            UpdateProjection();
        }
    }

    public Vector3 Position
    {
        get => _position;
        set
        {
            _position = value;
            UpdateView();
        }
    }

    public Quaternion Rotation
    {
        get => _rotation;
        set
        {
            _rotation = value;
            UpdateView();
        }
    }

    public Vector3 Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            UpdateView();
        }
    }

    public float ZFar { get; }
    public float ZNear { get; }

    private Vector2i _size;
    private Vector3 _position = Vector3.Zero;
    private Quaternion _rotation;
    private Vector3 _scale = new(32, 32, 1);

    public Camera(Vector2i size, float zNear, float zFar)
    {
        Size = size;
        ZNear = zNear;
        ZFar = zFar;
        
        UpdateProjection();
        UpdateView();
    }

    private void UpdateProjection()
    {
        Projection = Matrix4x4.CreateOrthographic(Size, ZNear, ZFar);
    }

    private void UpdateView()
    {
        View = Matrix4x4.CreateTransform(Position, Rotation, Scale);
    }
}