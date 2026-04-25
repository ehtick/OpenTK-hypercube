namespace Hypercube.Core.Windowing.Monitors.Data;

public readonly record struct ColorBits(int R, int G, int B)
{
    public override string ToString()
    {
        return $"R{R}G{G}B{B}";
    }
}
