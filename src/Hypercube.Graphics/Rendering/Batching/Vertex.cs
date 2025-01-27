using System.Runtime.InteropServices;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Rendering.Batching;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Vertex
{
    public const int Size = 9;

    public readonly Vector3 Position;
    public readonly Color Color;
    public readonly Vector2 UVCoords;

    public Vertex(Vector2 position, Vector2 uvCoords, Color color)
    {
        Position = new Vector3(position);
        UVCoords = uvCoords;
        Color = color;
    }
}