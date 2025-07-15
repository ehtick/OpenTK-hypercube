using Hypercube.Core.Resources.Loaders;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Resources;

public sealed class Model : Resource
{
    public readonly Vector3[] Vertices;
    public readonly Vector3[] Normals;
    public readonly Vector2[] UVs;
    public readonly (int v, int vt, int vn)[] Indices;

    public Model(Vector3[] vertices, Vector3[] normals, Vector2[] uVs, (int v, int vt, int vn)[] indices)
    {
        Vertices = vertices;
        Normals = normals;
        UVs = uVs;
        Indices = indices;
    }

    public override void Dispose()
    {
    }
}