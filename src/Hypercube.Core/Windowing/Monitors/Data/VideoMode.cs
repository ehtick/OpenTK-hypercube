namespace Hypercube.Core.Windowing.Monitors.Data;

[PublicAPI]
public readonly struct VideoMode
{
    public readonly Vector2i Size;
    public readonly ColorBits Bits;
    public readonly int RefreshRate;
    
    public VideoMode(Vector2i size, ColorBits bits, int refreshRate)
    {
        Size = size;
        Bits = bits;
        RefreshRate = refreshRate;
    }
    
    public override string ToString()
    {
        return $"{Size.X}x{Size.Y} @ {RefreshRate}Hz ({Bits})";
    }
}
