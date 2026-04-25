using Hypercube.Physics.Bodies;
using Hypercube.Physics.Shapes;
using Hypercube.Utilities.Collections;

namespace Hypercube.Physics.Worlds;

public class World
{
    public ushort Id;
    public bool Used;
    
    public NumPool<int> BodyIdPool = new();
    public Body[] Bodies = [];
    
    public NumPool<int> ShapeIdPool = new();
    public Shape[] Shapes = [];

    public Vector2 Gravity;

    public void Clear()
    {
        Id = 0;
        Used = false;
        
        BodyIdPool.Reset();
        Bodies = [];
        
        ShapeIdPool.Reset();
        Shapes = [];
    }
}
