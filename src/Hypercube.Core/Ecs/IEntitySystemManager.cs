namespace Hypercube.Core.Ecs;

public interface IEntitySystemManager
{
    IWorld Main { get; }
    void CrateMainWorld();
    IWorld CreateWorld();
}