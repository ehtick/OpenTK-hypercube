using Hypercube.Mathematics.Matrices;

namespace Hypercube.Mathematics.Transforms;

public interface ITransform
{
    Matrix4x4 Matrix { get; }
}