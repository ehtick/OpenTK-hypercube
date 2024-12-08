using JetBrains.Annotations;

namespace Hypercube.Core.Dependencies;

[PublicAPI]
public interface IPostInject
{
    void PostInject();
}