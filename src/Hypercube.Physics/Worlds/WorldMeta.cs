namespace Hypercube.Physics.Worlds;

public struct WorldMeta
{
    public Vector2 Gravity;
    
    public float MaximumLinearSpeed;
    public float MaximumAngularSpeed;

    public bool EnableSleep;
    public bool EnableContinuous;
    public bool EnableContactSoftening;

    public int WorkerCount;
}