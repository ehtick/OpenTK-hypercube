namespace Hypercube.Core.Configuration;

public interface IConfigManager
{
    void Init();
    void Load();
    void Save();
}